using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Core.Dto
{
    public class BetResultDto
    {
        public int idBet { get; set; }
        public float earnedAmount { get; set; }
        public int amountbet { get; set; }
        public string idUser { get; set; }
        public bool isEvenNumber { get; set; }
    }
}
