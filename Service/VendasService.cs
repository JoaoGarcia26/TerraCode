using System;
using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class VendasService
    {
        private VendasRepository _vendasRepository;
        private EstoqueService _estoqueService;

        public VendasService()
        {
            _vendasRepository = new VendasRepository();
            _estoqueService = new EstoqueService();
        }

        public ResultadoOperacao CriarVenda(DateTime data, string comprador, string motorista, string cpfMotorista, string placaVeiculo,
            Dictionary<string, int> listaVenda, int plId, int fazendaId, int safraId, string numeroDoc)
        {
            if (string.IsNullOrEmpty(comprador))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Comprador é obrigatório." };
            }

            var estoqueDisponivel = _estoqueService.RetornaEstoqueDisponivelPLeFazenda(fazendaId, plId, "Produção");
            var classificacoesPorTipo = InicializarClassificacoesPorTipo();

            foreach (var item in listaVenda)
            {
                var tipoProduto = item.Key;
                var quantidadeVendida = item.Value;

                if (estoqueDisponivel.Conteudo.TryGetValue(tipoProduto, out int quantidadeEstoque) && quantidadeEstoque >= quantidadeVendida)
                {
                    AtualizarClassificacaoPorTipo(classificacoesPorTipo, tipoProduto, quantidadeVendida);
                }
                else
                {
                    return new ResultadoOperacao { Sucesso = false, MensagemErro = $"Estoque insuficiente para {tipoProduto}. Disponível: {quantidadeEstoque}, solicitado: {quantidadeVendida}." };
                }
            }

            var listaVendaFinal = new Dictionary<string, int>();
            foreach (var categoria in classificacoesPorTipo)
            {
                foreach (var tipo in categoria.Value)
                {
                    string chaveProduto = $"{categoria.Key} {tipo.Key}";
                    listaVendaFinal[chaveProduto] = tipo.Value;
                }
            }

            Console.WriteLine("Classificações Finais:");
            foreach (var categoria in classificacoesPorTipo)
            {
                foreach (var tipo in categoria.Value)
                {
                    string chaveProduto = $"{categoria.Key} {tipo.Key}";
                    Console.WriteLine($"{chaveProduto}: {tipo.Value}");
                }
            }

            var resultadoVenda = _vendasRepository.CreateVenda(data, comprador, motorista, cpfMotorista, placaVeiculo, numeroDoc, listaVendaFinal, plId, fazendaId, safraId);

            if (resultadoVenda)
            {
                var resultadoEstoque = _estoqueService.CriarEstoque(data, "Venda", numeroDoc, fazendaId, plId, classificacoesPorTipo);

                if (resultadoEstoque.Sucesso)
                {
                    return new ResultadoOperacao
                    {
                        Sucesso = true,
                        MensagemErro = "Venda Cadastrada com sucesso!"
                    };
                }
                else
                {
                    return new ResultadoOperacao
                    {
                        Sucesso = false,
                        MensagemErro = resultadoEstoque.MensagemErro
                    };
                }
            }
            else
            {
                return new ResultadoOperacao
                {
                    Sucesso = false,
                    MensagemErro = "Erro ao salvar Venda na tabela Venda."
                };
            }
        }

        private Dictionary<string, Dictionary<string, int>> InicializarClassificacoesPorTipo()
        {
            var classificacoes = new Dictionary<string, Dictionary<string, int>>();
            var tipos = new[] { "8", "7", "6", "5", "4", "3", "Borrado20kg", "Industrial20kg", "Dente20kg", "Escovado2_3" };
            var categorias = new[] { "Extra", "Cat", "Especial", "Escovado", "Comercial", "Borrado", "Industrial", "Dente" };

            foreach (var categoria in categorias)
            {
                var valores = new Dictionary<string, int>();
                foreach (var tipo in tipos)
                {
                    valores[tipo] = 0;
                }
                classificacoes[categoria] = valores;
            }

            return classificacoes;
        }

        private void AtualizarClassificacaoPorTipo(Dictionary<string, Dictionary<string, int>> classificacoesPorTipo, string tipoProduto, int quantidadeVendida)
        {
            string[] partes = tipoProduto.Split(' ');
            string categoria = partes[0];
            string tipoClassificacao = partes.Length > 1 ? partes[1] : null;

            if (!classificacoesPorTipo.ContainsKey(categoria))
            {
                classificacoesPorTipo[categoria] = new Dictionary<string, int>();
            }

            if (!classificacoesPorTipo[categoria].ContainsKey(tipoClassificacao))
            {
                classificacoesPorTipo[categoria][tipoClassificacao] = 0;
            }

            classificacoesPorTipo[categoria][tipoClassificacao] += quantidadeVendida;
        }

        public ResultadoOperacaoComConteudo<Venda> RetornaVendaPorId(int id)
        {
            Venda venda = _vendasRepository.GetVendaById(id);
            if (venda == null)
            {
                return new ResultadoOperacaoComConteudo<Venda>()
                {
                    Sucesso = false,
                    MensagemErro = "Venda não encontrada.",
                    Conteudo = null
                };
            }

            return new ResultadoOperacaoComConteudo<Venda>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = venda
            };
        }

        public ResultadoOperacaoComConteudo<List<Venda>> RetornaTodasVendas()
        {
            List<Venda> vendas = _vendasRepository.GetAllVendas();
            return new ResultadoOperacaoComConteudo<List<Venda>>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = vendas
            };
        }

        public ResultadoOperacao AtualizarVenda(int id, DateTime data, string comprador, string motorista, string cpfMotorista, string placaVeiculo, string produto, int quantidadeCaixas, int plId)
        {
            bool sucesso = _vendasRepository.UpdateVenda(id, data, comprador, motorista, cpfMotorista, placaVeiculo, produto, quantidadeCaixas, plId);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true, MensagemErro = "Venda atualizada com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao atualizar a venda." };
            }
        }

        public ResultadoOperacao DeletarVenda(int id)
        {
            bool sucesso = _vendasRepository.DeleteVenda(id);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true, MensagemErro = "Venda deletada com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao deletar a venda." };
            }
        }
    }
}