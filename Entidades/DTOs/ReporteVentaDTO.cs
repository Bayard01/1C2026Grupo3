// SalesMasterPro.Entities/DTOs/ReporteVentaDTO.cs
using System;

namespace PuntoVenta.Entidades.DTOs
{
    
    /// DTO para reportes de ventas
    
    public class ReporteVentaDTO
    {
        public string NumeroVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NombreCliente { get; set; }
        public string NombreCliente { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal GranTotal { get; set; }
    }
}