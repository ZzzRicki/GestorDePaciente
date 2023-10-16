using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ResultadoRepositorio
    {
        private SqlConnection _connection;

        public ResultadoRepositorio(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Agregar(Resultados item)
        {
            SqlCommand command = new SqlCommand("INSERT INTO resultados (cedula_paciente, id_prueba, estado, id_cita) VALUES (@CedulaPaciente, @idPrueba, @estado, @idCita)", _connection);
            command.Parameters.AddWithValue("@CedulaPaciente", item.CedulaPaciente);
            command.Parameters.AddWithValue("@idPrueba", item.IdPrueba);
            command.Parameters.AddWithValue("@estado", item.Estado);
            command.Parameters.AddWithValue("@idCita", item.IdCita);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void CerrarResultado(string resultado, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE resultados SET resultado = @resultado where id_resultado = @id", _connection);
            command.Parameters.AddWithValue("@resultado", resultado);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public void ActualizaEstado(string estado, int id)
        {
            SqlCommand command = new SqlCommand("UPDATE resultados SET estado = @estado where id_resultado = @id", _connection);
            command.Parameters.AddWithValue("@estado", estado);
            command.Parameters.AddWithValue("@id", id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

        }

        public DataTable GetAll()
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT r.id_resultado as 'ID', concat(p.nombre,' ',p.apellido) as 'Paciente'," +
                " p.cedula, pr.nombre as 'Prueba', r.estado, case " +
                "when r.estado = 'P' then 'Pendiente' when r.estado = 'C' then 'Completado' end as 'estado' " +
                "FROM resultados r INNER JOIN pacientes p on(r.cedula_paciente = p.cedula) " +
                "INNER JOIN pruebas pr on (r.id_prueba = pr.id_prueba) WHERE r.estado = 'P'", _connection);

            return LoadData(command);
        }

        public int GetByCedula(string cedula)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("SELECT id_resultado FROM resultados where cedula_paciente = @cedula", _connection);
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

        public DataTable GetSearch(string cedula)
        {
            SqlDataAdapter command = new SqlDataAdapter("SELECT r.id_resultado as 'ID', concat(p.nombre,' ',p.apellido) as 'Paciente'," +
                " p.cedula, pr.nombre as 'Prueba', r.estado, case " +
                "when r.estado = 'P' then 'Pendiente' when r.estado = 'C' then 'Completado' end as 'Estado' " +
                "FROM resultados r INNER JOIN pacientes p on(r.cedula_paciente = p.cedula) " +
                "INNER JOIN pruebas pr on (r.id_prueba = pr.id_prueba) where p.cedula = @cedula", _connection);
            command.SelectCommand.Parameters.AddWithValue("@cedula", cedula);

            return LoadData(command);
        }

        public DataTable GetResultadosCita(int id)
        {
            SqlDataAdapter command = new SqlDataAdapter("select p.nombre as 'Prueba', case " +
                "when r.estado = 'P' then 'Pendiente' when r.estado = 'C' then 'Completado' end as Estado " +
                "from resultados r join pruebas p on (r.id_prueba = p.id_prueba) WHERE r.id_cita = @id", _connection);
            command.SelectCommand.Parameters.AddWithValue("@id", id);

            return LoadData(command);
        }

        public DataTable GetResultadosCompletados(int id)
        {
            SqlDataAdapter command = new SqlDataAdapter("select p.nombre as 'Prueba', r.resultado " +
                "from resultados r join pruebas p on (r.id_prueba = p.id_prueba) WHERE r.id_cita = @id and r.estado = 'C'", _connection);
            command.SelectCommand.Parameters.AddWithValue("@id", id);

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
