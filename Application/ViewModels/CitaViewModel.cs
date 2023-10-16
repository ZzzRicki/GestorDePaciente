using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CitaViewModel
    {
        public List<MedicoViewModel> Medico { get; set; }
        public List<PacienteViewModel> Paciente { get; set; }
        public List<ResultadoViewModel> Resultados { get; set; }

    }
}
