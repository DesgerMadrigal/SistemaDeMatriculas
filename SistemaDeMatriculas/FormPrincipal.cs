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
using SistemaDeMatriculas.Clases;

namespace SistemaDeMatriculas
{
    public partial class FormPrincipal : Form
    {
        private Cconexion objetoConexion;
        private string nombreUsuario;
        private bool esFuncionario;
        public FormPrincipal()
        {
            InitializeComponent();
            objetoConexion = new Cconexion();
            AbrirFormHija(new Inicio());

        }
        public FormPrincipal(string nombreUsuario) : this()
        {
            this.nombreUsuario = nombreUsuario;
            CargarInformacionUsuario();
            // Actualizar etiquetas y permisos según el rol del usuario
            if (esFuncionario)
            {
                lblRol.Text = "Administrador";
                // Mostrar ventanas y controles adicionales para funcionarios
                // Por ejemplo:
                //btnInicio.Visible = false;
                //btnPerfil.Visible = true;
            }
            else
            {
                lblRol.Text = "Estudiante";
                // Mostrar ventanas y controles adicionales para estudiantes
                // Por ejemplo:
                //btnPerfil.Visible = false;
                //btnInicio.Visible = true;
            }
        }

        private void CargarInformacionUsuario()
        {
            // Realizar la consulta a la base de datos para obtener la información del usuario
            // y actualizar las variables 'nombreUsuario' y 'esFuncionario' con los valores obtenidos
            // Asumamos que ya tienes la conexión a la base de datos establecida en el objeto 'objetoConexion'

            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtenemos los datos del usuario desde la consulta
                            // Asumimos que en la tabla 'Usuarios' existen columnas como 'EsFuncionario', 'Nombre', 'Apellido', etc.

                            // Ejemplo de asignación de valores, adapta esto a tu estructura de tabla
                            esFuncionario = Convert.ToBoolean(reader["EsFuncionario"]);
                            string nombre = reader["NombreUsuario"].ToString();

                            // Almacena otros datos relevantes del usuario si los necesitas
                        }
                    }
                }
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //tamaño 1100; 550
            //colores Menu: 12; 22; 24 | Barra: 0; 70; 67 | Contenedor 244; 233; 205
            lblNombreUsuario.Text = "Usuario: " + nombreUsuario;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Usuarios SET Activo = 0 WHERE NombreUsuario = @NombreUsuario", connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true ;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;  
        }

        private void lblNombreUsuario_Click(object sender, EventArgs e)
        {

        }
        private void AbrirFormHija(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Perfil());
        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Matricula());
        }
    }
}
