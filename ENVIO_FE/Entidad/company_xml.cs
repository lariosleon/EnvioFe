using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Entidad
{
    public class company_xml
    {
        public Int64 ruc  { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public List<address_company_xml> address { get; set; }

    }
}
