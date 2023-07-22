using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class DocenteDAL
    {
        private readonly Cconexion conexion;

        public DocenteDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        // Método para agregar un nuevo docente a la base de datos
        public bool AgregarDocente(Docente docente)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Docentes (CodigoDocente, Nombre, Apellido, CorreoElectronico, FechaContratacion) VALUES (@CodigoDocente, @Nombre, @Apellido, @CorreoElectronico, @FechaContratacion)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoDocente", docente.CodigoDocente);
                    command.Parameters.AddWithValue("@Nombre", docente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", docente.Apellido);
                    command.Parameters.AddWithValue("@CorreoElectronico", docente.CorreoElectronico);
                    command.Parameters.AddWithValue("@FechaContratacion", docente.FechaContratacion);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener todos los docentes de la base de datos
        public List<Docente> ObtenerTodosLosDocentes()
        {
            List<Docente> docentes = new List<Docente>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoDocente, Nombre, Apellido, CorreoElectronico, FechaContratacion FROM Docentes", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Docente docente = new Docente
                            {
                                CodigoDocente = reader["CodigoDocente"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                CorreoElectronico = reader["CorreoElectronico"].ToString(),
                                FechaContratacion = Convert.ToDateTime(reader["FechaContratacion"])
                            };

                            docentes.Add(docente);
                        }
                    }
                }
            }

            return docentes;
        }

        // Método para actualizar un docente existente en la base de datos
        public bool ActualizarDocente(Docente docente)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Docentes SET Nombre = @Nombre, Apellido = @Apellido, CorreoElectronico = @CorreoElectronico, FechaContratacion = @FechaContratacion WHERE CodigoDocente = @CodigoDocente", connection))
                {
                    command.Parameters.AddWithValue("@CodigoDocente", docente.CodigoDocente);
                    command.Parameters.AddWithValue("@Nombre", docente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", docente.Apellido);
                    command.Parameters.AddWithValue("@CorreoElectronico", docente.CorreoElectronico);
                    command.Parameters.AddWithValue("@FechaContratacion", docente.FechaContratacion);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar un docente de la base de datos
        public bool EliminarDocente(string codigoDocente)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Docentes WHERE CodigoDocente = @CodigoDocente", connection))
                {
                    command.Parameters.AddWithValue("@CodigoDocente", codigoDocente);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener un docente por su código
        public Docente ObtenerDocentePorCodigo(string codigoDocente)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoDocente, Nombre, Apellido, CorreoElectronico, FechaContratacion FROM Docentes WHERE CodigoDocente = @CodigoDocente", connection))
                {
                    command.Parameters.AddWithValue("@CodigoDocente", codigoDocente);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Docente docente = new Docente
                            {
                                CodigoDocente = reader["CodigoDocente"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                CorreoElectronico = reader["CorreoElectronico"].ToString(),
                                FechaContratacion = Convert.ToDateTime(reader["FechaContratacion"])
                            };

                            return docente;
                        }
                        else
                        {
                            return null; // No se encontró el docente con el código especificado
                        }
                    }
                }
            }
        }
    }
}
