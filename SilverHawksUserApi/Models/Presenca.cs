using System;
namespace SilverHawksUserApi.Models
{
    public enum TipoPresenca{
        P, J, F    
    }

    public class Presenca
    {
        public int ID { get; set; }
        public int AtletaID { get; set; }
        public int ChamadaID { get; set; }
        public DateTime Data { get; set; }
        public TipoPresenca? Tipo { get; set; }
    }
}
