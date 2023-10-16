using Application.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicioResultado
    {
        ResultadoRepositorio resultado;
        public ServicioResultado(SqlConnection connection)
        {
            resultado = new ResultadoRepositorio(connection);
        }

        public void Agregar(Resultados item)
        {
            resultado.Agregar(item);
        }

        public void ActualizaEstado(string estado, int id)
        {
            resultado.ActualizaEstado(estado, id);
        }

        public DataTable GetAll()
        {
            return resultado.GetAll();
        }

        public DataTable GetResultadosCita(int id)
        {
            return resultado.GetResultadosCita(id);
        }

        public DataTable GetResultadosCompletados(int id)
        {
            return resultado.GetResultadosCompletados(id);
        }

        public int GetByCedula(string cedula)
        {
            return resultado.GetByCedula(cedula);
        }

        public DataTable GetSearch(string cedula)
        {
            return resultado.GetSearch(cedula);
        }


        public void CerrarResultado(string result, int id)
        {
            resultado.CerrarResultado(result, id);
        }
    }
}
