using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using SistemaDeMatriculas.Clases;

namespace SistemaDeMatriculas
{
    public partial class FormRegistro : Form
    {
        private Clases.Cconexion objetoConexion;
        public FormRegistro()
        {
            InitializeComponent();
            objetoConexion = new Clases.Cconexion();
            TxtContraseñaR.UseSystemPasswordChar = true; //mostrar la contraseña en asteriscos
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            //tamaño 1100; 550
            //colores Menu: 12; 22; 24 | Barra: 0; 70; 67 | Contenedor 244; 233; 205
        }
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            // Validar los datos ingresados antes de guardarlos en la base de datos
            if (!int.TryParse(txtCedulaR.Text, out int IdUsuarioCedula))
            {
                MessageBox.Show("La cédula debe tener ceros en vez de espacios. Ejemplo: 101110111");
                return;
            }
            string nombreUsuario = TxtNombreUsuarioR.Text;
            string contraseña = TxtContraseñaR.Text;
            string sal = GenerarSalAleatoria();
            string contraseñaConSal = contraseña + sal;
            string contraseñaHash = CalcularSHA256Hash(contraseñaConSal);
            bool esFuncionario = false;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            // Verificar si el nombre de usuario ya existe en la base de datos
            if (UsuarioExiste(nombreUsuario))
            {
                MessageBox.Show("El nombre de usuario ya está en uso. Por favor, elija otro.");
                return;
            }

            // Agregar el nuevo usuario a la base de datos
            if (AgregarNuevoUsuario(IdUsuarioCedula, nombreUsuario, contraseñaHash, sal, esFuncionario))
            {
                MessageBox.Show("Registro exitoso. ¡Ahora puede iniciar sesión!");
                LimpiarCampos();
                Form1 formLogin = new Form1();
                formLogin.Show();
                this.Close(); // Cierra la ventana de registro
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar al usuario. Inténtelo nuevamente.");
            }
        }
        private bool UsuarioExiste(string nombreUsuario)
        {
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
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

        private bool AgregarNuevoUsuario(int IdUsuarioCedula, string nombreUsuario, string contraseñaHash, string sal, bool esFuncionario)
        {
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Usuarios (IdUsuarioCedula, NombreUsuario, ContraseñaHash, Salt, EsFuncionario, FechaCreacion) VALUES (@IdUsuarioCedula, @NombreUsuario, @ContraseñaHash, @Salt, @EsFuncionario, @FechaCreacion)", connection))
                {
                    command.Parameters.AddWithValue("@IdUsuarioCedula", IdUsuarioCedula);
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@ContraseñaHash", contraseñaHash);
                    command.Parameters.AddWithValue("@Salt", sal);
                    command.Parameters.AddWithValue("@EsFuncionario", esFuncionario ? 1 : 0);
                    command.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        private string GenerarSalAleatoria()
        {
            // Generar un "sal" aleatorio utilizando un algoritmo seguro
            byte[] randomBytes = new byte[32]; // 32 bytes = 256 bits
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }

        private string CalcularSHA256Hash(string input)
        {
            // Calcular el hash SHA-256 de una cadena de entrada
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private void LimpiarCampos()
        {
            // Limpia los campos después de un registro exitoso
            TxtNombreUsuarioR.Text = "";
            TxtContraseñaR.Text = "";
        }

        private void ChMostrar_CheckedChanged_1(object sender, EventArgs e)
        {
            TxtContraseñaR.UseSystemPasswordChar = !ChMostrar.Checked;
        }


        private void Salir_Click_1(object sender, EventArgs e)
        {
            // Finalizar el programa
            Form1 formLogin = new Form1();
            formLogin.Show();
            this.Close(); // Cierra la ventana de registro
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void txtCedulaR_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
