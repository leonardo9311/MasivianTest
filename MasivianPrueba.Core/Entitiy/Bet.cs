using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Core.Entitiy
{
    public  class Bet :BaseEntity
    {
        public int number { get; set; }
        public int amount { get; set; }
        public string idUser { get; set; }
        public int idRoullette { get; set; }
        public Roulette Roulette { get; set; }
    }
}
