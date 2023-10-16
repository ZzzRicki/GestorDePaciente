using Application.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicioPrueba
    {

        PruebaRepositorio prueba;
        public ServicioPrueba(SqlConnection connection)
        {
            prueba = new PruebaRepositorio(connection);
        }

        public void Agregar(Prueba item)
        {
            prueba.Agregar(item);
        }

        public void Editar(Prueba item, int id)
        {
            prueba.Editar(item, id);

        }

        public int GetLastID()
        {
            return prueba.GetLastID();
        }

        public void Eliminar(int id)
        {
            prueba.Eliminar(id);

        }

        public Prueba GetByID(int id)
        {
            return prueba.GetPrueba(id);
        }

        public DataTable GetAll()
        {
            return prueba.GetAll();
        }

    }
}
