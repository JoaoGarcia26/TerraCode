using System.Collections.Generic;

namespace TerraCode.Model
{
    public class Fazenda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public double Hectare { get; set; }
        public List<PL> PLs { get; set; }
    }
}
