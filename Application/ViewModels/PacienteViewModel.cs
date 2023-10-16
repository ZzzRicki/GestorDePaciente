using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PacienteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes Colocar el nombre")]
        public string Nombre { get; set; }
    }
}
