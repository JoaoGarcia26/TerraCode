namespace TerraCode.Model
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string TipoVeiculo { get; set; }
        public Motorista Motorista { get; set; }
    }
}
