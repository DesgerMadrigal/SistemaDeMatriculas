using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class MatriculaDAL
    {
        private readonly Cconexion conexion;

        public MatriculaDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        

        // Método para agregar una nueva matrícula a la base de datos
        public bool AgregarMatricula(Matricula matricula)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Matriculas (IdEstudiante, CodigoMateria, Nota) VALUES (@IdEstudiante, @CodigoMateria, @Nota)", connection))
                {
                    command.Parameters.AddWithValue("@IdEstudiante", matricula.IdEstudiante);
                    command.Parameters.AddWithValue("@CodigoMateria", matricula.CodigoMateria);
                    command.Parameters.AddWithValue("@Nota", matricula.Nota);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para obtener todas las matrículas de un estudiante por su ID
        public List<Matricula> ObtenerMatriculasPorEstudiante(int idEstudiante)
        {
            List<Matricula> matriculas = new List<Matricula>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT IdEstudiante, CodigoMateria, Nota FROM Matriculas WHERE IdEstudiante = @IdEstudiante", connection))
                {
                    command.Parameters.AddWithValue("@IdEstudiante", idEstudiante);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Matricula matricula = new Matricula
                            {
                                IdEstudiante = Convert.ToInt32(reader["IdEstudiante"]),
                                CodigoMateria = reader["CodigoMateria"].ToString(),
                                Nota = Convert.ToDouble(reader["Nota"])
                            };

                            matriculas.Add(matricula);
                        }
                    }
                }
            }

            return matriculas;
        }

        // Método para actualizar la nota de una matrícula en la base de datos
        public bool ActualizarNotaMatricula(int idEstudiante, string codigoMateria, double nuevaNota)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Matriculas SET Nota = @NuevaNota WHERE IdEstudiante = @IdEstudiante AND CodigoMateria = @CodigoMateria", connection))
                {
                    command.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                    command.Parameters.AddWithValue("@CodigoMateria", codigoMateria);
                    command.Parameters.AddWithValue("@NuevaNota", nuevaNota);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar una matrícula de la base de datos
        public bool EliminarMatricula(int idEstudiante, string codigoMateria)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Matriculas WHERE IdEstudiante = @IdEstudiante AND CodigoMateria = @CodigoMateria", connection))
                {
                    command.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                    command.Parameters.AddWithValue("@CodigoMateria", codigoMateria);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
