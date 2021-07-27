using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MasivianPrueba.Core.Entitiy
{
    public class Roulette : BaseEntity
    {
       public bool isOpen { get; set; }
        [JsonIgnore]
        public ICollection<Bet> bets { get; set; }
    }
}
