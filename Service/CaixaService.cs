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

        public ResultadoOperacao AumentarCaixas(int qtdCaixas, int fazendaId)
        {
            if (qtdCaixas <= 0)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Insira um valor válido nas caixas." };
            }

            bool resultado = _caixaRepository.AumentarCaixas(fazendaId, qtdCaixas);

            if (resultado)
            {
                return new ResultadoOperacao() { Sucesso = true, MensagemErro = $"Entrada de {qtdCaixas} caixas registrada com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Erro durante a operação de adicionar caixas." };
            }
        }

        public ResultadoOperacao RemoverCaixas(int qtdCaixas, int fazendaId)
        {
            if (qtdCaixas <= 0)
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Insira um valor válido nas caixas." };
            }

            bool resultado = _caixaRepository.DiminuirCaixas(fazendaId, qtdCaixas);

            if (resultado)
            {
                return new ResultadoOperacao() { Sucesso = true, MensagemErro = $"Saída de {qtdCaixas} caixas registrada com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao() { Sucesso = false, MensagemErro = "Erro durante a operação de remover caixas." };
            }
        }

        public ResultadoOperacaoComConteudo<int> RetornaTotalDeCaixasPorFazenda(int fazendaId)
        {
            int resultado = _caixaRepository.ObterCaixasDisponiveis(fazendaId);
            return new ResultadoOperacaoComConteudo<int>()
            {
                Sucesso = true,
                MensagemErro = "Operação realizada com sucesso.",
                Conteudo = resultado
            };
        }
    }
}