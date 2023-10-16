using Application.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiciosMedico
    {
        MedicoRepositorio medico;
        public ServiciosMedico(SqlConnection connection)
        {
            medico = new MedicoRepositorio(connection);
        }

        public void Agregar(ServiciosMedico item)
        {
            medico.Agregar(item);
        }

        public void Editar(ServiciosMedico item, int id)
        {
            medico.Editar(item, id);

        }

        public void SavePhoto(int id, string destino)
        {
            medico.SavePhoto(id, destino);
        }

        public int GetLastID()
        {
            return medico.GetLastID();
        }

        public void Eliminar(int id)
        {
            medico.Eliminar(id);

        }

        public ServiciosMedico GetByID(int id)
        {
            return medico.GetMedico(id);
        }

        public int GetByCedula(string cedula)
        {
            return medico.GetByCedula(cedula);
        }

        public DataTable GetSearch(int id)
        {
            return medico.GetSearch(id);
        }

        public DataTable GetAll()
        {
            return medico.GetAll();
        }
    }
}
