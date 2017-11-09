using System;
using System.Collections.Generic;

namespace SilverHawksUserApi.Models
{
    public class Chamada
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Presenca> Presencas { get; set; }
    }
}
