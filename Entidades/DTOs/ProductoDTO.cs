
using System;

namespace PuntoVenta.Entidades.DTOs
{
   
    /// DTO para transferencia de datos de productos
    
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public DateTime CreatedAt { get; set; }

        public static ProductoDTO FromEntity(Product producto)
        {
            return new ProductoDTO
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                Categoria = producto.Categoria,
                CreatedAt = producto.CreatedAt
            };
        }
    }
}

