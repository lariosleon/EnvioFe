using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Entidad
{
    public class Factura_CabeceraENT
    {
        public int? id_doc_electronico { get; set; }
        public string serieNumero { get; set; }
        public int? tipoDocumento { get; set; }
        public DateTime? fechaEmision { get; set; }
        public string numeroDocIdentidadEmisor { get; set; }
        public int? tipoDocIdentidadEmisor { get; set; }
        public string numeroDocIdentidadReceptor { get; set; }
        public string razonSocialReceptor { get; set; }
        public string direccionReceptor { get; set; }
        public string correoReceptor { get; set; }
        public int? tipoDocIdentidadReceptor { get; set; }
        public string telefono { get; set; }
        public int? idCliente { get; set; }
        public double? totalOPGravadas { get; set; }
        //public double? totalOPExoneradas { get; set; }
        public string totalOPExoneradas { get; set; }
        //public double? totalOPNoGravadas { get; set; }
        public string totalOPNoGravadas { get; set; }
        //public double totalOPGratuitas { get; set; }
        public string totalOPGratuitas { get; set; }
        public double? sumatoriaIGV { get; set; }
        //public double? sumatoriaISC { get; set; }
        public string sumatoriaISC { get; set; }
        public double? importeTotal { get; set; }
        public double? importeTotalVenta { get; set; }
        public double? totalDescuentos { get; set; }
        public double? descuentosGlobales { get; set; }
        //public double? sumatoriaOtrosCargos { get; set; }
        public string sumatoriaOtrosCargos { get; set; }
        //public double? porcentajeOtrosCargos { get; set; }
        public string porcentajeOtrosCargos { get; set; }
        //public double? sumatoriaImpuestoBolsas { get; set; }
        public string sumatoriaImpuestoBolsas { get; set; }
        public string tipoMoneda { get; set; }
        public string codigoPaisReceptor { get; set; }
        public int? codigoTipoOperacion { get; set; }
        public string montoEnLetras { get; set; }
        public int? idPedido { get; set; }
        public string Doc_Estado { get; set; }
        public int? Doc_id_cierre { get; set; }
        public string doc_afectado { get; set; }
        public string nro_detraccion { get; set; }
        public int? estado_xml { get; set; }
        public int? enviado_sunat { get; set; }
        public string xml_doc { get; set; } //text
        public string dcr_doc { get; set; } //text
        public string respuesta_sunat { get; set; } //text
        public int? aleatorio { get; set; }
        public string tipodoc_nc { get; set; }
        public string d_afect_nc { get; set; }
        public int? idmotivo_nc { get; set; }
    }
}
