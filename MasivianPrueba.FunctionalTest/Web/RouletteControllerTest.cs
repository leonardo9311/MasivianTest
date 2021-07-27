using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.FunctionalTest.Web
{
    [TestFixture]
    public class RouletteControllerTEst
    {
        public HttpClient Client { get; }
        public RouletteControllerTEst()
        {
            WebTestFixture factory = new WebTestFixture();
            Client = factory.CreateClient();
        }
      
    }
}
