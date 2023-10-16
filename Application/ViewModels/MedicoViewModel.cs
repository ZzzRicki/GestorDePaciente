using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class MedicoViewModel
    {
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo electrónico válida.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El campo Teléfono debe ser un número de teléfono válido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        public string Cedula { get; set; }

        public string Foto { get; set; }
    }

}
