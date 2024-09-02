using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class VeiculoService
    {
        private VeiculoRepository _veiculoRepository;
        private MotoristaRepository _motoristaRepository;
        public VeiculoService()
        {
            _veiculoRepository = new VeiculoRepository();
        }

        public ResultadoOperacao AdicionarVeiculo(string nomeMotorista, string tipoVeiculo, string placa)
        {
            if (string.IsNullOrEmpty(nomeMotorista))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Nome do motorista é obrigatório."};
            }
            if (string.IsNullOrEmpty(tipoVeiculo))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Tipo do veículo é obrigatório." };
            }
            if (string.IsNullOrEmpty(placa))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Placa do veículo é obrigatório." };
            }

            _motoristaRepository = new MotoristaRepository();

            var objMotorista = _motoristaRepository.GetMotoristaByNome(nomeMotorista);

            if (objMotorista == null)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Motorista não encontrado." };
            }

            bool resultado = _veiculoRepository.CreateVeiculo(placa, tipoVeiculo, objMotorista.Id);

            if (resultado)
            {
                return new ResultadoOperacao() { Sucesso = true, MensagemErro = "Veículo cadastrado com sucesso!"};
            }

            return new ResultadoOperacao() { Sucesso =  false, MensagemErro = "Falha em salvar veículo."};
        }

        public ResultadoOperacaoComConteudo<Veiculo> RetornaVeiculoPelaPlaca(string placa)
        {
            Veiculo veiculo = _veiculoRepository.GetVeiculoByPlaca(placa);
            return new ResultadoOperacaoComConteudo<Veiculo>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = veiculo
            };
        }

        public ResultadoOperacaoComConteudo<List<Veiculo>> RetornaTodosVeiculosPeloMotorista(string nomeMotorista)
        {
            List<Veiculo> veiculos = _veiculoRepository.GetAllVeiculosPorNomeMotorista(nomeMotorista);
            return new ResultadoOperacaoComConteudo<List<Veiculo>>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = veiculos
            };
        }

        public ResultadoOperacaoComConteudo<List<Veiculo>> RetornaTodosVeiculos()
        {
            List<Veiculo> veiculos = _veiculoRepository.GetAllVeiculos();
            return new ResultadoOperacaoComConteudo<List<Veiculo>>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = veiculos
            };
        }
    }
}
