using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class EstudianteDAL
    {
        private readonly Cconexion conexion;

        public EstudianteDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        // Método para agregar un nuevo estudiante a la base de datos
        public bool AgregarEstudiante(Estudiante estudiante)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Estudiantes (CodigoEstudiante, Nombre, Apellido, FechaNacimiento, CorreoElectronico) VALUES (@CodigoEstudiante, @Nombre, @Apellido, @FechaNacimiento, @CorreoElectronico)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoEstudiante", estudiante.CodigoEstudiante);
                    command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    command.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                    command.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                    command.Parameters.AddWithValue("@CorreoElectronico", estudiante.CorreoElectronico);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener todos los estudiantes de la base de datos
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoEstudiante, Nombre, Apellido, FechaNacimiento, CorreoElectronico FROM Estudiantes", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estudiante estudiante = new Estudiante
                            {
                                CodigoEstudiante = reader["CodigoEstudiante"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                CorreoElectronico = reader["CorreoElectronico"].ToString()
                            };

                            estudiantes.Add(estudiante);
                        }
                    }
                }
            }

            return estudiantes;
        }

        // Método para actualizar un estudiante existente en la base de datos
        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Estudiantes SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, CorreoElectronico = @CorreoElectronico WHERE CodigoEstudiante = @CodigoEstudiante", connection))
                {
                    command.Parameters.AddWithValue("@CodigoEstudiante", estudiante.CodigoEstudiante);
                    command.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                    command.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                    command.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                    command.Parameters.AddWithValue("@CorreoElectronico", estudiante.CorreoElectronico);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar un estudiante de la base de datos
        public bool EliminarEstudiante(string codigoEstudiante)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Estudiantes WHERE CodigoEstudiante = @CodigoEstudiante", connection))
                {
                    command.Parameters.AddWithValue("@CodigoEstudiante", codigoEstudiante);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener un estudiante por su código
        public Estudiante ObtenerEstudiantePorCodigo(string codigoEstudiante)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoEstudiante, Nombre, Apellido, FechaNacimiento, CorreoElectronico FROM Estudiantes WHERE CodigoEstudiante = @CodigoEstudiante", connection))
                {
                    command.Parameters.AddWithValue("@CodigoEstudiante", codigoEstudiante);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Estudiante estudiante = new Estudiante
                            {
                                CodigoEstudiante = reader["CodigoEstudiante"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                CorreoElectronico = reader["CorreoElectronico"].ToString()
                            };

                            return estudiante;
                        }
                        else
                        {
                            return null; // No se encontró el estudiante con el código especificado
                        }
                    }
                }
            }
        }
    }
}
