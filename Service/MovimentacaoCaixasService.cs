using System;
using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class MovimentacaoCaixasService
    {
        private readonly MovimentacaoCaixasRepository _movimentacaoCaixasRepository;
        private readonly MotoristaService _motoristaService;
        private readonly FazendaService _fazendaService;
        private readonly VeiculoService _veiculoService;
        private readonly CaixaService _caixaService;

        public MovimentacaoCaixasService()
        {
            _movimentacaoCaixasRepository = new MovimentacaoCaixasRepository();
            _motoristaService = new MotoristaService();
            _fazendaService = new FazendaService();
            _veiculoService = new VeiculoService();
            _caixaService = new CaixaService();
        }

        public ResultadoOperacao RegistrarEntradaMovimentacaoCaixas(DateTime dataRecebida, int qtdCaixas, string nomeDestino, string nomeOrigem, string nomeMotorista, string placaVeiculo, string observacoes)
        {
            if (qtdCaixas <= 0)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Insira uma quantidade de caixas válida." };
            }
            if (string.IsNullOrEmpty(nomeDestino))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Fazenda Destino é obrigatório." };
            }
            if (string.IsNullOrEmpty(nomeOrigem))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Fazenda Origem é obrigatório." };
            }
            if (string.IsNullOrEmpty(nomeMotorista))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Motorista é obrigatório." };
            }
            if (string.IsNullOrEmpty(placaVeiculo))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Veículo é obrigatório." };
            }

            var motoristaResultado = _motoristaService.RetornaMotoristaPeloNome(nomeMotorista);
            var fazendaDestinoResultado = _fazendaService.RetornaFazendaPeloNome(nomeDestino);
            var fazendaOrigemResultado = _fazendaService.RetornaFazendaPeloNome(nomeOrigem);
            var veiculoResultado = _veiculoService.RetornaVeiculoPelaPlaca(placaVeiculo);

            if (motoristaResultado.Conteudo == null || fazendaDestinoResultado.Conteudo == null || fazendaOrigemResultado.Conteudo == null || veiculoResultado.Conteudo == null)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Um ou mais registros não encontrados." };
            }

            var movimentacao = new MovimentacaoCaixas
            {
                DataMovimentacao = dataRecebida,
                QuantidadeCaixas = qtdCaixas,
                TipoMovimentacao = "Entrada",
                FazendaOrigemId = fazendaOrigemResultado.Conteudo.Id,
                FazendaDestinoId = fazendaDestinoResultado.Conteudo.Id,
                MotoristaId = motoristaResultado.Conteudo.Id,
                VeiculoId = veiculoResultado.Conteudo.Id,
                Observacoes = observacoes
            };

            var resultadoMovimentacao = _movimentacaoCaixasRepository.RegistrarMovimentacao(movimentacao);

            if (!resultadoMovimentacao)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Falha ao registrar a movimentação." };
            }

            var resultadoCaixas = _caixaService.AumentarCaixas(qtdCaixas, fazendaDestinoResultado.Conteudo.Id);
            _caixaService.RemoverCaixas(qtdCaixas, fazendaOrigemResultado.Conteudo.Id);
            return resultadoCaixas;
        }

        public ResultadoOperacao RegistrarSaidaMovimentacaoCaixas(DateTime dataRecebida, int qtdCaixas, string nomeOrigem, string nomeDestino, string nomeMotorista, string placaVeiculo, string observacoes)
        {
            if (qtdCaixas <= 0)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Insira uma quantidade de caixas válida." };
            }
            if (string.IsNullOrEmpty(nomeDestino))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Fazenda Destino é obrigatório." };
            }
            if (string.IsNullOrEmpty(nomeOrigem))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Fazenda Origem é obrigatório." };
            }
            if (string.IsNullOrEmpty(nomeMotorista))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Motorista é obrigatório." };
            }
            if (string.IsNullOrEmpty(placaVeiculo))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Veículo é obrigatório." };
            }

            var motoristaResultado = _motoristaService.RetornaMotoristaPeloNome(nomeMotorista);
            var fazendaDestinoResultado = _fazendaService.RetornaFazendaPeloNome(nomeDestino);
            var fazendaOrigemResultado = _fazendaService.RetornaFazendaPeloNome(nomeOrigem);
            var veiculoResultado = _veiculoService.RetornaVeiculoPelaPlaca(placaVeiculo);

            if (motoristaResultado.Conteudo == null || fazendaDestinoResultado.Conteudo == null || fazendaOrigemResultado.Conteudo == null || veiculoResultado.Conteudo == null)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Um ou mais registros não encontrados." };
            }

            var movimentacao = new MovimentacaoCaixas
            {
                DataMovimentacao = dataRecebida,
                QuantidadeCaixas = qtdCaixas,
                TipoMovimentacao = "Saída",
                FazendaOrigemId = fazendaOrigemResultado.Conteudo.Id,
                FazendaDestinoId = fazendaDestinoResultado.Conteudo.Id,
                MotoristaId = motoristaResultado.Conteudo.Id,
                VeiculoId = veiculoResultado.Conteudo.Id,
                Observacoes = observacoes
            };

            var resultadoMovimentacao = _movimentacaoCaixasRepository.RegistrarMovimentacao(movimentacao);

            if (!resultadoMovimentacao)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Falha ao registrar a movimentação." };
            }

            var resultadoCaixas = _caixaService.RemoverCaixas(qtdCaixas, fazendaOrigemResultado.Conteudo.Id);
            _caixaService.AumentarCaixas(qtdCaixas, fazendaDestinoResultado.Conteudo.Id);
            return resultadoCaixas;
        }

        public ResultadoOperacaoComConteudo<List<MovimentacaoCaixas>> ObterTodasMovimentacoes()
        {
            var movimentacoes = _movimentacaoCaixasRepository.ObterTodasMovimentacoes();

            return new ResultadoOperacaoComConteudo<List<MovimentacaoCaixas>>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = movimentacoes
            };
        }
    }
}
