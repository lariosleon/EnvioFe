using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ENVIO_FE.Data
{
    public class ConexionDAO
    {
        public string GetCnx()
        {
            string strgCnx = ConfigurationManager.ConnectionStrings["SQL_SERVER"].ConnectionString;

            if (object.ReferenceEquals(strgCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strgCnx;
            }
        }

        public string GetCnx2()
        {
            string strgCnx = ConfigurationManager.ConnectionStrings["MYSQL"].ConnectionString;

            if (object.ReferenceEquals(strgCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strgCnx;
            }
        }
    }
}
