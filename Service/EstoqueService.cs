using System;
using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class EstoqueService
    {
        private EstoqueRepository _estoqueRepository;

        public EstoqueService()
        {
            _estoqueRepository = new EstoqueRepository();
        }

        public ResultadoOperacao CriarEstoque(DateTime data, string evento, string docNr, Dictionary<string, Dictionary<string, int>> classificacoesPorTipo)
        {
            if (string.IsNullOrEmpty(evento))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "O evento não pode ser vazio." };
            }

            if (string.IsNullOrEmpty(docNr))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "O número do documento não pode ser vazio." };
            }

            Estoque estoque = new Estoque
            {
                Data = data,
                Evento = evento,
                DocNr = docNr
            };

            foreach (var tipoClassificacao in classificacoesPorTipo)
            {
                string tipo = tipoClassificacao.Key;
                var valores = tipoClassificacao.Value;

                switch (tipo)
                {
                    case "8":
                        estoque.Extra8 = valores.ContainsKey("Extra") ? valores["Extra"] : 0;
                        estoque.Cat8 = valores.ContainsKey("Cat") ? valores["Cat"] : 0;
                        estoque.Especial8 = valores.ContainsKey("Especial") ? valores["Especial"] : 0;
                        estoque.Escovado8 = valores.ContainsKey("Escovado") ? valores["Escovado"] : 0;
                        estoque.Comercial8 = valores.ContainsKey("Comercial") ? valores["Comercial"] : 0;
                        break;
                    case "7":
                        estoque.Extra7 = valores.ContainsKey("Extra") ? valores["Extra"] : 0;
                        estoque.Cat7 = valores.ContainsKey("Cat") ? valores["Cat"] : 0;
                        estoque.Especial7 = valores.ContainsKey("Especial") ? valores["Especial"] : 0;
                        estoque.Escovado7 = valores.ContainsKey("Escovado") ? valores["Escovado"] : 0;
                        estoque.Comercial7 = valores.ContainsKey("Comercial") ? valores["Comercial"] : 0;
                        break;
                    case "6":
                        estoque.Extra6 = valores.ContainsKey("Extra") ? valores["Extra"] : 0;
                        estoque.Cat6 = valores.ContainsKey("Cat") ? valores["Cat"] : 0;
                        estoque.Especial6 = valores.ContainsKey("Especial") ? valores["Especial"] : 0;
                        estoque.Escovado6 = valores.ContainsKey("Escovado") ? valores["Escovado"] : 0;
                        estoque.Comercial6 = valores.ContainsKey("Comercial") ? valores["Comercial"] : 0;
                        break;
                    case "5":
                        estoque.Extra5 = valores.ContainsKey("Extra") ? valores["Extra"] : 0;
                        estoque.Cat5 = valores.ContainsKey("Cat") ? valores["Cat"] : 0;
                        estoque.Especial5 = valores.ContainsKey("Especial") ? valores["Especial"] : 0;
                        estoque.Escovado5 = valores.ContainsKey("Escovado") ? valores["Escovado"] : 0;
                        estoque.Comercial5 = valores.ContainsKey("Comercial") ? valores["Comercial"] : 0;
                        break;
                    case "4":
                        estoque.Extra4 = valores.ContainsKey("Extra") ? valores["Extra"] : 0;
                        estoque.Cat4 = valores.ContainsKey("Cat") ? valores["Cat"] : 0;
                        estoque.Especial4 = valores.ContainsKey("Especial") ? valores["Especial"] : 0;
                        estoque.Escovado4 = valores.ContainsKey("Escovado") ? valores["Escovado"] : 0;
                        estoque.Comercial4 = valores.ContainsKey("Comercial") ? valores["Comercial"] : 0;
                        break;
                    case "3":
                        estoque.Escovado3 = valores.ContainsKey("numQuantidade") ? valores["numQuantidade"] : 0;
                        break;
                    case "Borrado20kg":
                        estoque.Borrado20kg = valores.ContainsKey("numQuantidade") ? valores["numQuantidade"] : 0;
                        break;
                    case "Escovado2_3":
                        estoque.Escovado2_3 = valores.ContainsKey("numQuantidade") ? valores["numQuantidade"] : 0;
                        break;
                    case "Industrial20kg":
                        estoque.Industrial20kg = valores.ContainsKey("numQuantidade") ? valores["numQuantidade"] : 0;
                        break;
                    case "Dente20kg":
                        estoque.Dente20kg = valores.ContainsKey("numQuantidade") ? valores["numQuantidade"] : 0;
                        break;
                    default:
                        return new ResultadoOperacao { Sucesso = false, MensagemErro = $"Tipo de classificação '{tipo}' desconhecido." };
                }
            }

            // Salva no repositório
            bool sucesso = _estoqueRepository.CreateEstoque(estoque);
            return new ResultadoOperacao
            {
                Sucesso = sucesso,
                MensagemErro = sucesso ? "Estoque criado com sucesso!" : "Erro ao criar estoque."
            };
        }

        public ResultadoOperacaoComConteudo<List<Estoque>> RetornaTodosEstoques()
        {
            List<Estoque> estoques = _estoqueRepository.GetAllEstoques();
            return new ResultadoOperacaoComConteudo<List<Estoque>>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = estoques
            };
        }

        public ResultadoOperacaoComConteudo<Dictionary<string, int>> GetEstoqueGeral()
        {
            var todosEstoques = _estoqueRepository.GetAllEstoques();
            var estoqueGeral = new Dictionary<string, int>
            {
                { "Extra 8", 0 },
                { "Cat 8", 0 },
                { "Especial 8", 0 },
                { "Escovado 8", 0 },
                { "Comercial 8", 0 },
                { "Extra 7", 0 },
                { "Cat 7", 0 },
                { "Especial 7", 0 },
                { "Escovado 7", 0 },
                { "Comercial 7", 0 },
                { "Extra 6", 0 },
                { "Cat 6", 0 },
                { "Especial 6", 0 },
                { "Escovado 6", 0 },
                { "Comercial 6", 0 },
                { "Extra 5", 0 },
                { "Cat 5", 0 },
                { "Especial 5", 0 },
                { "Escovado 5", 0 },
                { "Comercial 5", 0 },
                { "Extra 4", 0 },
                { "Cat 4", 0 },
                { "Especial 4", 0 },
                { "Escovado 4", 0 },
                { "Comercial 4", 0 },
                { "Escovado 3", 0 },
                { "Borrado 20kg", 0 },
                { "Escovado 2/3", 0 },
                { "Industrial 20kg", 0 },
                { "Dente 20kg", 0 }
            };

            foreach (var estoque in todosEstoques)
            {
                estoqueGeral["Extra 8"] += estoque.Extra8;
                estoqueGeral["Cat 8"] += estoque.Cat8;
                estoqueGeral["Especial 8"] += estoque.Especial8;
                estoqueGeral["Escovado 8"] += estoque.Escovado8;
                estoqueGeral["Comercial 8"] += estoque.Comercial8;

                estoqueGeral["Extra 7"] += estoque.Extra7;
                estoqueGeral["Cat 7"] += estoque.Cat7;
                estoqueGeral["Especial 7"] += estoque.Especial7;
                estoqueGeral["Escovado 7"] += estoque.Escovado7;
                estoqueGeral["Comercial 7"] += estoque.Comercial7;

                estoqueGeral["Extra 6"] += estoque.Extra6;
                estoqueGeral["Cat 6"] += estoque.Cat6;
                estoqueGeral["Especial 6"] += estoque.Especial6;
                estoqueGeral["Escovado 6"] += estoque.Escovado6;
                estoqueGeral["Comercial 6"] += estoque.Comercial6;

                estoqueGeral["Extra 5"] += estoque.Extra5;
                estoqueGeral["Cat 5"] += estoque.Cat5;
                estoqueGeral["Especial 5"] += estoque.Especial5;
                estoqueGeral["Escovado 5"] += estoque.Escovado5;
                estoqueGeral["Comercial 5"] += estoque.Comercial5;

                estoqueGeral["Extra 4"] += estoque.Extra4;
                estoqueGeral["Cat 4"] += estoque.Cat4;
                estoqueGeral["Especial 4"] += estoque.Especial4;
                estoqueGeral["Escovado 4"] += estoque.Escovado4;
                estoqueGeral["Comercial 4"] += estoque.Comercial4;

                estoqueGeral["Escovado 3"] += estoque.Escovado3;
                estoqueGeral["Borrado 20kg"] += estoque.Borrado20kg;
                estoqueGeral["Escovado 2/3"] += estoque.Escovado2_3;
                estoqueGeral["Industrial 20kg"] += estoque.Industrial20kg;
                estoqueGeral["Dente 20kg"] += estoque.Dente20kg;
            }

            return new ResultadoOperacaoComConteudo<Dictionary<string, int>>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = estoqueGeral
            };
        }

        public ResultadoOperacaoComConteudo<Estoque> RetornaEstoquePorID(int id)
        {
            Estoque estoque = _estoqueRepository.GetEstoqueById(id);
            return new ResultadoOperacaoComConteudo<Estoque>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = estoque
            };
        }

        public ResultadoOperacao AtualizarEstoque(Estoque estoque)
        {
            bool sucesso = _estoqueRepository.UpdateEstoque(estoque);
            return new ResultadoOperacao
            {
                Sucesso = sucesso,
                MensagemErro = sucesso ? "Estoque atualizado com sucesso!" : "Erro ao atualizar estoque."
            };
        }

        public ResultadoOperacao ExcluirEstoque(int id)
        {
            bool sucesso = _estoqueRepository.DeleteEstoque(id);
            return new ResultadoOperacao
            {
                Sucesso = sucesso,
                MensagemErro = sucesso ? "Estoque excluído com sucesso!" : "Erro ao excluir estoque."
            };
        }
    }
}
