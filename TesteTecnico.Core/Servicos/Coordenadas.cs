using System.Device.Location;

namespace TesteTecnico.Core.Servicos
{
    public class Coordenadas
    {
        ////Referencia do calculo de distancia:
        ////https://msdn.microsoft.com/en-us/library/system.device.location.geocoordinate(v=vs.110).aspx

        /// <summary>
        /// Função que realiza o calculo entre a distancia de dois pontos geograficos
        /// </summary>
        /// <param name="sLatitude">Latitude de Origem</param>
        /// <param name="sLongitude">Longitude de Origem</param>
        /// <param name="eLatitude">Latitude de Destino</param>
        /// <param name="eLongitude">Longitude de Destino</param>
        /// <returns>Distancia em Metros</returns>
        public static double RetornarCalculoDistancia(double sLatitude, double sLongitude, double eLatitude, double eLongitude)
        {
            var sCoord = new GeoCoordinate(sLatitude, sLongitude);
            var eCoord = new GeoCoordinate(eLatitude, eLongitude);

            return sCoord.GetDistanceTo(eCoord);
        }

    }
}
