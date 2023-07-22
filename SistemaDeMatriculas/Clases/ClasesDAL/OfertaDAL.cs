using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class OfertaDAL
    {
        private readonly Cconexion conexion;

        public OfertaDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        // Método para agregar una nueva oferta a la base de datos
        public bool AgregarOferta(Oferta oferta)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Ofertas (CodigoOferta, Nombre, FechaInicio, FechaFin) VALUES (@CodigoOferta, @Nombre, @FechaInicio, @FechaFin)", connection))
                {
                    command.Parameters.AddWithValue("@CodigoOferta", oferta.CodigoOferta);
                    command.Parameters.AddWithValue("@Nombre", oferta.Nombre);
                    command.Parameters.AddWithValue("@FechaInicio", oferta.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", oferta.FechaFin);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener todas las ofertas de la base de datos
        public List<Oferta> ObtenerTodasLasOfertas()
        {
            List<Oferta> ofertas = new List<Oferta>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoOferta, Nombre, FechaInicio, FechaFin FROM Ofertas", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Oferta oferta = new Oferta
                            {
                                CodigoOferta = reader["CodigoOferta"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                                FechaFin = Convert.ToDateTime(reader["FechaFin"])
                            };

                            ofertas.Add(oferta);
                        }
                    }
                }
            }

            return ofertas;
        }

        // Método para actualizar una oferta existente en la base de datos
        public bool ActualizarOferta(Oferta oferta)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Ofertas SET Nombre = @Nombre, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE CodigoOferta = @CodigoOferta", connection))
                {
                    command.Parameters.AddWithValue("@CodigoOferta", oferta.CodigoOferta);
                    command.Parameters.AddWithValue("@Nombre", oferta.Nombre);
                    command.Parameters.AddWithValue("@FechaInicio", oferta.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", oferta.FechaFin);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar una oferta de la base de datos
        public bool EliminarOferta(string codigoOferta)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Ofertas WHERE CodigoOferta = @CodigoOferta", connection))
                {
                    command.Parameters.AddWithValue("@CodigoOferta", codigoOferta);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener una oferta por su código
        public Oferta ObtenerOfertaPorCodigo(string codigoOferta)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CodigoOferta, Nombre, FechaInicio, FechaFin FROM Ofertas WHERE CodigoOferta = @CodigoOferta", connection))
                {
                    command.Parameters.AddWithValue("@CodigoOferta", codigoOferta);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Oferta oferta = new Oferta
                            {
                                CodigoOferta = reader["CodigoOferta"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                                FechaFin = Convert.ToDateTime(reader["FechaFin"])
                            };

                            return oferta;
                        }
                        else
                        {
                            return null; // No se encontró la oferta con el código dado
                        }
                    }
                }
            }
        }
    }
}
