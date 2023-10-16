using Application.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiciosPaciente
    {

        PacienteRepositorio paciente;
        public ServiciosPaciente(SqlConnection connection)
        {
            paciente = new PacienteRepositorio(connection);
        }

        public void Agregar(Paciente item)
        {
            paciente.Agregar(item);
        }

        public void Editar(Paciente item, int id)
        {
            paciente.Editar(item, id);

        }

        public void SavePhoto(int id, string destino)
        {
            paciente.SavePhoto(id, destino);
        }

        public int GetLastID()
        {
            return paciente.GetLastID();
        }

        public void Eliminar(int id)
        {
            paciente.Eliminar(id);

        }

        public Paciente GetByID(int id)
        {
            return paciente.GetPaciente(id);
        }

        public int GetByCedula(string cedula)
        {
            return paciente.GetByCedula(cedula);
        }

        public DataTable GetSearch(int id)
        {
            return paciente.GetSearch(id);
        }

        public DataTable GetAll()
        {
            return paciente.GetAll();
        }
    }
}
