using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class SafraService
    {
        private readonly SafraRepository _safraRepository;

        public SafraService()
        {
            _safraRepository = new SafraRepository();
        }

        public ResultadoOperacao CriarSafra(string nome, int ano)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Nome da Safra é obrigatório." };
            }
            if (ano <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Ano inválido." };
            }

            bool sucesso = _safraRepository.CreateSafra(nome, ano);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true, MensagemErro = "Safra cadastrada com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao salvar a safra." };
            }
        }

        public ResultadoOperacaoComConteudo<Safra> RetornaSafraPeloID(int idSafra)
        {
            Safra safra = _safraRepository.GetSafraById(idSafra);
            return new ResultadoOperacaoComConteudo<Safra>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = safra
            };
        }

        public ResultadoOperacaoComConteudo<Safra> RetornaSafraPeloNome(string nomeSafra)
        {
            Safra safra = _safraRepository.GetSafraByNome(nomeSafra);
            return new ResultadoOperacaoComConteudo<Safra>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = safra
            };
        }

        public ResultadoOperacaoComConteudo<List<Safra>> RetornaTodasSafras()
        {
            List<Safra> safras = _safraRepository.GetAllSafras();
            return new ResultadoOperacaoComConteudo<List<Safra>>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = safras
            };
        }

        public ResultadoOperacao AtualizarSafra(int id, string nome, int ano)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Nome da Safra é obrigatório." };
            }
            if (ano <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Ano inválido." };
            }

            bool sucesso = _safraRepository.UpdateSafra(id, nome, ano);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true, MensagemErro = "Safra atualizada com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao atualizar a safra." };
            }
        }

        public ResultadoOperacao DeletarSafra(int id)
        {
            bool sucesso = _safraRepository.DeleteSafra(id);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true, MensagemErro = "Safra excluída com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao excluir a safra." };
            }
        }
    }
}
