using System;
using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class MovimentacaoProducaoRocaService
    {
        private MovimentacaoProducaoRocaRepository _movimentacaoRepository;

        public MovimentacaoProducaoRocaService()
        {
            _movimentacaoRepository = new MovimentacaoProducaoRocaRepository();
        }

        public ResultadoOperacao CriarMovimentacao(int motoristaId, int veiculoId, int fazendaId, int plId, float pesoTotal, int numCaixas, DateTime dataEntrada)
        {
            if (motoristaId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID do motorista é obrigatório." };
            }

            if (veiculoId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID do veículo é obrigatório." };
            }

            if (fazendaId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID da fazenda é obrigatório." };
            }

            if (plId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID do PL é obrigatório." };
            }

            if (pesoTotal <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Peso total deve ser maior que zero." };
            }

            if (numCaixas <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Número de caixas deve ser maior que zero." };
            }

            bool sucesso = _movimentacaoRepository.CreateMovimentacao(motoristaId, veiculoId, fazendaId, plId, pesoTotal, numCaixas, dataEntrada);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao salvar a movimentação." };
            }
        }

        public ResultadoOperacaoComConteudo<List<MovimentacaoProducaoRoca>> RetornaTodasMovimentacoes()
        {
            List<MovimentacaoProducaoRoca> movimentacoes = _movimentacaoRepository.GetAllMovimentacoes();
            return new ResultadoOperacaoComConteudo<List<MovimentacaoProducaoRoca>>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = movimentacoes
            };
        }

        public ResultadoOperacaoComConteudo<MovimentacaoProducaoRoca> RetornaMovimentacaoPeloId(int idEntrada)
        {
            if (idEntrada <= 0)
            {
                return new ResultadoOperacaoComConteudo<MovimentacaoProducaoRoca>
                {
                    Sucesso = false,
                    MensagemErro = "ID da movimentação é obrigatório."
                };
            }

            MovimentacaoProducaoRoca movimentacao = _movimentacaoRepository.GetMovimentacaoById(idEntrada);
            return new ResultadoOperacaoComConteudo<MovimentacaoProducaoRoca>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = movimentacao
            };
        }

        public ResultadoOperacao AtualizarMovimentacao(int idEntrada, int motoristaId, int veiculoId, int fazendaId, int plId, float pesoTotal, int numCaixas, DateTime dataEntrada)
        {
            if (motoristaId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID do motorista é obrigatório." };
            }

            if (veiculoId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID do veículo é obrigatório." };
            }

            if (fazendaId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID da fazenda é obrigatório." };
            }

            if (plId <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID do PL é obrigatório." };
            }

            if (pesoTotal <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Peso total deve ser maior que zero." };
            }

            if (numCaixas <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Número de caixas deve ser maior que zero." };
            }

            bool sucesso = _movimentacaoRepository.UpdateMovimentacao(idEntrada, motoristaId, veiculoId, fazendaId, plId, pesoTotal, numCaixas, dataEntrada);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao atualizar a movimentação." };
            }
        }

        public ResultadoOperacao DeletarMovimentacao(int idEntrada)
        {
            if (idEntrada <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "ID da movimentação é obrigatório." };
            }

            bool sucesso = _movimentacaoRepository.DeleteMovimentacao(idEntrada);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao deletar a movimentação." };
            }
        }
    }
}
