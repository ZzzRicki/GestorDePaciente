using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PruebaRepositorio
    {

        private SqlConnection _connection;
        public PruebaRepositorio(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Agregar(Prueba item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO pruebas (nombre) VALUES (@nombre)", _connection);
            command.Parameters.AddWithValue("@nombre", item.Nombre);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public int GetLastID()
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("select max(id_prueba) from pruebas", _connection);
            SqlDataReader reader = command.ExecuteReader();

            int id = Convert.ToInt32(reader[0].ToString());

            _connection.Close();
            reader.Close();
            reader.Dispose();
            return id;

        }

        public void Editar(Prueba item, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE pruebas SET nombre = @nombre where id_prueba = @id", _connection);
            command.Parameters.AddWithValue("@nombre", item.Nombre);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void Eliminar(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM pruebas where id_prueba = @id", _connection);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public Prueba GetPrueba(int id)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT nombre FROM pruebas where id_prueba = @id", _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            Prueba prueba;

            if (reader.Read())
            {
                prueba = new Prueba
                {
                    Nombre = reader[0].ToString()
                };

            }
            else
            {
                prueba = new Prueba
                {
                    Nombre = ""
                };
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();

            return prueba;

        }

        public DataTable GetAll()
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT id_prueba as 'ID', nombre FROM pruebas", _connection);

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
