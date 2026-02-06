using System.ComponentModel.DataAnnotations;

namespace PuntoVenta.Entidades
{
    
    /// Representa un producto en el sistema de ventas
    
    public class Producto : EntidadBase
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El código debe tener entre 3 y 20 caracteres")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        [Required]
        public string Category { get; set; } = "General";

        public Producto()
        {
            Code = GeneraCodigoProducto();
        }

        private string GeneraCodigoProducto()
        {
            return $"PROD-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";
        }

        public void ActualizaStock(int quantity)
        {
            if (Stock + quantity < 0)
                throw new InvalidOperationException("Stock insuficiente");

            Stock += quantity;
        }
    }
}
