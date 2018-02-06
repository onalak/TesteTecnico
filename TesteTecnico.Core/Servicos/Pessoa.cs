using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteTecnico.Core.Servicos
{
    public class Pessoa
    {

        #region Variaveis e propriedades

        private List<Entidades.Pessoa> Pessoas { get; set; }

        #endregion

        #region Construtor

        public Pessoa()
        {
            if (Pessoas == null)
            {
                Pessoas = new List<Entidades.Pessoa>();
            }
        }

        #endregion

        #region Funcoes Privativas 

        private bool PesquisarSeJaTemPessoaNaLocalizacao(Entidades.Pessoa objPessoa)
        {
            var Pesquisa = Pessoas.Where(o => o.Latitude.Equals(objPessoa.Latitude) && o.Longitude.Equals(objPessoa.Longitude)).SingleOrDefault();
            return (Pesquisa == null);
        }

        #endregion

        #region Funcoes Publicas

        public void AdicionarEntidadeNaLista(Entidades.Pessoa objPessoa)
        {
            if (PesquisarSeJaTemPessoaNaLocalizacao(objPessoa))
            {
                Pessoas.Add(objPessoa);
            }
            else
            {
                throw new ArgumentException("Já existe uma pessoa que foi cadastrada nessa localização geográfica");
            }
        }

        public List<Entidades.Pessoa> ListarPessoasRegistradas()
        {
            return Pessoas;
        }

        public List<Entidades.PessoaDistancia> PesquisarTresProximosAmigos(Entidades.Pessoa objPessoaOrigem)
        {
            List<Entidades.PessoaDistancia> PessoasDistancia = new List<Entidades.PessoaDistancia>();

            foreach (var objPessoa in Pessoas)
            {
                PessoasDistancia.Add(new Entidades.PessoaDistancia()
                {
                    Nome = objPessoa.Nome,
                    Latitude = objPessoa.Latitude,
                    Longitude = objPessoa.Longitude,
                    Distancia = Coordenadas.RetornarCalculoDistancia(objPessoaOrigem.Latitude, objPessoaOrigem.Longitude, objPessoa.Latitude, objPessoa.Longitude)
                });
            }

            return PessoasDistancia.Where(o => !o.Distancia.Equals(0)).OrderBy(o => o.Distancia).Take(3).ToList();
        }

        public Entidades.Pessoa ConsultarPorNome(string strNome)
        {
            return Pessoas.Where(o => o.Nome.Equals(strNome)).SingleOrDefault();
        }

        #endregion

    }
}
