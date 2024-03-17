using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENVIO_FE.Entidad
{
    public class Factura_DetalleENT
    {
        public int id_doc_electronico { get; set; }
        public string serieNumero { get; set; }
        public string numeroDocIdentidadEmisor { get; set; }
        public int ordenItem { get; set; }
        public int codigoProductoItem { get; set; }
        public string descripcionItem { get; set; }
        public string unidadMedidaItem { get; set; }
        public double cantidadItem { get; set; }
        public double valorUnitarioSinIgv { get; set; }
        public double precioUnitarioConIgv { get; set; }
        public int codTipoPrecioVtaUnitarioItem { get; set; }
        public double importeIGVItem { get; set; }
        public int codigoAfectacionIGVItem { get; set; }
        public double descuentoItem { get; set; }
        public double valorVentaItem { get; set; }
        public double _descuentoItem { get; set; }
        public double _precioUnitario { get; set; }
        public double _valorVentaSinIGV { get; set; }
        public double montoReferenciaItem { get; set; }
        public double montoReferencialUnitarioItem { get; set; }
        public int clasificacionProductoItem { get; set; }
        public double montoTotalItem { get; set; }
        public int cantidadBolsasItem { get; set; }
        public double montoUnitarioBolsasItem { get; set; }
        public double importeBolsasItem { get; set; }
        public int iddetpedido { get; set; }
        public decimal opGratuitas { get; set; }
        public decimal opExoneradas { get; set; }
        public decimal ISC { get; set; }
    }
}
