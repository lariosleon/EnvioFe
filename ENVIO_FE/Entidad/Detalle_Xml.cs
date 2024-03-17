using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Entidad
{
    public class Detalle_Xml
    {
        public Int32 tipAfeIgv { get; set; }
        public string codProducto { get; set; }
        public string unidad { get; set; }
        public string descripcion { get; set; }
        public Int32 cantidad { get; set; }
        public Int32 mtoValorUnitario { get; set; }
        public Int32 mtoValorVenta { get; set; }
        public Int32 mtoBaseIgv { get; set; }
        public Int32 porcentajeIgv { get; set; }
        public Int32 igv { get; set; }
        public Int32 totalImpuestos { get; set; }
        public Int32 mtoPrecioUnitario { get; set; }
    }
}
