using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PacienteRepositorio
    {

        private SqlConnection _connection;
        public PacienteRepositorio(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Agregar(Paciente item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO pacientes (nombre, apellido, telefono, direccion, cedula, fecha_nac, fumador, alergias) VALUES (@nombre, @apellido, @telefono, @direccion, @cedula, @fecha_nac, @fumador, @alergias)", _connection);
            command.Parameters.AddWithValue("@nombre", item.Nombre);
            command.Parameters.AddWithValue("@apellido", item.Apellido);
            command.Parameters.AddWithValue("@telefono", item.Telefono);
            command.Parameters.AddWithValue("@direccion", item.Direccion);
            command.Parameters.AddWithValue("@cedula", item.Cedula);
            command.Parameters.AddWithValue("@fecha_nac", item.FechaNac);
            command.Parameters.AddWithValue("@fumador", item.Fumador);
            command.Parameters.AddWithValue("@alergias", item.Alergias);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public int GetLastID()
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("select max(id_paciente) from pacientes", _connection);
            SqlDataReader reader = command.ExecuteReader();

            int id;

            if (reader.Read())
            {
                id = reader.GetInt32(0);
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
            SqlCommand command = new SqlCommand("UPDATE pacientes SET foto = @foto where id_paciente = @id", _connection);
            command.Parameters.AddWithValue("@foto", destino);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Editar(Paciente item, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE pacientes SET nombre = @nombre, apellido = @apellido, telefono = @telefono, direccion = @direccion, cedula = @cedula, fecha_nac = @fecha_nac, fumador = @fumador, alergias = @alergias where id_paciente = @id", _connection);
            command.Parameters.AddWithValue("@nombre", item.Nombre);
            command.Parameters.AddWithValue("@apellido", item.Apellido);
            command.Parameters.AddWithValue("@telefono", item.Telefono);
            command.Parameters.AddWithValue("@direccion", item.Direccion);
            command.Parameters.AddWithValue("@cedula", item.Cedula);
            command.Parameters.AddWithValue("@fecha_nac", item.FechaNac);
            command.Parameters.AddWithValue("@fumador", item.Fumador);
            command.Parameters.AddWithValue("@alergias", item.Alergias);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void Eliminar(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM pacientes where id_paciente = @id", _connection);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public Paciente GetPaciente(int id)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT nombre, apellido, telefono, direccion, cedula, fecha_nac, fumador, alergias, foto FROM pacientes where id_paciente = @id", _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            Paciente paciente;

            if (reader.Read())
            {
                paciente = new Paciente
                {
                    Nombre = reader[0].ToString(),
                    Apellido = reader[1].ToString(),
                    Telefono = reader[2].ToString(),
                    Direccion = reader[3].ToString(),
                    Cedula = reader[4].ToString(),
                    FechaNac = reader[5].ToString(),
                    Fumador = Convert.ToInt32(reader[6].ToString()),
                    Alergias = Convert.ToInt32(reader[7].ToString()),
                    Foto = reader[8].ToString()
                };

            }
            else
            {
                paciente = new Paciente
                {
                    Nombre = "",
                    Apellido = "",
                    Telefono = "",
                    Direccion = "",
                    Cedula = "",
                    FechaNac = "",
                    Fumador = 0,
                    Alergias = 0,
                };
            }

            _connection.Close();
            reader.Close();
            reader.Dispose();

            return paciente;

        }

        public int GetByCedula(string cedula)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT id_paciente FROM pacientes where cedula = @cedula", _connection);
            command.Parameters.AddWithValue("@cedula", cedula);
            SqlDataReader reader = command.ExecuteReader();

            int IdPaciente;

            if (reader.Read())
            {

                IdPaciente = reader.GetInt32(0);

            }
            else
            {
                IdPaciente = 0;

            }

            _connection.Close();
            reader.Close();
            reader.Dispose();

            return IdPaciente;

        }

        public DataTable GetSearch(int id)
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT id_paciente as 'ID', nombre, apellido, telefono, direccion, cedula, fecha_nac, case when fumador  = 1 then 'Si' else 'No'end as 'fumador', case when alergias  = 1 then 'Si' else 'No' end as 'alergias' FROM pacientes where id_paciente = @id", _connection);
            command.SelectCommand.Parameters.AddWithValue("@id", id);

            return LoadData(command);
        }

        public DataTable GetAll()
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT id_paciente as 'ID', nombre, apellido, telefono, direccion, cedula, fecha_nac, case when fumador  = 1 then 'Si' else 'No'end as 'fumador', case when alergias  = 1 then 'Si' else 'No' end as 'alergias' FROM pacientes", _connection);

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
