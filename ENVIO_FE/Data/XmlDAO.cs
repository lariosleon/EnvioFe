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
    public class XmlDAO
    {
        public List<Post_Xml> funcfactura_xml(string DNI_RUC, ConsultaParametrosENT param)
        {
            //Listar lista 
            List<Post_Xml> ListaXml = new List<Post_Xml>();
            IList<Post_Xml> lista = new List<Post_Xml>();
            List<FormaPago_Xml> listaformaPago = new List<FormaPago_Xml>();
            List<company_xml> listacompany = new List<company_xml>();
            List<address_company_xml> listaaddress = new List<address_company_xml>();
            List<Cliente_Xml> listacliente = new List<Cliente_Xml>();
            //Lista para los objetos
            Post_Xml objPostXml = new Post_Xml();

            //Objeto para los atributos //
            Post_Xml cabecera = null;

            //conexion
            SqlConnection conex = new SqlConnection(new ConexionDAO().GetCnx());
            SqlCommand cmd = new SqlCommand("SP_FACTURASCABECERA", conex);
            cmd.CommandType = CommandType.StoredProcedure;

            //envia parametros de entrada
            cmd.Parameters.AddWithValue("NUMALBARAN", param.NUMALBARAN);
            cmd.Parameters.AddWithValue("NUMSERIE", param.NUMSERIE);
            cmd.Parameters.AddWithValue("NUMFAC", param.NUMFAC);
            cmd.Parameters.AddWithValue("NUMSERIEFAC", param.NUMSERIEFAC);
            cmd.Parameters.AddWithValue("RUC_DNI", DNI_RUC);

            try
            {
                conex.Open();
                SqlDataReader lectura = cmd.ExecuteReader();


                while (lectura.Read())
                {
                    objPostXml = new Post_Xml();
                    objPostXml.tipoDoc = lectura.GetString(lectura.GetOrdinal("tipoDocumento"));
                    objPostXml.tipoOperacion = "0101";
                    objPostXml.serie = lectura.GetString(lectura.GetOrdinal("serieNumero"));
                    objPostXml.correlativo = Convert.ToString(param.NUMFAC);
                    objPostXml.fechaemision = lectura.GetDateTime(lectura.GetOrdinal("fechaEmision"));

                    FormaPago_Xml objformapago = new FormaPago_Xml
                    {
                        moneda = lectura.GetString(lectura.GetOrdinal("tipoMoneda")),
                        tipo = lectura.GetString(lectura.GetOrdinal("tipo")),
                    };
                    listaformaPago.Add(objformapago);
                    objPostXml.formaPago = listaformaPago;

                    cabecera.tipoMoneda = lectura.GetString(lectura.GetOrdinal("tipoMoneda"));

                    company_xml objcompany = new company_xml
                    {
                        ruc = lectura.GetInt32(lectura.GetOrdinal("ruc")),
                        razonSocial = lectura.GetString(lectura.GetOrdinal("razonSocial")),
                        nombreComercial = lectura.GetString(lectura.GetOrdinal("nombreComercial")),
                    };
                    listacompany.Add(objcompany);

                    address_company_xml objaddress = new address_company_xml
                    {
                        ubigeo = lectura.GetString(lectura.GetOrdinal("ubigeo")),
                        departamento = lectura.GetString(lectura.GetOrdinal("departamento")),
                        provincia = lectura.GetString(lectura.GetOrdinal("provincia")),
                        distrito = lectura.GetString(lectura.GetOrdinal("distrito")),
                        urbanizacion = lectura.GetString(lectura.GetOrdinal("urbanizacion")),
                        direccion = lectura.GetString(lectura.GetOrdinal("direccion")),
                        codLocal = lectura.GetString(lectura.GetOrdinal("codLocal")),
                    };
                    listaaddress.Add(objaddress);
                    objcompany.address = listaaddress;
                    objPostXml.company = listacompany;

                    Cliente_Xml objcliente = new Cliente_Xml
                    {
                        tipoDoc = lectura.GetString(lectura.GetOrdinal("tipoDoc")),
                        numDoc = lectura.GetString(lectura.GetOrdinal("numDoc")),
                        rznSocial = lectura.GetString(lectura.GetOrdinal("rznSocial")),
                    };
                    listacliente.Add(objcliente);
                    objPostXml.client = listacliente;

                    ListaXml.Add(objPostXml);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                cmd.Parameters.Clear();
            }

            return ListaXml;
        }
    }
}
