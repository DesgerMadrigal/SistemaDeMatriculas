using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class ReporteriaDAL
    {
        private readonly Cconexion conexion;

        public ReporteriaDAL()
        {
            conexion = new Cconexion();
        }

        public List<Usuario> ObtenerUsuariosActivos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE Activo = 1", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreUsuario = reader["NombreUsuario"].ToString(),
                                EsFuncionario = Convert.ToBoolean(reader["EsFuncionario"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }

        public List<Usuario> ObtenerUsuariosInactivos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE Activo = 0", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreUsuario = reader["NombreUsuario"].ToString(),
                                EsFuncionario = Convert.ToBoolean(reader["EsFuncionario"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }

        public List<Oferta> ObtenerOfertasPorCodigo(string codigoOferta)
        {
            List<Oferta> ofertas = new List<Oferta>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Ofertas WHERE Codigo = @Codigo", connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigoOferta);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Oferta oferta = new Oferta
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CodigoOferta = reader["Codigo"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
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

        public List<MateriaEstudiante> ObtenerMateriasAprobadasPorEstudiante(int estudianteId)
        {
            List<MateriaEstudiante> materiasAprobadas = new List<MateriaEstudiante>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT M.Codigo, M.Nombre, EM.Condicion FROM Materias M INNER JOIN EstudianteMateria EM ON M.Id = EM.MateriaId WHERE EM.EstudianteId = @EstudianteId AND EM.Condicion = 'Aprobado'", connection))
                {
                    command.Parameters.AddWithValue("@EstudianteId", estudianteId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MateriaEstudiante materiaEstudiante = new MateriaEstudiante
                            {
                                CodigoMateria = reader["Codigo"].ToString(),
                                NombreMateria = reader["Nombre"].ToString(),
                                Condicion = reader["Condicion"].ToString()
                            };

                            materiasAprobadas.Add(materiaEstudiante);
                        }
                    }
                }
            }

            return materiasAprobadas;
        }

        public List<Docente> ObtenerDocentesActivos()
        {
            List<Docente> docentes = new List<Docente>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Docentes WHERE Activo = 1", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Docente docente = new Docente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };

                            docentes.Add(docente);
                        }
                    }
                }
            }

            return docentes;
        }

        public List<Aula> ObtenerAulasPorCondicion(string condicion)
        {
            List<Aula> aulas = new List<Aula>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Aulas WHERE Condicion = @Condicion", connection))
                {
                    command.Parameters.AddWithValue("@Condicion", condicion);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aula aula = new Aula
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NumeroAula = reader["NumeroAula"].ToString(),
                                Capacidad = Convert.ToInt32(reader["Capacidad"]),
                                Condicion = reader["Condicion"].ToString()
                            };

                            aulas.Add(aula);
                        }
                    }
                }
            }

            return aulas;
        }
    }

}
