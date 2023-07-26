using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using SistemaDeMatriculas.Clases;

namespace SistemaDeMatriculas
{
    public partial class Form1 : Form
    {
        private int intentosFallidos = 0;
        private Cconexion objetoConexion;
        public Form1()
        {
            InitializeComponent();
            objetoConexion = new Cconexion();
            Contraseña.UseSystemPasswordChar = true; //mostrar la contraseña en asteriscos
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tamaño 1300; 650
            //colores Menu: 12; 22; 24 | Barra: 0; 70; 67 | Contenedor 244; 233; 205
        }

        private void Login_Click_1(object sender, EventArgs e)
        {
            //boton de login 
            // Código para verificar las credenciales y autenticar al usuario
            if (intentosFallidos >= 3)
            {
                MessageBox.Show("Has llegado al número máximo de intentos. El programa se cerrará.");
                Application.Exit();
                return;
            }

            string nombreUsuario = Usuario.Text;
            string contraseña = Contraseña.Text;

            if (ValidarCredenciales(nombreUsuario, contraseña))
            {
                intentosFallidos = 0;
                //Abre el formulario principal y cerrar/oculta el formulario de login
                FormPrincipal formPrincipal = new FormPrincipal(nombreUsuario);
                formPrincipal.Show();
                this.Hide();

            }
            else
            {
                intentosFallidos++;
                MessageBox.Show("Credenciales incorrectas. Intento " + intentosFallidos + " de 3. Puedes intentar contactando con el equipo de soporte para restablecer tu contraseña");

                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Has llegado al número máximo de intentos. El programa se cerrará.");
                    Application.Exit();
                }
            }
        }

        private bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                //IMPORTANTE, USAR TRY POR SI SE GENERA UN ERROR EN LA CONEXION CON LA BD
                try
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

                                if (contraseñaHash == contraseñaHashDB)
                                {
                                    // Credenciales correctas
                                    // Actualizar fecha de inicio de sesión y estado de activo
                                    ActualizarInicioSesionYEstado(nombreUsuario);
                                    return true;
                                }
                                else
                                {
                                    return false; // Contraseña incorrecta
                                }
                            }
                            else
                            {
                                return false; // El usuario no existe en la base de datos
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("No se pudo conectar a la base de datos. Contacte al administrador para que agregue su ip al firewall.\n\nDetalles del error: " + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
                
            }
        }

        private void ActualizarInicioSesionYEstado(string nombreUsuario)
        {
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Usuarios SET FechaUltimoInicioSesion = @FechaUltimoInicioSesion, Activo = 1 WHERE NombreUsuario = @NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@FechaUltimoInicioSesion", DateTime.Now);
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.ExecuteNonQuery();
                }
            }
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
        private void btnRegistro_Click_1(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();
            this.Hide(); // Close | Oculta el formulario de login 
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

        private void ChMostrar_CheckedChanged(object sender, EventArgs e)
        {
            //boton para hacer visible la contraseña
            Contraseña.UseSystemPasswordChar = !ChMostrar.Checked;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}