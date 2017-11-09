using System;
using System.Collections.Generic;

namespace SilverHawksUserApi.Models
{
    public class Atleta
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public bool Diretoria { get; set; }

        public ICollection<Presenca> Presencas { get; set; }
    }
}
