using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteTecnico.Core.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnico.Core.Servicos.Tests
{
    [TestClass()]
    public class CoordenadasTests
    {
        [TestMethod()]
        public void RetornarCalculoDistanciaTest()
        {
            double Distancia1 = Coordenadas.RetornarCalculoDistancia(47.712696, -122.083926, 0, 0);

            Assert.AreEqual(12346619.84321486, Distancia1);

            double Distancia2 = Coordenadas.RetornarCalculoDistancia(47.712696, -122.083926, 36.249793, -115.103541);

            Assert.AreEqual(1398904.5676025117, Distancia2);

        }
    }
}