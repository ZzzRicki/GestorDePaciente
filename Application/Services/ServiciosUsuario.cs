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
    public class ServiciosUsuario
    {
        UsuarioRepositorio usuario;
        public ServiciosUsuario(SqlConnection connection)
        {
            usuario = new UsuarioRepositorio(connection);
        }

        public void Agregar(Usuario item)
        {
            usuario.Agregar(item);
        }

        public void Editar(Usuario item, int id)
        {
            usuario.Editar(item, id);

        }

        public void Eliminar(int id)
        {
            usuario.Eliminar(id);

        }


        public int ExisteUsuario(string user)
        {
            return usuario.ExisteUsuario(user);
        }

        public int UsuarioEditar(string user, int id)
        {
            return usuario.UsuarioEditar(user, id);
        }

        public int Login(string user, string pass)
        {
            return usuario.Login(user, pass);
        }

        public Usuario GetByID(int id)
        {
            return usuario.GetUsuario(id);
        }

        public string GetTipoUsuario(string user, string pass)
        {
            return usuario.GetTipoUsuario(user, pass);
        }

        public DataTable GetAll()
        {
            return usuario.GetAll();
        }
    }
}
