using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Drawing.Imaging;
using System.Net;
using MySql.Data.MySqlClient; //CONEX CON MYSQL - XAMPP
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using ENVIO_FE.Entidad;

namespace ENVIO_FE.Data
{
    public class FacturaDAO
    {
        int idCabecera;
        public List<Factura_CabeceraENT> funcfactura_cabecera(string DNI_RUC, ConsultaParametrosENT param)
        {
            //Lista para los objetos
            List<Factura_CabeceraENT> List_fact_Cab = new List<Factura_CabeceraENT>();
            //Objeto para los atributos //
            Factura_CabeceraENT cabecera = null;

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
                    cabecera = new Factura_CabeceraENT();
                    //Obtiene los datos de la consulta
                    cabecera.id_doc_electronico = lectura.GetInt32(lectura.GetOrdinal("id_doc_electronico"));
                    cabecera.serieNumero = lectura.GetString(lectura.GetOrdinal("serieNumero"));
                    cabecera.tipoDocumento = lectura.GetInt32(lectura.GetOrdinal("tipoDocumento"));
                    cabecera.fechaEmision = lectura.GetDateTime(lectura.GetOrdinal("fechaEmision"));
                    cabecera.numeroDocIdentidadEmisor = lectura.GetString(lectura.GetOrdinal("numeroDocIdentidadEmisor"));
                    cabecera.tipoDocIdentidadEmisor = lectura.GetInt32(lectura.GetOrdinal("tipoDocIdentidadEmisor"));
                    cabecera.numeroDocIdentidadReceptor = lectura.GetString(lectura.GetOrdinal("numeroDocIdentidadReceptor"));
                    cabecera.razonSocialReceptor = lectura.GetString(lectura.GetOrdinal("razonSocialReceptor"));
                    cabecera.direccionReceptor = lectura.GetString(lectura.GetOrdinal("direccionReceptor"));
                    cabecera.correoReceptor = lectura.GetString(lectura.GetOrdinal("correoReceptor"));
                    cabecera.tipoDocIdentidadReceptor = lectura.GetInt32(lectura.GetOrdinal("tipoDocIdentidadReceptor"));
                    cabecera.telefono = lectura.GetString(lectura.GetOrdinal("telefono"));
                    cabecera.idCliente = lectura.GetInt32(lectura.GetOrdinal("idCliente"));
                    cabecera.totalOPGravadas = lectura.GetDouble(lectura.GetOrdinal("totalOPGravadas"));
                    //cabecera.totalOPExoneradas = lectura.GetDouble(lectura.GetOrdinal("totalOPExoneradas"));
                    cabecera.totalOPExoneradas = lectura.GetString(lectura.GetOrdinal("totalOPExoneradas"));
                    //cabecera.totalOPNoGravadas = lectura.GetDouble(lectura.GetOrdinal("totalOPNoGravadas"));
                    cabecera.totalOPNoGravadas = lectura.GetString(lectura.GetOrdinal("totalOPNoGravadas"));
                    //cabecera.totalOPGratuitas = lectura.GetDouble(lectura.GetOrdinal("totalOPGratuitas"));
                    cabecera.totalOPGratuitas = lectura.GetString(lectura.GetOrdinal("totalOPGratuitas"));
                    cabecera.sumatoriaIGV = lectura.GetDouble(lectura.GetOrdinal("sumatoriaIGV"));
                    //cabecera.sumatoriaISC = lectura.GetDouble(lectura.GetOrdinal("sumatoriaISC"));
                    cabecera.sumatoriaISC = lectura.GetString(lectura.GetOrdinal("sumatoriaISC"));
                    cabecera.importeTotal = lectura.GetDouble(lectura.GetOrdinal("importeTotal"));
                    cabecera.importeTotalVenta = lectura.GetDouble(lectura.GetOrdinal("importeTotalVenta"));
                    cabecera.totalDescuentos = lectura.GetDouble(lectura.GetOrdinal("totalDescuentos"));
                    cabecera.descuentosGlobales = lectura.GetDouble(lectura.GetOrdinal("descuentosGlobales"));
                    //cabecera.sumatoriaOtrosCargos = lectura.GetDouble(lectura.GetOrdinal("sumatoriaOtrosCargos"));
                    cabecera.sumatoriaOtrosCargos = lectura.GetString(lectura.GetOrdinal("sumatoriaOtrosCargos"));
                    //cabecera.porcentajeOtrosCargos = lectura.GetDouble(lectura.GetOrdinal("porcentajeOtrosCargos"));
                    cabecera.porcentajeOtrosCargos = lectura.GetString(lectura.GetOrdinal("porcentajeOtrosCargos"));
                    //cabecera.sumatoriaImpuestoBolsas = lectura.GetDouble(lectura.GetOrdinal("sumatoriaImpuestoBolsas"));
                    cabecera.sumatoriaImpuestoBolsas = lectura.GetString(lectura.GetOrdinal("sumatoriaImpuestoBolsas"));
                    cabecera.tipoMoneda = lectura.GetString(lectura.GetOrdinal("tipoMoneda"));
                    cabecera.codigoPaisReceptor = lectura.GetString(lectura.GetOrdinal("codigoPaisReceptor"));
                    cabecera.codigoTipoOperacion = lectura.GetInt32(lectura.GetOrdinal("codigoTipoOperacion"));
                    cabecera.montoEnLetras = lectura.GetString(lectura.GetOrdinal("montoEnLetras"));
                    cabecera.idPedido = lectura.GetInt32(lectura.GetOrdinal("idPedido"));
                    cabecera.Doc_Estado = lectura.GetString(lectura.GetOrdinal("Doc_Estado"));
                    cabecera.Doc_id_cierre = lectura.GetInt32(lectura.GetOrdinal("Doc_id_cierre"));
                    cabecera.doc_afectado = lectura.GetString(lectura.GetOrdinal("doc_afectado"));
                    cabecera.nro_detraccion = lectura.GetString(lectura.GetOrdinal("nro_detraccion"));
                    cabecera.estado_xml = lectura.GetInt32(lectura.GetOrdinal("estado_xml"));
                    cabecera.enviado_sunat = lectura.GetInt32(lectura.GetOrdinal("enviado_sunat"));
                    cabecera.xml_doc = lectura.GetString(lectura.GetOrdinal("xml_doc"));
                    cabecera.dcr_doc = lectura.GetString(lectura.GetOrdinal("dcr_doc"));
                    cabecera.respuesta_sunat = lectura.GetString(lectura.GetOrdinal("respuesta_sunat"));
                    cabecera.aleatorio = lectura.GetInt32(lectura.GetOrdinal("aleatorio"));
                    cabecera.tipodoc_nc = lectura.GetString(lectura.GetOrdinal("tipodoc_nc"));
                    cabecera.d_afect_nc = lectura.GetString(lectura.GetOrdinal("d_afect_nc"));
                    cabecera.idmotivo_nc = lectura.GetInt32(lectura.GetOrdinal("idmotivo_nc"));

                    List_fact_Cab.Add(cabecera);
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

            return List_fact_Cab;
        }
        public void InsertarCabecera(Factura_CabeceraENT cabecera)
        {
            MySqlConnection conex = new MySqlConnection(new ConexionDAO().GetCnx2());
            /*
            string Query = "INSERT INTO sf_doc_electronico (id_doc_electronico, serieNumero, tipoDocumento," +
                "fechaEmision, numeroDocIdentidadEmisor, tipoDocIdentidadEmisor, numeroDocIdentidadReceptor, " +
                "razonSocialReceptor, direccionReceptor, correoReceptor, tipoDocIdentidadReceptor, telefono, " +
                "idCliente, totalOPGravadas, totalOPExoneradas, totalOPNoGravadas, totalOPGratuitas, sumatoriaIGV, " +
                "sumatoriaISC, importeTotal, importeTotalVenta, totalDescuentos, descuentosGlobales, sumatoriaOtrosCargos," +
                " porcentajeOtrosCargos, sumatoriaImpuestoBolsas, tipoMoneda, codigoPaisReceptor, codigoTipoOperacion, " +
                "montoEnLetras, idPedido, Doc_Estado, Doc_id_cierre, doc_afectado, nro_detraccion, estado_xml, enviado_sunat, " +
                "xml_doc, dcr_doc, respuesta_sunat, aleatorio, tipodoc_nc, d_afect_nc, idmotivo_nc)"
            */

            MySqlCommand cmd = new MySqlCommand("InsertarFacturaCabecera", conex);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("_id_doc_electronico", cabecera.id_doc_electronico);
                cmd.Parameters.AddWithValue("_serieNumero", cabecera.serieNumero);
                cmd.Parameters.AddWithValue("_tipoDocumento", cabecera.tipoDocumento);
                cmd.Parameters.AddWithValue("_fechaEmision", cabecera.fechaEmision);
                cmd.Parameters.AddWithValue("_numeroDocIdentidadEmisor", cabecera.numeroDocIdentidadEmisor);
                cmd.Parameters.AddWithValue("_tipoDocIdentidadEmisor", cabecera.tipoDocIdentidadEmisor);
                cmd.Parameters.AddWithValue("_numeroDocIdentidadReceptor", cabecera.numeroDocIdentidadReceptor);
                cmd.Parameters.AddWithValue("_razonSocialReceptor", cabecera.razonSocialReceptor);
                cmd.Parameters.AddWithValue("_direccionReceptor", cabecera.direccionReceptor);
                cmd.Parameters.AddWithValue("_correoReceptor", cabecera.correoReceptor);
                cmd.Parameters.AddWithValue("_tipoDocIdentidadReceptor", cabecera.tipoDocIdentidadReceptor);
                cmd.Parameters.AddWithValue("_telefono", cabecera.telefono);
                cmd.Parameters.AddWithValue("_idCliente", cabecera.idCliente);
                cmd.Parameters.AddWithValue("_totalOPGravadas", cabecera.totalOPGravadas);
                cmd.Parameters.AddWithValue("_totalOPExoneradas", cabecera.totalOPExoneradas);
                cmd.Parameters.AddWithValue("_totalOPNoGravadas", cabecera.totalOPNoGravadas);
                cmd.Parameters.AddWithValue("_totalOPGratuitas", cabecera.totalOPGratuitas);
                cmd.Parameters.AddWithValue("_sumatoriaIGV", cabecera.sumatoriaIGV);
                cmd.Parameters.AddWithValue("_sumatoriaISC", cabecera.sumatoriaISC);
                cmd.Parameters.AddWithValue("_importeTotal", cabecera.importeTotal);
                cmd.Parameters.AddWithValue("_importeTotalVenta", cabecera.importeTotalVenta);
                cmd.Parameters.AddWithValue("_totalDescuentos", cabecera.totalDescuentos);
                cmd.Parameters.AddWithValue("_descuentosGlobales", cabecera.descuentosGlobales);
                cmd.Parameters.AddWithValue("_sumatoriaOtrosCargos", cabecera.sumatoriaOtrosCargos);
                cmd.Parameters.AddWithValue("_porcentajeOtrosCargos", cabecera.porcentajeOtrosCargos);
                cmd.Parameters.AddWithValue("_sumatoriaImpuestoBolsas", cabecera.sumatoriaImpuestoBolsas);
                cmd.Parameters.AddWithValue("_tipoMoneda", cabecera.tipoMoneda);
                cmd.Parameters.AddWithValue("_codigoPaisReceptor", cabecera.codigoPaisReceptor);
                cmd.Parameters.AddWithValue("_codigoTipoOperacion", cabecera.codigoTipoOperacion);
                cmd.Parameters.AddWithValue("_montoEnLetras", cabecera.montoEnLetras);
                cmd.Parameters.AddWithValue("_idPedido", cabecera.idPedido);
                cmd.Parameters.AddWithValue("_Doc_Estado", cabecera.Doc_Estado);
                cmd.Parameters.AddWithValue("_Doc_id_cierre", cabecera.Doc_id_cierre);
                cmd.Parameters.AddWithValue("_doc_afectado", cabecera.doc_afectado);
                cmd.Parameters.AddWithValue("_nro_detraccion", cabecera.nro_detraccion);
                cmd.Parameters.AddWithValue("_estado_xml", cabecera.estado_xml);
                cmd.Parameters.AddWithValue("_enviado_sunat", cabecera.enviado_sunat);
                cmd.Parameters.AddWithValue("_xml_doc", cabecera.xml_doc);
                cmd.Parameters.AddWithValue("_dcr_doc", cabecera.dcr_doc);
                cmd.Parameters.AddWithValue("_respuesta_sunat", cabecera.respuesta_sunat);
                cmd.Parameters.AddWithValue("_aleatorio", cabecera.aleatorio);
                cmd.Parameters.AddWithValue("_tipodoc_nc", cabecera.tipodoc_nc);
                cmd.Parameters.AddWithValue("_d_afect_nc", cabecera.d_afect_nc);
                cmd.Parameters.AddWithValue("_idmotivo_nc", cabecera.idmotivo_nc);

                conex.Open();
                int row = cmd.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                cmd.Parameters.Clear();
            }

        }
        public List<Factura_DetalleENT> funcfactura_detalle(string DNI_RUC, ConsultaParametrosENT param)
        {
            //Lista para los objetos 
            List<Factura_DetalleENT> List_fact_Det = new List<Factura_DetalleENT>();
            //los objetos para los atributos
            Factura_DetalleENT detalle = null;

            //conexion
            SqlConnection conex = new SqlConnection(new ConexionDAO().GetCnx());
            SqlCommand cmd = new SqlCommand("SP_FACTURASDETALLE", conex);
            cmd.CommandType = CommandType.StoredProcedure;
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
                    detalle = new Factura_DetalleENT();

                    detalle.id_doc_electronico = lectura.GetInt32(lectura.GetOrdinal("id_doc_electronico"));
                    detalle.serieNumero = lectura.GetString(lectura.GetOrdinal("serieNumero"));
                    detalle.numeroDocIdentidadEmisor = "20603227159";//lectura.GetString(lectura.GetOrdinal("numeroDocIdentidadEmisor")); //nh
                    detalle.ordenItem = lectura.GetInt32(lectura.GetOrdinal("ordenItem"));
                    detalle.codigoProductoItem = lectura.GetInt32(lectura.GetOrdinal("codigoProductoItem"));
                    detalle.descripcionItem = lectura.GetString(lectura.GetOrdinal("descripcionItem"));
                    detalle.unidadMedidaItem = "NIU";//lectura.GetString(lectura.GetOrdinal("unidadMedidaItem"));//nh
                    detalle.cantidadItem = lectura.GetDouble(lectura.GetOrdinal("cantidadItem"));
                    detalle.valorUnitarioSinIgv = lectura.GetDouble(lectura.GetOrdinal("valorUnitarioSinIgv"));
                    detalle.precioUnitarioConIgv = lectura.GetDouble(lectura.GetOrdinal("precioUnitarioConIgv"));
                    detalle.codTipoPrecioVtaUnitarioItem = 1; //lectura.GetInt32(lectura.GetOrdinal("codTipoPrecioVtaUnitarioItem"));//nh
                    detalle.importeIGVItem = lectura.GetDouble(lectura.GetOrdinal("importeIGVItem"));
                    detalle.codigoAfectacionIGVItem = 10; // lectura.GetInt32(lectura.GetOrdinal("codigoAfectacionIGVItem"));//nh
                    detalle.descuentoItem = lectura.GetDouble(lectura.GetOrdinal("descuentoItem"));
                    detalle.valorVentaItem = lectura.GetDouble(lectura.GetOrdinal("valorVentaItem"));
                    detalle._descuentoItem = 0; // lectura.GetDouble(lectura.GetOrdinal("_descuentoItem"));//nh
                    detalle._precioUnitario = lectura.GetDouble(lectura.GetOrdinal("_precioUnitario"));
                    detalle._valorVentaSinIGV = lectura.GetDouble(lectura.GetOrdinal("_valorVentaSinIGV"));
                    detalle.montoReferenciaItem = 0; // lectura.GetDouble(lectura.GetOrdinal("montoReferenciaItem"));//nh
                    detalle.montoReferencialUnitarioItem = 0; // lectura.GetDouble(lectura.GetOrdinal("montoReferencialUnitarioItem")); //nh
                    detalle.clasificacionProductoItem = 0; // lectura.GetInt32(lectura.GetOrdinal("clasificacionProductoItem"));//nh
                    detalle.montoTotalItem = lectura.GetDouble(lectura.GetOrdinal("montoTotalItem"));
                    detalle.cantidadBolsasItem = 0; // lectura.GetInt32(lectura.GetOrdinal("cantidadBolsasItem")); //nh
                    detalle.montoUnitarioBolsasItem = 0; // lectura.GetDouble(lectura.GetOrdinal("montoUnitarioBolsasItem")); //nh
                    detalle.importeBolsasItem = 0; // lectura.GetDouble(lectura.GetOrdinal("importeBolsasItem")); //nh
                    detalle.iddetpedido = 0; // lectura.GetInt32(lectura.GetOrdinal("iddetpedido")); //nh
                    detalle.opGratuitas = 0; // lectura.GetDecimal(lectura.GetOrdinal("opGratuitas")); //nh
                    detalle.opExoneradas = 0; // lectura.GetDecimal(lectura.GetOrdinal("opExoneradas")); //nh
                    detalle.ISC = 0; // lectura.GetDecimal(lectura.GetOrdinal("ISC")); //nh

                    List_fact_Det.Add(detalle);
                }

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                cmd.Parameters.Clear();
            }
            return List_fact_Det;
        }
        public void InsertarDetalle(Factura_DetalleENT detalle)
        {

            MySqlConnection conex = new MySqlConnection(new ConexionDAO().GetCnx2());
            ;
            // -----------CAPTUTA DEL ID DE CABECERA DE LA BASE REMOTA ----------
            string query = "SELECT id FROM sf_doc_electronico ORDER BY id DESC LIMIT 1";
            MySqlCommand cmd2 = new MySqlCommand(query, conex);
            try
            {
                conex.Open();
                MySqlDataReader lectura = cmd2.ExecuteReader();

                while (lectura.Read())
                {
                    idCabecera = lectura.GetInt32(lectura.GetOrdinal("id"));
                }
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }

            }



            // INSERCCION DEL DETALLE A LA BASE REMOTA
            MySqlCommand cmd = new MySqlCommand("InsertarFacturaDetalle", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                cmd.Parameters.AddWithValue("_id_doc_electronico", idCabecera);
                cmd.Parameters.AddWithValue("_serieNumero", detalle.serieNumero);
                cmd.Parameters.AddWithValue("_numeroDocIdentidadEmisor", detalle.numeroDocIdentidadEmisor);  //de la empresa
                cmd.Parameters.AddWithValue("_ordenItem", detalle.ordenItem);
                cmd.Parameters.AddWithValue("_codigoProductoItem", detalle.codigoProductoItem);
                cmd.Parameters.AddWithValue("_descripcionItem", detalle.descripcionItem);
                cmd.Parameters.AddWithValue("_unidadMedidaItem", detalle.unidadMedidaItem);
                cmd.Parameters.AddWithValue("_cantidadItem", detalle.cantidadItem);
                cmd.Parameters.AddWithValue("_valorUnitarioSinIgv", detalle.valorUnitarioSinIgv);
                cmd.Parameters.AddWithValue("_precioUnitarioConIgv", detalle.precioUnitarioConIgv);
                cmd.Parameters.AddWithValue("_codTipoPrecioVtaUnitarioItem", detalle.codTipoPrecioVtaUnitarioItem);
                cmd.Parameters.AddWithValue("_importeIGVItem", detalle.importeIGVItem);
                cmd.Parameters.AddWithValue("_codigoAfectacionIGVItem", detalle.codigoAfectacionIGVItem);
                cmd.Parameters.AddWithValue("_descuentoItem", detalle.descuentoItem);
                cmd.Parameters.AddWithValue("_valorVentaItem", detalle.valorVentaItem);
                cmd.Parameters.AddWithValue("D_descuentoItem", detalle._descuentoItem);
                cmd.Parameters.AddWithValue("D_precioUnitario", detalle._precioUnitario);
                cmd.Parameters.AddWithValue("D_valorVentaSinIGV", detalle._valorVentaSinIGV);
                cmd.Parameters.AddWithValue("_montoReferenciaItem", detalle.montoReferenciaItem);
                cmd.Parameters.AddWithValue("_montoReferencialUnitarioItem", detalle.montoReferencialUnitarioItem);
                cmd.Parameters.AddWithValue("_clasificacionProductoItem", detalle.clasificacionProductoItem);
                cmd.Parameters.AddWithValue("_montoTotalItem", detalle.montoTotalItem);
                cmd.Parameters.AddWithValue("_cantidadBolsasItem", detalle.cantidadBolsasItem);
                cmd.Parameters.AddWithValue("_montoUnitarioBolsasItem", detalle.montoUnitarioBolsasItem);
                cmd.Parameters.AddWithValue("_importeBolsasItem", detalle.importeBolsasItem);
                cmd.Parameters.AddWithValue("_iddetpedido", detalle.iddetpedido);
                cmd.Parameters.AddWithValue("_opGratuitas", detalle.opGratuitas);
                cmd.Parameters.AddWithValue("_opExoneradas", detalle.opExoneradas);
                cmd.Parameters.AddWithValue("_ISC", detalle.ISC);

                conex.Open();
                int row = cmd.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                cmd.Parameters.Clear();
            }
        }
        public ConsultaParametrosENT ConsultarUltimaFactura()
        {
            ConsultaParametrosENT parametros = new ConsultaParametrosENT();

            SqlConnection conex = new SqlConnection(new ConexionDAO().GetCnx());

            string query = " select TOP 1 NUMALBARAN, NUMSERIE, NUMFAC, NUMSERIEFAC from ALBVENTACAB ORDER BY NUMALBARAN DESC";
            SqlCommand cmd = new SqlCommand(query, conex);
            try
            {
                conex.Open();
                SqlDataReader lectura = cmd.ExecuteReader();

                while (lectura.Read())
                {
                    parametros.NUMALBARAN = (int)lectura[0];
                    parametros.NUMSERIE = (string)lectura[1];
                    parametros.NUMFAC = (int)lectura[2];
                    parametros.NUMSERIEFAC = (string)lectura[3];
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conex.State == ConnectionState.Open)
                {
                    conex.Close();
                }
                cmd.Parameters.Clear();
            }

            return parametros;
        }




        public void EjecucionLink()
        {
            System.Diagnostics.Process.Start("http://localhost:9000/facturador/app_add/cron_gen_xml_boleta.php");

            System.Threading.Thread.Sleep(8000);

            System.Diagnostics.Process.Start("http://localhost:9000/facturador/app_add/cron_envio_boleta_2.php");

        }

    }
}
