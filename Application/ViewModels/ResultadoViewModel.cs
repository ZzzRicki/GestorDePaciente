using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ResultadosViewModel
    {
        public int IdResultado { get; set; }
        public string CedulaPaciente { get; set; }
        [Required(ErrorMessage = "Debes Colocar la cedula")]

        public int IdPrueba { get; set; }
        public string Estado { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]

        public int IdCita { get; set; }
        public string Resultado { get; set; }

    }

}

