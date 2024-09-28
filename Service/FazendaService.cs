using System;
using System.Collections.Generic;
using TerraCode.Common;
using TerraCode.Model;
using TerraCode.Repository;

namespace TerraCode.Service
{
    public class FazendaService
    {
        private FazendaRepository _fazendaRepository;
        public FazendaService()
        {
            _fazendaRepository = new FazendaRepository();
        }

        public ResultadoOperacao CriarFazenda(string nome, string localizacao, float areaPlantada, bool isBarracao)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return new ResultadoOperacao{ Sucesso = false, MensagemErro = "Nome da fazenda é obrigatório." };
            }

            if (string.IsNullOrEmpty(localizacao))
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Localização é obrigatória." };
            }

            if (!isBarracao && areaPlantada <= 0)
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Hectare deve ser maior que zero." };
            }

            bool sucesso = _fazendaRepository.CreateFazenda(nome, localizacao, areaPlantada, isBarracao);

            if (sucesso)
            {
                return new ResultadoOperacao { Sucesso = true };
            }
            else
            {
                return new ResultadoOperacao { Sucesso = false, MensagemErro = "Erro ao salvar a fazenda." };
            }
        }

        public ResultadoOperacaoComConteudo<List<Fazenda>> RetornaTodasFazendas()
        {
            List<Fazenda> fazendas = _fazendaRepository.GetAllFazendas();
            return new ResultadoOperacaoComConteudo<List<Fazenda>> 
            { 
                Sucesso = true, 
                MensagemErro = "Ok", 
                Conteudo = fazendas 
            };
        }

        public ResultadoOperacaoComConteudo<Fazenda> RetornaFazendaPeloNome(string nome)
        {
            Fazenda fazenda = _fazendaRepository.GetFazendaByNome(nome);
            return new ResultadoOperacaoComConteudo<Fazenda> 
            { 
                Sucesso = true, 
                MensagemErro = "Ok", 
                Conteudo = fazenda 
            };
        }

        public ResultadoOperacaoComConteudo<Fazenda> RetornaFazendaPeloId(int id)
        {
            Fazenda fazenda = _fazendaRepository.GetFazendaById(id);
            return new ResultadoOperacaoComConteudo<Fazenda>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = fazenda
            };
        }

        public ResultadoOperacaoComConteudo<List<Fazenda>> RetornaSomenteBarracoes()
        {
            List<Fazenda> barracoes = _fazendaRepository.GetSomenteBarracoes();
            return new ResultadoOperacaoComConteudo<List<Fazenda>>
            {
                Sucesso = true,
                MensagemErro = "Ok",
                Conteudo = barracoes
            };
        }
    }
}
