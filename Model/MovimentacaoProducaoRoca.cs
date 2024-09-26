using System;

namespace TerraCode.Model
{
    public class MovimentacaoProducaoRoca
    {
        public int IdEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public int MotoristaId { get; set; }
        public int VeiculoId { get; set; }
        public int FazendaId { get; set; }
        public int PLId { get; set; }
        public double PesoTotal { get; set; }
        public int NumCaixas { get; set; }
    }
}
