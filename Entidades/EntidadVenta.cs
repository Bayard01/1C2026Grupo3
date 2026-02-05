
using System;
using System.Collections.Generic;
using System.Linq;

namespace PuntoVenta.Entidades
{
   
    /// Representa una venta en el sistema
    
    public class Venta : EntidadBase
    {
        public string NumeroVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();
        public decimal MontoTotal => DetalleVentas.Sum(d => d.Subtotal);
        public decimal MontoImpuesto => MontoTotal * 0.13m; // 13% IVA
        public decimal GranTotal => MontoTotal + MontoImpuesto;
        public string Estado { get; set; } = "Completado";

        public Venta()
        {
            NumeroVenta = GenerarNumeroVenta();
            FechaVenta = DateTime.Now;
        }

        private string GenerarNumeroVenta()
        {
            return $"SALE-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        }

        public void AgregarDetalle(Producto producto, int cantidad)
        {
            if (producto.Stock < cantidad)
                throw new InvalidOperationException($"Stock insuficiente para {producto.Name}. Stock disponible: {producto.Stock}");

            var detail = new SaleDetail
            {
                ProductoId = producto.Id,
                Producto = producto,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio,
                Idventa = this.Id
            };

            DetalleVentas.Add(detail);
            producto.UpdateStock(-cantidad);
        }
    }
}
