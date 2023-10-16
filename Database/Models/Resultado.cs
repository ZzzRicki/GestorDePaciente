using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Resultados
    {

        public int IdResultado { get; set; }
        public string CedulaPaciente { get; set; }
        public int IdPrueba { get; set; }
        public string Estado { get; set; }
        public int IdCita { get; set; }
        public string Resultado { get; set; }

    }
}
