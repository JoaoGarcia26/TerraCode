using System;
using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class PreClassificacaoService
    {
        private PreClassificacaoRepository _preClassificacaoRepository;
        private FazendaService _fazendaService;
        private PLService _plService;

        public PreClassificacaoService()
        {
            _preClassificacaoRepository = new PreClassificacaoRepository();
            _fazendaService = new FazendaService();
            _plService = new PLService();
        }

        public ResultadoOperacao CriarPreClassificacao(DateTime data, string nomeFazenda, string nomePL, float alho08, float alho07,
    float alho06, float alho05, float alho04, float alho03, float alhoIndustrial, float descarte, float pesoTotalClassificado)
        {
            if (pesoTotalClassificado <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Total classificado deve ser maior que zero." };
            }

            if (string.IsNullOrEmpty(nomeFazenda))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Fazenda não pode ser vazia." };
            }

            if (string.IsNullOrEmpty(nomePL))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "PL não pode ser vazio." };
            }

            float somaClassificacoes = alho08 + alho07 + alho06 + alho05 + alho04 + alho03 + alhoIndustrial + descarte;
            if (somaClassificacoes > pesoTotalClassificado)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Soma das classificações e descarte não pode ser maior que o total classificado." };
            }

            var fazenda = _fazendaService.RetornaFazendaPeloNome(nomeFazenda).Conteudo;
            if (fazenda == null)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Fazenda não encontrada." };
            }

            var pl = _plService.RetornaPlPeloNomeeFazenda(nomePL, nomeFazenda).Conteudo;
            if (pl == null)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "PL não encontrado." };
            }

            float perda = pesoTotalClassificado - (alho08 + alho07 + alho06 + alho05 + alho04 + alho03 + alhoIndustrial + descarte);

            PreClassificacao preClassificacao = new PreClassificacao
            {
                Data = data,
                FazendaId = fazenda.Id,
                PLId = pl.Id,
                PesoAlho8 = alho08,
                PesoAlho7 = alho07,
                PesoAlho6 = alho06,
                PesoAlho5 = alho05,
                PesoAlho4 = alho04,
                PesoAlho3 = alho03,
                PesoIndustrial = alhoIndustrial,
                Descarte = descarte,
                Perda = perda,
                TotalClassificado = pesoTotalClassificado
            };

            bool sucesso = _preClassificacaoRepository.CreatePreClassificacao(preClassificacao);
            return new ResultadoOperacao
            {
                Sucesso = sucesso,
                MensagemErro = sucesso ? "Pré-classificação criada com sucesso!" : "Erro ao criar pré-classificação."
            };
        }

        public ResultadoOperacaoComConteudo<List<PreClassificacao>> RetornaTodasPreClassificacoes()
        {
            List<PreClassificacao> preClassificacoes = _preClassificacaoRepository.GetAllPreClassificacoes();
            return new ResultadoOperacaoComConteudo<List<PreClassificacao>>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = preClassificacoes
            };
        }

        public ResultadoOperacaoComConteudo<PreClassificacao> RetornaPreClassificacoesPorData(DateTime dateTime)
        {
            PreClassificacao preClassificacoes = _preClassificacaoRepository.GetPreClassificacoesByData(dateTime);
            return new ResultadoOperacaoComConteudo<PreClassificacao>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = preClassificacoes
            };
        }
    }
}
