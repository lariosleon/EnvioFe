using ENVIO_FE.Data;
using ENVIO_FE.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Domain
{
    public class ConsultaClienteBL
    {
        public List<EnvioENT> ConsultarDNIRUC()
        {
            return new ConsultaClienteDAO().GetBuscarCliente();
        }
    }
}
