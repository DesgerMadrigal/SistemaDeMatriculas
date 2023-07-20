using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemaDeMatriculas
{   
    public partial class Form1 : Form
    {
        private int intentosFallidos = 0;
        private Clases.Cconexion objetoConexion;
        public Form1()
        {
            InitializeComponent();
            objetoConexion = new Clases.Cconexion();
            Contraseña.UseSystemPasswordChar = true; //mostrar la contraseña en asteriscos
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
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
                FormPrincipal formPrincipal = new FormPrincipal();
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
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        private void ChMostrar_CheckedChanged_1(object sender, EventArgs e)
        {
            //boton para hacer visible la contraseña
            Contraseña.UseSystemPasswordChar = !ChMostrar.Checked;
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            // Finalizar el programa
            Application.Exit();
            this.Close();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.Show();
            this.Hide(); // Close | Oculta el formulario de login 
        }
    }
}
