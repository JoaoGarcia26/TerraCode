using System;

namespace TerraCode.Model
{
    public class MovimentacaoCaixas
    {
        public int Id { get; set; }
        public int QuantidadeCaixas { get; set; }

        public DateTime DataMovimentacao { get; set; }
        public string TipoMovimentacao { get; set; }

        public int FazendaOrigemId { get; set; }
        public Fazenda FazendaOrigem { get; set; }

        public int FazendaDestinoId { get; set; }
        public Fazenda FazendaDestino { get; set; }

        public int? PLId { get; set; }
        public PL PL { get; set; }

        public int? MotoristaId { get; set; }
        public Motorista Motorista { get; set; }

        public int? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public string Observacoes { get; set; }
    }
}
