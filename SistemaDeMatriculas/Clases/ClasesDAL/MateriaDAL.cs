using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class MateriaDAL
    {
        private readonly Cconexion conexion;

        public MateriaDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        // Método para agregar una nueva materia a la base de datos
        public bool AgregarMateria(Materia materia)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Materias (Codigo, Nombre, Creditos) VALUES (@Codigo, @Nombre, @Creditos)", connection))
                {
                    command.Parameters.AddWithValue("@Codigo", materia.Codigo);
                    command.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    command.Parameters.AddWithValue("@Creditos", materia.Creditos);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener todas las materias de la base de datos
        public List<Materia> ObtenerTodasLasMaterias()
        {
            List<Materia> materias = new List<Materia>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT Codigo, Nombre, Creditos FROM Materias", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Materia materia = new Materia
                            {
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Creditos = Convert.ToInt32(reader["Creditos"])
                            };

                            materias.Add(materia);
                        }
                    }
                }
            }

            return materias;
        }

        // Método para actualizar una materia existente en la base de datos
        public bool ActualizarMateria(Materia materia)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Materias SET Nombre = @Nombre, Creditos = @Creditos WHERE Codigo = @Codigo", connection))
                {
                    command.Parameters.AddWithValue("@Codigo", materia.Codigo);
                    command.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    command.Parameters.AddWithValue("@Creditos", materia.Creditos);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar una materia de la base de datos
        public bool EliminarMateria(string codigoMateria)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Materias WHERE Codigo = @Codigo", connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigoMateria);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener una materia por su código
        public Materia ObtenerMateriaPorCodigo(string codigoMateria)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT Codigo, Nombre, Creditos FROM Materias WHERE Codigo = @Codigo", connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigoMateria);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Materia materia = new Materia
                            {
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Creditos = Convert.ToInt32(reader["Creditos"])
                            };

                            return materia;
                        }
                        else
                        {
                            return null; // No se encontró la materia con el código especificado
                        }
                    }
                }
            }
        }

        // Método para obtener una materia por su nombre
        public Materia ObtenerMateriaPorNombre(string nombreMateria)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT Codigo, Nombre, Creditos FROM Materias WHERE Nombre = @Nombre", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombreMateria);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Materia materia = new Materia
                            {
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Creditos = Convert.ToInt32(reader["Creditos"])
                            };

                            return materia;
                        }
                        else
                        {
                            return null; // No se encontró la materia con el nombre especificado
                        }
                    }
                }
            }
        }
    }
}
