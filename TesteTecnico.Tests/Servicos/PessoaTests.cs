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
    public class PessoaTests
    {
        [TestMethod()]
        public void AdicionarEntidadeNaListaTest()
        {
            Entidades.Pessoa objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Wanda", "47.712696", "-122,083926");

            Pessoa objServicoPessoa = new Pessoa();
            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            var objPessoaConsultada = objServicoPessoa.ConsultarPorNome("Wanda");

            Assert.AreEqual("Wanda", objPessoa.Nome);
            Assert.AreEqual(47.712696, objPessoa.Latitude);
            Assert.AreEqual(-122.083926, objPessoa.Longitude);

            //--Segundo teste--//

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Vince", "36,249793", "-115,103541");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoaConsultada = objServicoPessoa.ConsultarPorNome("Vince");

            Assert.AreNotEqual("Wanda", objPessoa.Nome);
            Assert.AreNotEqual(47.712696, objPessoa.Latitude);
            Assert.AreNotEqual(-122.083926, objPessoa.Longitude);

            Assert.AreEqual("Vince", objPessoa.Nome);
            Assert.AreEqual(36.249793, objPessoa.Latitude);
            Assert.AreEqual(-115.103541, objPessoa.Longitude);

        }

        [TestMethod()]
        public void ListarPessoasRegistradasTest()
        {
            Entidades.Pessoa objPessoa = new Entidades.Pessoa();
            Pessoa objServicoPessoa = new Pessoa();

            objPessoa.CarregarEntidade("Wanda", "47.712696", "-122,083926");
            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Vince", "36,249793", "-115,103541");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Shirley", "34,023", "-118,353597");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Columbus", "40,478421", "-74,457588");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Annamae", "37,864296", "-87,268739");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("James", "45,069125", "-93,314745");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);


            var lisPessoas = objServicoPessoa.ListarPessoasRegistradas();
            Assert.AreEqual(6, lisPessoas.Count);
        }


        [TestMethod()]
        public void PesquisarTresProximosAmigosTest()
        {
            Entidades.Pessoa objPessoa = new Entidades.Pessoa();
            Pessoa objServicoPessoa = new Pessoa();

            objPessoa.CarregarEntidade("Wanda", "47.712696", "-122,083926");
            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Vince", "36,249793", "-115,103541");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Shirley", "34,023", "-118,353597");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Columbus", "40,478421", "-74,457588");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Annamae", "37,864296", "-87,268739");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("James", "45,069125", "-93,314745");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);


            var lisPessoas = objServicoPessoa.PesquisarTresProximosAmigos(objPessoa);
            Assert.AreEqual(3, lisPessoas.Count);

            foreach (var item in lisPessoas)
            {
                Assert.AreNotEqual("James", item.Nome);
                Assert.AreNotEqual(45.069125, item.Latitude);
                Assert.AreNotEqual(-93.314745, item.Longitude);
            }

            Assert.AreEqual("Annamae", lisPessoas[0].Nome);
            Assert.AreEqual(37.864296, lisPessoas[0].Latitude);
            Assert.AreEqual(-87.268739, lisPessoas[0].Longitude);

            Assert.AreEqual("Columbus", lisPessoas[1].Nome);
            Assert.AreEqual(40.478421, lisPessoas[1].Latitude);
            Assert.AreEqual(-74.457588, lisPessoas[1].Longitude);

            Assert.AreEqual("Vince", lisPessoas[2].Nome);
            Assert.AreEqual(36.249793, lisPessoas[2].Latitude);
            Assert.AreEqual(-115.103541, lisPessoas[2].Longitude);
        }

        [TestMethod()]
        public void ConsultarPorNomeTest()
        {
            Entidades.Pessoa objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Wanda", "47.712696", "-122,083926");

            Pessoa objServicoPessoa = new Pessoa();
            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            var objPessoaConsultada = objServicoPessoa.ConsultarPorNome("Wanda");

            Assert.AreEqual("Wanda", objPessoa.Nome);
            Assert.AreEqual(47.712696, objPessoa.Latitude);
            Assert.AreEqual(-122.083926, objPessoa.Longitude);

            //--Segundo teste--//

            objPessoa = new Entidades.Pessoa();
            objPessoa.CarregarEntidade("Vince", "36,249793", "-115,103541");

            objServicoPessoa.AdicionarEntidadeNaLista(objPessoa);

            objPessoaConsultada = objServicoPessoa.ConsultarPorNome("Vince");

            Assert.AreNotEqual("Wanda", objPessoa.Nome);
            Assert.AreNotEqual(47.712696, objPessoa.Latitude);
            Assert.AreNotEqual(-122.083926, objPessoa.Longitude);

            Assert.AreEqual("Vince", objPessoa.Nome);
            Assert.AreEqual(36.249793, objPessoa.Latitude);
            Assert.AreEqual(-115.103541, objPessoa.Longitude);
        }
    }
}