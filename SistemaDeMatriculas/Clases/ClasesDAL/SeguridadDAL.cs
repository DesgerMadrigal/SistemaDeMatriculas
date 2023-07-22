using System;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace SistemaDeMatriculas.Clases.ClasesDAL
{
    public class SeguridadDAL
    {
        private readonly Cconexion conexion;

        public SeguridadDAL()
        {
            conexion = new Cconexion();
        }

        public bool AutenticarUsuario(string nombreUsuario, string contraseña)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT ContraseñaHash, Salt FROM Usuarios WHERE NombreUsuario = @NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string contraseñaHashDB = reader["ContraseñaHash"].ToString();
                            string sal = reader["Salt"].ToString();
                            string contraseñaConSal = contraseña + sal;
                            string contraseñaHash = CalcularSHA256Hash(contraseñaConSal);

                            return contraseñaHash == contraseñaHashDB;
                        }
                        else
                        {
                            return false; // El usuario no existe en la base de datos
                        }
                    }
                }
            }
        }

        public bool AsignarRolUsuario(string nombreUsuario, string rol)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int usuarioId = ObtenerIdUsuarioPorNombre(nombreUsuario, connection, transaction);
                        int rolId = ObtenerIdRolPorNombre(rol, connection, transaction);

                        if (usuarioId == -1 || rolId == -1)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        using (SqlCommand command = new SqlCommand("INSERT INTO UsuarioRol (UsuarioId, RolId) VALUES (@UsuarioId, @RolId)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                            command.Parameters.AddWithValue("@RolId", rolId);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error al asignar rol al usuario: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private int ObtenerIdUsuarioPorNombre(string nombreUsuario, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("SELECT Id FROM Usuarios WHERE NombreUsuario = @NombreUsuario", connection, transaction))
            {
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private int ObtenerIdRolPorNombre(string nombreRol, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand("SELECT Id FROM Roles WHERE Nombre = @NombreRol", connection, transaction))
            {
                command.Parameters.AddWithValue("@NombreRol", nombreRol);

                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private string CalcularSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
