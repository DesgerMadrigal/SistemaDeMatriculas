using System;
using System.Text;
using System.Security.Cryptography;

namespace SistemaDeMatriculas.Clases
{
    public class SeguridadDLL
    {
        private readonly UsuarioDAL usuarioDAL;
        private readonly Cconexion conexion;

        public SeguridadDLL()
        {
            conexion = new Cconexion();
            usuarioDAL = new UsuarioDAL(conexion);
        }

        // Método para verificar si un nombre de usuario ya existe en la base de datos
        public bool UsuarioExiste(string nombreUsuario)
        {
            return usuarioDAL.UsuarioExiste(nombreUsuario);
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
