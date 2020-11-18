using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruebaDGT.Services;

namespace PruebaDGT.Models.ModelosPropios
{
    public class ConteoPuntosController : ApiController
    {
        private DGTEntities db = new DGTEntities();
        public ConteoPuntos Get(string id)
        {
            //Se obtiene la lista de infracciones
            List<InfraccionVehiculo> liInfVeh = InfraccionVehiculoService.getInfraccionVehiculoByDni(id);

            //Se crea el conductor e informa el conteo de puntos
            ConteoPuntos oConteo = informarConteoPuntos(liInfVeh);

            return oConteo;
        }



        // ----------- Métodos auxiliares -----------
        #region Metodos Auxilialers
        private ConteoPuntos informarConteoPuntos(List<InfraccionVehiculo> liInfVeh)
        {
            try
            {
                ConteoPuntos oConteo = new ConteoPuntos();
                oConteo.Nombre = liInfVeh.First().Conductores.nombre + " " + liInfVeh.First().Conductores.apellidos;
                oConteo.Dni = liInfVeh.First().Conductores.dni;
                oConteo.ListaInfracciones = new List<ListaInfracciones>();

                int i = 0;
                int? ultPuntos = 0;
                int ultMulta = 0;
                foreach (InfraccionVehiculo oInfVeh in liInfVeh)
                {

                    ListaInfracciones oLista = new ListaInfracciones();
                    oLista.Infraccion = oInfVeh.Infracciones.descripcion;
                    oLista.Fecha = oInfVeh.fecha;
                    oLista.PuntosRestados = oInfVeh.Infracciones.puntos;

                    if (i == 0)
                    {
                        oLista.PuntosRestantes = oInfVeh.Conductores.puntos;
                        ultPuntos = oInfVeh.Conductores.puntos;
                    }
                    else
                    {
                        oLista.PuntosRestantes = ultPuntos + ultMulta;
                        ultPuntos = oLista.PuntosRestantes;
                    }

                    oConteo.ListaInfracciones.Add(oLista);
                    ultMulta = oInfVeh.Infracciones.puntos;
                    i++;

                }

                return oConteo;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
