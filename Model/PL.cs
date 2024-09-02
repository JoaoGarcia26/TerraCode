using System;

namespace TerraCode.Model
{
    public class PL
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int FazendaId { get; set; }
        public string DataDoPlantio { get; set; }
        public double HectarePlantados { get; set; }
        public string Observacoes { get; set; }
        public Fazenda Fazenda { get; set; }
    }
}
