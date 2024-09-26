using System;
using System.Collections.Generic;
using System.Linq;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class PosClassificacaoService
    {
        private PosClassificacaoRepository _posClassificacaoRepository;
        private PreClassificacaoRepository _preClassificacaoRepository;
        private PreClassificacaoService _preClassificacaoService;

        public PosClassificacaoService()
        {
            _posClassificacaoRepository = new PosClassificacaoRepository();
            _preClassificacaoRepository = new PreClassificacaoRepository();
            _preClassificacaoService = new PreClassificacaoService();
        }

        public ResultadoOperacao CriarPosClassificacao(int preClassificacaoId, string categoria, float quantidade)
        {
            if (string.IsNullOrEmpty(categoria))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Categoria não pode ser vazia." };
            }

            if (quantidade <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Quantidade deve ser maior que zero." };
            }

            // Busca a pré-classificação correspondente
            var preClassificacao = _preClassificacaoRepository.GetAllPreClassificacoes().Find(pc => pc.Id == preClassificacaoId);
            if (preClassificacao == null)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Pré-classificação não encontrada." };
            }

            // Calcula a quantidade já distribuída para essa categoria
            var distribuido = _posClassificacaoRepository.GetAllPosClassificacoes()
                                .FindAll(pc => pc.PreClassificacaoId == preClassificacaoId && pc.Categoria == categoria)
                                .ConvertAll(pc => pc.Quantidade)
                                .Sum();

            // Verifica se há quantidade disponível para distribuição
            float quantidadeDisponivel = preClassificacao.TotalClassificado - distribuido;
            if (quantidade > quantidadeDisponivel)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = $"Quantidade excede o disponível para esta categoria. Disponível: {quantidadeDisponivel}kg." };
            }

            // Criação do objeto de pós-classificação
            PosClassificacao posClassificacao = new PosClassificacao
            {
                PreClassificacaoId = preClassificacaoId,
                Categoria = categoria,
                Quantidade = quantidade,
                Data = DateTime.Now
            };

            // Persistência no banco de dados
            bool sucesso = _posClassificacaoRepository.CreatePosClassificacao(posClassificacao);
            return new ResultadoOperacao
            {
                Sucesso = sucesso,
                MensagemErro = sucesso ? "Pós-classificação criada com sucesso!" : "Erro ao criar pós-classificação."
            };
        }

        public ResultadoOperacaoComConteudo<List<PosClassificacao>> RetornaTodasPosClassificacoes()
        {
            List<PosClassificacao> posClassificacoes = _posClassificacaoRepository.GetAllPosClassificacoes();
            return new ResultadoOperacaoComConteudo<List<PosClassificacao>>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = posClassificacoes
            };
        }
    }
}
