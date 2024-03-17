using ENVIO_FE.Data;
using ENVIO_FE.Domain;
using ENVIO_FE.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENVIO_FE
{
    public partial class FrmEnviando : Form
    {
        ConsultaClienteBL v_consulta = new ConsultaClienteBL();
        FacturaDAO obj = new FacturaDAO();
        ConsultaParametrosENT parametros = new ConsultaParametrosENT();

        string dniruc;
        public FrmEnviando()
        {
            InitializeComponent();
            parametros = obj.ConsultarUltimaFactura();
            envioFE();
        }

        private void envioFE()
        {
            //lista para objetos cabecera
            List<Factura_CabeceraENT> list = new List<Factura_CabeceraENT>();
            List<EnvioENT> listconsulta = new List<EnvioENT>();
            Factura_CabeceraENT FACT_CAB = new Factura_CabeceraENT();
            //lista para objetos detalles 
            List<Factura_DetalleENT> list2 = new List<Factura_DetalleENT>();
            Factura_DetalleENT FACT_DET = new Factura_DetalleENT();

            //v_consulta.ConsultarDNIRUC();

            //dynamic respuesta = (v_consulta.ConsultarDNIRUC());

            listconsulta = v_consulta.ConsultarDNIRUC();

            foreach (EnvioENT item in listconsulta)
            {
                dniruc = item.NIF20T;
            }

            list = obj.funcfactura_cabecera(dniruc, parametros);

            foreach (Factura_CabeceraENT item in list)
            {
                obj.InsertarCabecera(item);
            }

            list2 = obj.funcfactura_detalle(dniruc, parametros);

            foreach (Factura_DetalleENT item2 in list2)
            {
                obj.InsertarDetalle(item2);
            }
            obj.EjecucionLink();
            //MessageBox.Show(this.parametros.ToString());

            this.Close();

        }
    }
}
