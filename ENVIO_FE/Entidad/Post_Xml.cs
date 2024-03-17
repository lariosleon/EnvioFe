using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Entidad
{
    public class Post_Xml
    {
        public string tipoDoc { get; set; }
        public string tipoOperacion { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public DateTime fechaemision { get; set; }
        public List<FormaPago_Xml> formaPago { get; set;}
        public string tipoMoneda { get; set; }
        public List<company_xml> company { get; set; }
        public List<Cliente_Xml> client { get; set; }
        public List<Detalle_Xml> details { get; set; }
    }
}
