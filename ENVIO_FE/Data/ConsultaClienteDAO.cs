using ENVIO_FE.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Data
{
    public class ConsultaClienteDAO
    {
        public List<EnvioENT> GetBuscarCliente()
        {
            List<EnvioENT> _list = new List<EnvioENT>();
            EnvioENT _obj = null;

            SqlConnection cnx = new SqlConnection(new ConexionDAO().GetCnx());
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_CLIENTE_FE", cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cnx.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _obj = new EnvioENT();
                    _obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    _obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    _obj.NIF20T = Convert.ToString(reader["NIF20T"]);

                    _list.Add(_obj);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cmd.Parameters.Clear();
            }
            return _list;
        }
    }
}
