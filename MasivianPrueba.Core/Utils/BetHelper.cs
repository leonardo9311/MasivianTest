using MasivianPrueba.Core.Contanst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Core.Utils
{
    public static class BetHelper
    {
        public static int RandomNumber()
        {
            Random r = new Random();
            return r.Next(Constants.minimunNumberRoulette, Constants.maximunNumberRoulette);          
        }
        public static bool isEvenNumber(int number)
        {
            return number % 2 == 0;
        }
    }
}
