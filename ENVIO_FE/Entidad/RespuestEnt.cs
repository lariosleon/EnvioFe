using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Entidad
{
    public class RespuestEnt<T>
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public T Response { get; set; }
    }
    public class MensajeSignalR
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public string DatosJSON { get; set; }
        public TipoAlerta Tipo { get; set; }
    }

    public enum TipoAlerta
    {
        Actividad = 1,
        RespuestaActividad = 2,
        PreferenteAsignado = 3,
        RetornoPreferente = 4,
        ConnectionId = 5,
        ConexionNueva = 6,
        ConexionRechazada = 7,
        ConexionListaUsuario = 8,
        DesconexionUsuario = 9,
        NuevoMensaje = 10,
        CitaReservada = 11,
        ReservaEliminada = 12,
    }
}
