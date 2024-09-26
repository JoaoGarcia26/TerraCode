using System;

namespace TerraCode.Model
{
    public class PreClassificacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int FazendaId { get; set; }
        public int PLId { get; set; }
        public float PesoAlho8 { get; set; }
        public float PesoAlho7 { get; set; }
        public float PesoAlho6 { get; set; }
        public float PesoAlho5 { get; set; }
        public float PesoAlho4 { get; set; }
        public float PesoAlho3 { get; set; }
        public float PesoIndustrial { get; set; }
        public float Descarte { get; set; }
        public float Perda { get; set; }
        public float TotalClassificado { get; set; }
    }
}
