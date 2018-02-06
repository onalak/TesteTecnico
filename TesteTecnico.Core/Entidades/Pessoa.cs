using System;

namespace TesteTecnico.Core.Entidades
{
    public class Pessoa
    {
        #region Variaveis e propriedades

        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        #endregion

        #region Funções da entidade 

        public void CarregarEntidade(string strNome, string strLatitude, string strLongitude)
        {
            this.Nome = strNome;

            try
            {
                this.Latitude = Convert.ToDouble(strLatitude.Replace(".", ","));
            }
            catch
            {
                throw new ArgumentException("O valor de Latitude está fora do formato numérico", "Latitude");
            }

            try
            {
                this.Longitude = Convert.ToDouble(strLongitude.Replace(".", ","));
            }
            catch
            {
                throw new ArgumentException("O valor de Longitude está fora do formato numérico", "Longitude");
            }

            //Realizar validação dos valores possiveis de Latitude e Longitude
            if (!ValidarValoresLatitude())
            {
                throw new ArgumentOutOfRangeException("Latitude", "Valores aceitos na Latitude é de -90 até +90");
            }

            if (!ValidarValoresLongitude())
            {
                throw new ArgumentOutOfRangeException("Longitude", "Valores aceitos na Longitude é de -180 até +180");
            }
        }

        private bool ValidarValoresLatitude()
        {
            return (this.Latitude > -90 && this.Latitude < 90);
        }

        private bool ValidarValoresLongitude()
        {
            return (this.Longitude > -180 && this.Longitude < 180);
        }

        #endregion  
    }
}
