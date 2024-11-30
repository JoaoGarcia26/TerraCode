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

        public ResultadoOperacao CriarEstoque(
    DateTime data,
    string evento,
    string docNr,
    int fazendaId,
    int plId,
    Dictionary<string, Dictionary<string, int>> classificacoesPorTipo)
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
                DocNr = docNr,
                FazendaId = fazendaId,
                PLId = plId
            };

            foreach (var categoria in classificacoesPorTipo)
            {
                string tipo = categoria.Key;
                var valores = categoria.Value;

                foreach (var tipoClassificacao in valores)
                {
                    string tipoProduto = tipoClassificacao.Key;
                    int quantidade = tipoClassificacao.Value;

                    switch (tipo)
                    {
                        case "Extra":
                            if (tipoProduto == "8") estoque.Extra8 = quantidade;
                            else if (tipoProduto == "7") estoque.Extra7 = quantidade;
                            else if (tipoProduto == "6") estoque.Extra6 = quantidade;
                            else if (tipoProduto == "5") estoque.Extra5 = quantidade;
                            else if (tipoProduto == "4") estoque.Extra4 = quantidade;
                            break;

                        case "Cat":
                            if (tipoProduto == "8") estoque.Cat8 = quantidade;
                            else if (tipoProduto == "7") estoque.Cat7 = quantidade;
                            else if (tipoProduto == "6") estoque.Cat6 = quantidade;
                            else if (tipoProduto == "5") estoque.Cat5 = quantidade;
                            else if (tipoProduto == "4") estoque.Cat4 = quantidade;
                            break;

                        case "Comercial":
                            if (tipoProduto == "8") estoque.Comercial8 = quantidade;
                            else if (tipoProduto == "7") estoque.Comercial7 = quantidade;
                            else if (tipoProduto == "6") estoque.Comercial6 = quantidade;
                            else if (tipoProduto == "5") estoque.Comercial5 = quantidade;
                            else if (tipoProduto == "4") estoque.Comercial4 = quantidade;
                            break;

                        case "Especial":
                            if (tipoProduto == "8") estoque.Especial8 = quantidade;
                            else if (tipoProduto == "7") estoque.Especial7 = quantidade;
                            else if (tipoProduto == "6") estoque.Especial6 = quantidade;
                            else if (tipoProduto == "5") estoque.Especial5 = quantidade;
                            else if (tipoProduto == "4") estoque.Especial4 = quantidade;
                            break;

                        case "Escovado":
                            if (tipoProduto == "8") estoque.Escovado8 = quantidade;
                            else if (tipoProduto == "7") estoque.Escovado7 = quantidade;
                            else if (tipoProduto == "6") estoque.Escovado6 = quantidade;
                            else if (tipoProduto == "5") estoque.Escovado5 = quantidade;
                            else if (tipoProduto == "4") estoque.Escovado4 = quantidade;
                            else if (tipoProduto == "3") estoque.Escovado3 = quantidade;
                            else if (tipoProduto == "2/3") estoque.Escovado2_3 = quantidade;
                            break;

                        case "Borrado":
                            if (tipoProduto == "20kg") estoque.Borrado20kg = quantidade;
                            break;

                        case "Industrial":
                            if (tipoProduto == "20kg") estoque.Industrial20kg = quantidade;
                            break;

                        case "Dente":
                            if (tipoProduto == "20kg") estoque.Dente20kg = quantidade;
                            break;

                        default:
                            return new ResultadoOperacao
                            {
                                Sucesso = false,
                                MensagemErro = $"Tipo de classificação '{tipo}' ou '{tipoProduto}' desconhecido."
                            };
                    }
                }
            }

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

        public ResultadoOperacaoComConteudo<Dictionary<string, int>> RetornaEstoqueDisponivelPLeFazenda(int fazendaId, int plId, string evento)
        {
            var estoqueAtual = _estoqueRepository.GetEstoqueAtual(fazendaId, plId, evento);

            var estoqueDisponivel = new Dictionary<string, int>
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

            foreach (var key in estoqueAtual.Keys)
            {
                estoqueDisponivel[key] = estoqueAtual[key];
            }

            return new ResultadoOperacaoComConteudo<Dictionary<string, int>>()
            {
                Sucesso = true,
                Conteudo = estoqueDisponivel
            };
        }
    
        public ResultadoOperacaoComConteudo<List<Estoque>> RetornaEstoqueFiltrado(DateTime? dataInicial = null, DateTime? dataFinal = null, string evento = null, string documento = null)
        {
            List<Estoque> estoques = _estoqueRepository.RetornaEstoquesFiltrado(dataInicial, dataFinal, evento, documento, null, null, null);
            return new ResultadoOperacaoComConteudo<List<Estoque>>
            {
                Sucesso = true,
                MensagemErro = "OK",
                Conteudo = estoques
            };
        }

        public ResultadoOperacaoComConteudo<Dictionary<string, int>> GetEstoqueGeralPorFazendaEPL(int? fazendaId = null, int? plId = null, int? safraId = null)
        {
            var todosEstoques = _estoqueRepository.RetornaEstoquesFiltrado(null, null, null, null, fazendaId, plId, safraId);
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
                int multiplier = estoque.Evento == "Venda" ? -1 : 1;

                estoqueGeral["Extra 8"] += (estoque.Extra8 ?? 0) * multiplier;
                estoqueGeral["Cat 8"] += (estoque.Cat8 ?? 0) * multiplier;
                estoqueGeral["Especial 8"] += (estoque.Especial8 ?? 0) * multiplier;
                estoqueGeral["Escovado 8"] += (estoque.Escovado8 ?? 0) * multiplier;
                estoqueGeral["Comercial 8"] += (estoque.Comercial8 ?? 0) * multiplier;

                estoqueGeral["Extra 7"] += (estoque.Extra7 ?? 0) * multiplier;
                estoqueGeral["Cat 7"] += (estoque.Cat7 ?? 0) * multiplier;
                estoqueGeral["Especial 7"] += (estoque.Especial7 ?? 0) * multiplier;
                estoqueGeral["Escovado 7"] += (estoque.Escovado7 ?? 0) * multiplier;
                estoqueGeral["Comercial 7"] += (estoque.Comercial7 ?? 0) * multiplier;

                estoqueGeral["Extra 6"] += (estoque.Extra6 ?? 0) * multiplier;
                estoqueGeral["Cat 6"] += (estoque.Cat6 ?? 0) * multiplier;
                estoqueGeral["Especial 6"] += (estoque.Especial6 ?? 0) * multiplier;
                estoqueGeral["Escovado 6"] += (estoque.Escovado6 ?? 0) * multiplier;
                estoqueGeral["Comercial 6"] += (estoque.Comercial6 ?? 0) * multiplier;

                estoqueGeral["Extra 5"] += (estoque.Extra5 ?? 0) * multiplier;
                estoqueGeral["Cat 5"] += (estoque.Cat5 ?? 0) * multiplier;
                estoqueGeral["Especial 5"] += (estoque.Especial5 ?? 0) * multiplier;
                estoqueGeral["Escovado 5"] += (estoque.Escovado5 ?? 0) * multiplier;
                estoqueGeral["Comercial 5"] += (estoque.Comercial5 ?? 0) * multiplier;

                estoqueGeral["Extra 4"] += (estoque.Extra4 ?? 0) * multiplier;
                estoqueGeral["Cat 4"] += (estoque.Cat4 ?? 0) * multiplier;
                estoqueGeral["Especial 4"] += (estoque.Especial4 ?? 0) * multiplier;
                estoqueGeral["Escovado 4"] += (estoque.Escovado4 ?? 0) * multiplier;
                estoqueGeral["Comercial 4"] += (estoque.Comercial4 ?? 0) * multiplier;

                estoqueGeral["Escovado 3"] += (estoque.Escovado3 ?? 0) * multiplier;
                estoqueGeral["Borrado 20kg"] += (estoque.Borrado20kg ?? 0) * multiplier;
                estoqueGeral["Escovado 2/3"] += (estoque.Escovado2_3 ?? 0) * multiplier;
                estoqueGeral["Industrial 20kg"] += (estoque.Industrial20kg ?? 0) * multiplier;
                estoqueGeral["Dente 20kg"] += (estoque.Dente20kg ?? 0) * multiplier;
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

        public ResultadoOperacaoComConteudo<Estoque> RetornaEstoquePorNumDoc(string numDoc)
        {
            Estoque estoque = _estoqueRepository.GetEstoqueByNumDoc(numDoc);
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
