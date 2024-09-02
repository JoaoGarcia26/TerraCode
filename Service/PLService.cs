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
        public PLService()
        {
            _plrepository = new PLRepository();
            _fazendaRepository = new FazendaRepository();
        }

        public ResultadoOperacao CriarPL(string nomePl, string nomeFazenda, string dataPlantio, float hectarePlantados, string observacoes)
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

            Fazenda fazenda = _fazendaRepository.GetFazendaByNome(nomeFazenda);

            bool sucesso = _plrepository.CreatePL(nomePl, fazenda.Id, dataPlantio, hectarePlantados, observacoes);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true, MensagemErro = "PL cadastrado com sucesso!" };
            } else
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
