using TerraCode.Common;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class CaixaService
    {
        private CaixaRepository _caixaRepository;
        public CaixaService()
        {
            _caixaRepository = new CaixaRepository();
        }

        public ResultadoOperacao RegistrarCaixas(int qtdCaixas, string status) 
        { 
            if (qtdCaixas == 0)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Insira um valor válido nas caixas."};
            }

            if (status == "Entrada")
            {
                bool resultado = _caixaRepository.AtualizarQuantidadeCaixas(qtdCaixas);

                if (resultado)
                {
                    return new ResultadoOperacao() { Sucesso = true, MensagemErro = $"Entrada - {qtdCaixas} Registrado com sucesso!" };
                }
            } else if (status == "Saida")
            {
                bool resultado = _caixaRepository.AtualizarQuantidadeCaixas(-qtdCaixas);

                if (resultado)
                {
                    return new ResultadoOperacao() { Sucesso = true, MensagemErro = $"Saida - {qtdCaixas} Registrado com sucesso!" };
                }
            } else if (string.IsNullOrEmpty(status))
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = $"Selecione um status (Entrada ou Saida)." };
            }
            return new ResultadoOperacao() { Sucesso = false, MensagemErro = $"{status} - Erro durante a operação." };
        }
    }
}
