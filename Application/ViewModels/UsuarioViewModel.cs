using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo electrónico válida.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        public string User { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Usuario es obligatorio.")]
        public string TipoUsuario { get; set; }
    }
}
