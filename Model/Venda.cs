using System;

namespace TerraCode.Model
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Comprador { get; set; }
        public string Motorista { get; set; }
        public string CPFMotorista { get; set; }
        public string PlacaVeiculo { get; set; }
        public string Produto { get; set; }
        public string NumDoc { get; set; }
        public int QuantidadeCaixas { get; set; }
        public int PLId { get; set; }
    }
}
