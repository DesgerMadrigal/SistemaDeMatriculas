using System;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Diagnostics;



namespace SistemaDeMatriculas.Clases
{
    public class UsuarioDAL
    {
        private Cconexion conexion;

        public UsuarioDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        public bool AsignarRolUsuario(int idUsuario, int idRol)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO UsuariosRoles (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)", connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    command.Parameters.AddWithValue("@IdRol", idRol);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool UsuarioExiste(string nombreUsuario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public bool AsignarPermisoRol(int idRol, int idPermiso)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO RolesPermisos (IdRol, IdPermiso) VALUES (@IdRol, @IdPermiso)", connection))
                {
                    command.Parameters.AddWithValue("@IdRol", idRol);
                    command.Parameters.AddWithValue("@IdPermiso", idPermiso);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Usuarios", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                NombreUsuario = reader["NombreUsuario"].ToString(),
                                // Otras propiedades del usuario si las hubiera
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

    }
}
