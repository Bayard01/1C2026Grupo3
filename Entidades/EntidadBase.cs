using System;

namespace PuntoVenta.Entidades
{
  
    /// Entidad base con propiedades comunes a todas las entidades
  
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
