using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class PLService
    {
        private PLRepository _plrepository;
        private FazendaRepository _fazendaRepository;
        private SafraRepository _safraRepository;
        public PLService()
        {
            _plrepository = new PLRepository();
            _fazendaRepository = new FazendaRepository();
            _safraRepository = new SafraRepository();
        }

        public ResultadoOperacao CriarPL(string nomePl, string nomeFazenda, string dataPlantio, float hectarePlantados, string observacoes, string nomeSafra)
        {
            if (string.IsNullOrEmpty(nomePl))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Nome do PL é obrigatório." };
            }
            if (string.IsNullOrEmpty(nomeFazenda))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Selecione uma fazenda." };
            }
            if (string.IsNullOrEmpty(dataPlantio))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Data do Plantio é obrigatório." };
            }
            if (hectarePlantados <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Área Plantada deve ser maior que zero." };
            }
            if (string.IsNullOrEmpty(nomeSafra))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Safra é obrigatória." };
            }

            Fazenda fazenda = _fazendaRepository.GetFazendaByNome(nomeFazenda);
            Safra safra = _safraRepository.GetSafraByNome(nomeSafra);

            if (safra == null)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Safra não encontrada." };
            }

            bool sucesso = _plrepository.CreatePL(nomePl, fazenda.Id, dataPlantio, hectarePlantados, observacoes, safra.Id);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true, MensagemErro = "PL cadastrado com sucesso!" };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao salvar o PL." };
            }
        }

        public ResultadoOperacaoComConteudo<PL> RetornaPlPeloIDeFazenda(int numeroPl, string nomeFazenda)
        {
            PL pl = _plrepository.GetPLByIDeFazenda(numeroPl, nomeFazenda);
            return new ResultadoOperacaoComConteudo<PL>() 
            { 
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = pl
            };
        }

        public ResultadoOperacaoComConteudo<PL> RetornaPlPeloNomeeFazenda(string nomePL, string nomeFazenda)
        {
            PL pl = _plrepository.GetPLByNomeeFazenda(nomePL, nomeFazenda);
            return new ResultadoOperacaoComConteudo<PL>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = pl
            };
        }

        public ResultadoOperacaoComConteudo<PL> RetornaPlPeloID(int idPl)
        {
            PL pl = _plrepository.GetPLById(idPl);
            return new ResultadoOperacaoComConteudo<PL>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = pl
            };
        }

        public ResultadoOperacaoComConteudo<List<PL>> RetornaTodosPlDaFazenda(string nomeFazenda)
        {
            List<PL> pls = _plrepository.GetAllPLsByFazenda(nomeFazenda);
            return new ResultadoOperacaoComConteudo<List<PL>>()
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = pls
            };
        }
    }
}
