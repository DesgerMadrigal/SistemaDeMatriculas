using System;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace SistemaDeMatriculas.Clases
{
    public class UsuarioDAL
    {
        private readonly Cconexion conexion; // Usar la clase Cconexion para obtener la conexión

        public UsuarioDAL(Cconexion conexion)
        {
            this.conexion = conexion;
        }

        // Método para autenticar un usuario en el sistema
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

        // Método para agregar un nuevo usuario a la base de datos
        public bool AgregarUsuario(string nombreUsuario, string contraseña, bool esFuncionario)
        {
            string sal = GenerarSalAleatoria();
            string contraseñaConSal = contraseña + sal;
            string contraseñaHash = CalcularSHA256Hash(contraseñaConSal);

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Usuarios (NombreUsuario, ContraseñaHash, Salt, EsFuncionario) VALUES (@NombreUsuario, @ContraseñaHash, @Salt, @EsFuncionario)", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@ContraseñaHash", contraseñaHash);
                    command.Parameters.AddWithValue("@Salt", sal);
                    command.Parameters.AddWithValue("@EsFuncionario", esFuncionario);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        // Método para verificar si un nombre de usuario ya existe en la base de datos
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

        // Método para generar un "sal" aleatorio utilizando un algoritmo seguro
        private string GenerarSalAleatoria()
        {
            byte[] randomBytes = new byte[32]; // 32 bytes = 256 bits
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        // Método para calcular el hash SHA-256 de una cadena de entrada
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
