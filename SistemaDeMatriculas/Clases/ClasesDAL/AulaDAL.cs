using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class AulaDAL
    {
        private readonly Cconexion conexion;

        public AulaDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        // Método para agregar una nueva aula a la base de datos
        public bool AgregarAula(Aula aula)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Aulas (CodigoAula, Nombre, Estado) VALUES (@CodigoAula, @Nombre, @Estado)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoAula", aula.CodigoAula);
                    command.Parameters.AddWithValue("@Nombre", aula.Nombre);
                    command.Parameters.AddWithValue("@Estado", aula.Estado);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener todas las aulas de la base de datos
        public List<Aula> ObtenerTodasLasAulas()
        {
            List<Aula> aulas = new List<Aula>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoAula, Nombre, Estado FROM Aulas", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aula aula = new Aula
                            {
                                CodigoAula = reader["CodigoAula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = reader["Estado"].ToString()
                            };

                            aulas.Add(aula);
                        }
                    }
                }
            }

            return aulas;
        }

        // Método para actualizar una aula existente en la base de datos
        public bool ActualizarAula(Aula aula)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Aulas SET Nombre = @Nombre, Estado = @Estado WHERE CodigoAula = @CodigoAula", connection))
                {
                    command.Parameters.AddWithValue("@CodigoAula", aula.CodigoAula);
                    command.Parameters.AddWithValue("@Nombre", aula.Nombre);
                    command.Parameters.AddWithValue("@Estado", aula.Estado);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar una aula de la base de datos
        public bool EliminarAula(string codigoAula)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Aulas WHERE CodigoAula = @CodigoAula", connection))
                {
                    command.Parameters.AddWithValue("@CodigoAula", codigoAula);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener una aula por su código
        public Aula ObtenerAulaPorCodigo(string codigoAula)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoAula, Nombre, Estado FROM Aulas WHERE CodigoAula = @CodigoAula", connection))
                {
                    command.Parameters.AddWithValue("@CodigoAula", codigoAula);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Aula aula = new Aula
                            {
                                CodigoAula = reader["CodigoAula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Estado = reader["Estado"].ToString()
                            };

                            return aula;
                        }
                        else
                        {
                            return null; // No se encontró el aula con el código dado
                        }
                    }
                }
            }
        }
    }
}
