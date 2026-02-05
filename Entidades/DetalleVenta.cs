
// SalesMasterPro.Entities/SaleDetail.cs

namespace PuntoVenta.Entidades
{

    /// Representa el detalle de una venta

    public class DetalleVenta : EntidadBase
    {
        public int Idventa { get; set; }
        public virtual Venta Venta { get; set; }
        public int IdProducto { get; set; }
        public virtual Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}