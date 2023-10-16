using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class MedicoRepositorio
    {

        private SqlConnection _connection;
        public MedicoRepositorio(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Agregar(MedicoRepositorio item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO medicos (nombre, apellido, correo, telefono, cedula) VALUES (@nombre, @apellido, @correo, @telefono, @cedula)", _connection);
            command.Parameters.AddWithValue("@nombre", item.Agregar);
            command.Parameters.AddWithValue("@apellido", item.Agregar);
            command.Parameters.AddWithValue("@correo", item.Agregar);
            command.Parameters.AddWithValue("@telefono", item.Agregar);
            command.Parameters.AddWithValue("@cedula", item.Agregar);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public int GetLastID()
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("select top 1 id_medico from medicos order by id_medico desc", _connection);
            SqlDataReader reader = command.ExecuteReader();

            int id;

            if (reader.Read())
            {
                id = Convert.ToInt32(reader[0].ToString());
            }
            else
            {
                id = 0;
            }


            _connection.Close();
            reader.Close();
            reader.Dispose();
            return id;

        }

        public void SavePhoto(int id, string destino)
        {
            SqlCommand command = new SqlCommand("UPDATE medicos SET foto = @foto where id_medico = @id", _connection);
            command.Parameters.AddWithValue("@foto", destino);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Editar(MedicoRepositorio item, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE medicos SET nombre = @nombre, apellido = @apellido, correo = @correo, telefono = @telefono, cedula = @cedula where id_medico = @id", _connection);
            command.Parameters.AddWithValue("@nombre", item.Agregar);
            command.Parameters.AddWithValue("@apellido", item.Agregar);
            command.Parameters.AddWithValue("@correo", item.Agregar);
            command.Parameters.AddWithValue("@telefono", item.Agregar);
            command.Parameters.AddWithValue("@cedula", item.Agregar);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void Eliminar(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM medicos where id_medico = @id", _connection);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public Medi GetMedico(int id)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT nombre, apellido, correo, telefono, cedula, foto FROM medicos where id_medico = @id", _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            Medico medico;

            if (reader.Read())
            {
                medico = new Medico
                {
                    Nombre = reader[0].ToString(),
                    Apellido = reader[1].ToString(),
                    Correo = reader[2].ToString(),
                    Telefono = reader[3].ToString(),
                    Cedula = reader[4].ToString(),
                    Foto = reader[5].ToString(),
                };

            }
            else
            {
                medico = new Medico
                {
                    Nombre = "",
                    Apellido = "",
                    Correo = "",
                    Telefono = "",
                    Cedula = "",
                    Foto = "",
                };
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();

            return medico;

        }

        public int GetByCedula(string cedula)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT id_medico FROM medicos where cedula = @cedula", _connection);
            command.Parameters.AddWithValue("@cedula", cedula);
            SqlDataReader reader = command.ExecuteReader();

            int IdMedico;

            if (reader.Read())
            {

                IdMedico = reader.GetInt32(0);

            }
            else
            {
                IdMedico = 0;

            }

            _connection.Close();
            reader.Close();
            reader.Dispose();

            return IdMedico;

        }

        public DataTable GetSearch(int id)
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT id_medico as 'ID', nombre, apellido, correo, telefono, cedula FROM medicos where id_medico = @id", _connection);
            command.SelectCommand.Parameters.AddWithValue("@id", id);

            return LoadData(command);
        }

        public DataTable GetAll()
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT id_medico as 'ID', nombre, apellido, correo, telefono, cedula FROM medicos", _connection);

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

    }
}
