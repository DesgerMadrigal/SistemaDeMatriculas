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

        }
        private void BtnRegistrar_Click_1(object sender, EventArgs e)
        {
            // Validar los datos ingresados antes de guardarlos en la base de datos
            string nombreUsuario = TxtNombreUsuarioR.Text;
            string contraseña = TxtContraseñaR.Text;

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
            if (AgregarNuevoUsuario(nombreUsuario, contraseña))
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

        private bool AgregarNuevoUsuario(string nombreUsuario, string contraseña)
        {
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Usuarios (NombreUsuario, Contraseña) VALUES (@NombreUsuario, @Contraseña)", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        private void LimpiarCampos()
        {
            // Limpia los campos después de un registro exitoso
            TxtNombreUsuarioR.Text = "";
            TxtContraseñaR.Text = "";
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            // Finalizar el programa
            Application.Exit();
            this.Close();
        }

        private void ChMostrar_CheckedChanged(object sender, EventArgs e)
        {
            TxtContraseñaR.UseSystemPasswordChar = !ChMostrar.Checked;
        }

        private void TxtContraseñaR_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
