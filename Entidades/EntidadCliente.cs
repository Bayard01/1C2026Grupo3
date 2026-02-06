
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PuntoVenta.Entidades
{
   
    /// Representa un cliente en el sistema
   
    public class Cliente : EntidadBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Teléfono debe tener 10 dígitos")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Correo { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        public string Direccion { get; set; }

        public string CodigoCliente => $"CLI-{Id.ToString().PadLeft(5, '0')}";

       
        /// Valida los datos del cliente
       
        /// <returns>True si los datos son válidos</returns>
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) return false;
            if (string.IsNullOrWhiteSpace(Telefono)) return false;
            if (string.IsNullOrWhiteSpace(Correo)) return false;

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(Correo);
        }
    }
}
