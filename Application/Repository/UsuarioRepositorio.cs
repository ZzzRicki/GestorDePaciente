using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class UsuarioRepositorio
    {
        private SqlConnection _connection;
        public int existe;
        public UsuarioRepositorio(SqlConnection connection)
        {
            _connection = connection;
            existe = 0;
        }

        public void Agregar(Usuario item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO usuarios (nombre, apellido, correo, usuario, pass, tipo_usuario) VALUES (@nombre, @apellido, @correo, @usuario, @pass, @tipo_usuario)", _connection);
            command.Parameters.AddWithValue("@nombre", item.Nombre);
            command.Parameters.AddWithValue("@apellido", item.Apellido);
            command.Parameters.AddWithValue("@correo", item.Correo);
            command.Parameters.AddWithValue("@usuario", item.User);
            command.Parameters.AddWithValue("@pass", item.Pass);
            command.Parameters.AddWithValue("@tipo_usuario", item.TipoUsuario);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void Editar(Usuario item, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE usuarios SET nombre = @nombre, apellido = @apellido, correo = @correo, usuario = @usuario, pass = @pass, tipo_usuario = @tipo_usuario where id_usuario = @id", _connection);
            command.Parameters.AddWithValue("@nombre", item.Nombre);
            command.Parameters.AddWithValue("@apellido", item.Apellido);
            command.Parameters.AddWithValue("@correo", item.Correo);
            command.Parameters.AddWithValue("@usuario", item.User);
            command.Parameters.AddWithValue("@pass", item.Pass);
            command.Parameters.AddWithValue("@tipo_usuario", item.TipoUsuario);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void Eliminar(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM usuarios where id_usuario = @id", _connection);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public Usuario GetUsuario(int id)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT nombre, apellido, correo, tipo_usuario, usuario, pass FROM usuarios where id_usuario = @id and tipo_usuario <> 'SA'", _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            Usuario user;

            if (reader.Read())
            {
                user = new Usuario
                {
                    Nombre = reader[0].ToString(),
                    Apellido = reader[1].ToString(),
                    Correo = reader[2].ToString(),
                    TipoUsuario = reader[3].ToString(),
                    User = reader[4].ToString(),
                    Pass = reader[5].ToString()
                };
            }
            else
            {
                user = new Usuario
                {
                    Nombre = "",
                    Apellido = "",
                    Correo = "",
                    TipoUsuario = "",
                    User = "",
                    Pass = ""
                };
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();

            return user;

        }

        public string GetTipoUsuario(string usuario, string pass)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT tipo_usuario FROM usuarios where usuario = @usuario and pass = @pass", _connection);
            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@pass", pass);
            SqlDataReader reader = command.ExecuteReader();

            string TipoUsuario;

            if (reader.Read())
            {
                TipoUsuario = reader[0].ToString();
            }
            else
            {
                TipoUsuario = "";
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();

            return TipoUsuario;
        }

        public DataTable GetAll()
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT id_usuario, nombre, apellido, correo, usuario, pass, case when tipo_usuario = 'A' then 'Administrador' when tipo_usuario = 'M' then 'Medico' when tipo_usuario = 'SA' then 'Super administrador' end as 'Tipo de Usuario' FROM usuarios", _connection);

            return LoadData(command);
        }

        public DataTable LoadData(SqlDataAdapter command)
        {
            try
            {
                DataTable data = new DataTable();

                _connection.Open();
                command.Fill(data);
                _connection.Close();

                return data;
            }
            catch (Exception)
            {

                return null;
            }


        }

        public int ExisteUsuario(string usuario)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("Select id_usuario from usuarios where usuario = @usuario", _connection);
            command.Parameters.AddWithValue("@usuario", usuario);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                existe = reader.GetInt32(0);
            }
            else
            {
                existe = 0;
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();
            return existe;
        }


        public int UsuarioEditar(string usuario, int id)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("Select id_usuario from usuarios where usuario = @usuario and id_usuario <> @id", _connection);
            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                existe = reader.GetInt32(0);
            }
            else
            {
                existe = 0;
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();
            return existe;
        }


        public int Login(string usuario, string pass)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("Select id_usuario from usuarios where usuario = @usuario and pass = @pass", _connection);
            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@pass", pass);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                existe = reader.GetInt32(0);
            }
            else
            {
                existe = 0;
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();
            return existe;
        }

    }
}
