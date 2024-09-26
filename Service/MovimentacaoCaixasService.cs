using System;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class MovimentacaoCaixasService
    {
        private MovimentacaoCaixasRepository _movimentacaoCaixasRepository;
        private MotoristaService _motoristaService;
        private VeiculoService _veiculoService;
        private FazendaService _fazendaService;
        private PLService _plService;
        private CaixaService _caixaService;
        public MovimentacaoCaixasService()
        {
            _movimentacaoCaixasRepository = new MovimentacaoCaixasRepository();
            _veiculoService = new VeiculoService();
            _motoristaService = new MotoristaService();
            _fazendaService = new FazendaService();
            _plService = new PLService();
            _caixaService = new CaixaService();
        }

        public ResultadoOperacao RegistrarSaidaMovimentacaoCaixas(int qtdCaixas, string nomeDestino, string nomeOrigem, string nomeMotorista, string placaVeiculo, string observacoes)
        {
            if (qtdCaixas <= 0)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Insira uma quantidade de caixas valído." };
            }
            if (string.IsNullOrEmpty(nomeDestino))
            {
                return new ResultadoOperacao() { Sucesso =  false, MensagemErro = "Fazenda Destino é obrigatório."};
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

            MovimentacaoCaixas objMovimentacaoCaixas = new MovimentacaoCaixas()
            {
                CaixaId = 1,
                QuantidadeCaixas = qtdCaixas,
                DataMovimentacao = DateTime.Now,
                TipoMovimentacao = "Saída",
                FazendaDestino = fazendaDestinoResultado.Conteudo,
                FazendaDestinoId = fazendaDestinoResultado.Conteudo.Id,
                FazendaOrigem = fazendaOrigemResultado.Conteudo,
                FazendaOrigemId = fazendaOrigemResultado.Conteudo.Id,
                Motorista = motoristaResultado.Conteudo,
                MotoristaId = motoristaResultado.Conteudo.Id,
                Veiculo = veiculoResultado.Conteudo,
                VeiculoId = veiculoResultado.Conteudo.Id,
                Observacoes = observacoes
            };

            var resultadoCaixa = _caixaService.RegistrarCaixas(qtdCaixas, "Saída");
            
            if (resultadoCaixa.Sucesso)
            {
                bool resultadoMovimentacao = _movimentacaoCaixasRepository.RegistrarMovimentacao(objMovimentacaoCaixas);
                if (resultadoMovimentacao)
                {
                    return new ResultadoOperacao() { Sucesso = true, MensagemErro = "Movimentação de saída registrada!" };
                }
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Estoque insuficiente para completar a operação." };
            } 
            return new ResultadoOperacao() { Sucesso = false, MensagemErro = resultadoCaixa.MensagemErro };
        }
    }
}
