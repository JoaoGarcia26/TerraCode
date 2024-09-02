using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class MotoristaService
    {
        private MotoristaRepository _motoristaRepository;
        public MotoristaService()
        {
            _motoristaRepository = new MotoristaRepository();
        }

        public ResultadoOperacao CriarMotorista(string nome, string endereco, string cnh, string cpf) 
        {
            if (string.IsNullOrEmpty(nome))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "O campo nome é obrigatório."};
            }
            if (string.IsNullOrEmpty(endereco))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "O campo endereço é obrigatório." };
            }
            if (string.IsNullOrEmpty(cnh))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "O campo CNH é obrigatório." };
            }
            if (string.IsNullOrEmpty(cpf))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "O campo CPF é obrigatório." };
            }

            bool resultado = _motoristaRepository.CreateMotorista(nome, endereco, cnh, cpf);
            
            if (resultado)
            {
                return new ResultadoOperacao() { Sucesso = true, MensagemErro = "Motorista cadastrado com sucesso!"};
            } else
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Falha em salvar motorista."};
            }
        }

        public ResultadoOperacaoComConteudo<List<Motorista>> RetornaTodosMotoristas() 
        { 
            List<Motorista> resultado = _motoristaRepository.GetAllMotoristas();

            return new ResultadoOperacaoComConteudo<List<Motorista>>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = resultado
            };
        }

        public ResultadoOperacaoComConteudo<Motorista> RetornaMotoristaPeloNome(string nome)
        {
            var motorista = _motoristaRepository.GetMotoristaByNome(nome);

            return new ResultadoOperacaoComConteudo<Motorista>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = motorista
            };
        }
    }
}
