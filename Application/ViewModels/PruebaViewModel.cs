using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PruebaViewModel
    {
        public int IdPrueba { get; set; }

        [Required(ErrorMessage = "El campo Nombre de la Prueba es obligatorio.")]
        public string Nombre { get; set; }

    }

}
