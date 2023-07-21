using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases.ClasesDAL
{
    public class HorarioDAL
    {
        private readonly Cconexion conexion;

        public HorarioDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        // Método para agregar un nuevo horario a la base de datos
        public bool AgregarHorario(Horario horario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Horarios (CodigoHorario, DiaSemana, HoraInicio, HoraFin) VALUES (@CodigoHorario, @DiaSemana, @HoraInicio, @HoraFin)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoHorario", horario.CodigoHorario);
                    command.Parameters.AddWithValue("@DiaSemana", horario.DiaSemana);
                    command.Parameters.AddWithValue("@HoraInicio", horario.HoraInicio);
                    command.Parameters.AddWithValue("@HoraFin", horario.HoraFin);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener todos los horarios de la base de datos
        public List<Horario> ObtenerTodosLosHorarios()
        {
            List<Horario> horarios = new List<Horario>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoHorario, DiaSemana, HoraInicio, HoraFin FROM Horarios", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Horario horario = new Horario
                            {
                                CodigoHorario = reader["CodigoHorario"].ToString(),
                                DiaSemana = reader["DiaSemana"].ToString(),
                                HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString()),
                                HoraFin = TimeSpan.Parse(reader["HoraFin"].ToString())
                            };

                            horarios.Add(horario);
                        }
                    }
                }
            }

            return horarios;
        }

        // Método para actualizar un horario existente en la base de datos
        public bool ActualizarHorario(Horario horario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Horarios SET DiaSemana = @DiaSemana, HoraInicio = @HoraInicio, HoraFin = @HoraFin WHERE CodigoHorario = @CodigoHorario", connection))
                {
                    command.Parameters.AddWithValue("@CodigoHorario", horario.CodigoHorario);
                    command.Parameters.AddWithValue("@DiaSemana", horario.DiaSemana);
                    command.Parameters.AddWithValue("@HoraInicio", horario.HoraInicio);
                    command.Parameters.AddWithValue("@HoraFin", horario.HoraFin);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar un horario de la base de datos
        public bool EliminarHorario(string codigoHorario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Horarios WHERE CodigoHorario = @CodigoHorario", connection))
                {
                    command.Parameters.AddWithValue("@CodigoHorario", codigoHorario);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener un horario por su código
        public Horario ObtenerHorarioPorCodigo(string codigoHorario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoHorario, DiaSemana, HoraInicio, HoraFin FROM Horarios WHERE CodigoHorario = @CodigoHorario", connection))
                {
                    command.Parameters.AddWithValue("@CodigoHorario", codigoHorario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Horario horario = new Horario
                            {
                                CodigoHorario = reader["CodigoHorario"].ToString(),
                                DiaSemana = reader["DiaSemana"].ToString(),
                                HoraInicio = TimeSpan.Parse(reader["HoraInicio"].ToString()),
                                HoraFin = TimeSpan.Parse(reader["HoraFin"].ToString())
                            };

                            return horario;
                        }
                        else
                        {
                            return null; // No se encontró el horario con el código dado
                        }
                    }
                }
            }
        }
    }
}
