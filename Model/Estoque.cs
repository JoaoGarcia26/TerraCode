using System;

namespace TerraCode.Model
{
    public class Estoque
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Evento { get; set; }
        public string DocNr { get; set; }
        public int FazendaId { get; set; }
        public int PLId { get; set; }

        public int? Extra8 { get; set; }
        public int? Cat8 { get; set; }
        public int? Especial8 { get; set; }
        public int? Escovado8 { get; set; }
        public int? Comercial8 { get; set; }

        public int? Extra7 { get; set; }
        public int? Cat7 { get; set; }
        public int? Especial7 { get; set; }
        public int? Escovado7 { get; set; }
        public int? Comercial7 { get; set; }

        public int? Extra6 { get; set; }
        public int? Cat6 { get; set; }
        public int? Especial6 { get; set; }
        public int? Escovado6 { get; set; }
        public int? Comercial6 { get; set; }

        public int? Extra5 { get; set; }
        public int? Cat5 { get; set; }
        public int? Especial5 { get; set; }
        public int? Escovado5 { get; set; }
        public int? Comercial5 { get; set; }

        public int? Extra4 { get; set; }
        public int? Cat4 { get; set; }
        public int? Especial4 { get; set; }
        public int? Escovado4 { get; set; }
        public int? Comercial4 { get; set; }

        public int? Escovado3 { get; set; }

        public int? Borrado20kg { get; set; }
        public int? Escovado2_3 { get; set; }
        public int? Industrial20kg { get; set; }
        public int? Dente20kg { get; set; }
    }
}
