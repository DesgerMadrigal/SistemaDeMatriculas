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
    public partial class Matricula : Form
    {
        private Cconexion objetoConexion;
        List<string> IdentificacionesList = new List<string>
        {
            "Cédula de Nacional",
            "Cédula de Extranjería",
            "Cédula de Ciudadanía",
            "Pasaporte"
        };
        List<string> GenerosList = new List<string>
        {
            "Masculino",
            "Femenino",
            "Binario"
        };
        public Matricula()
        {
            InitializeComponent();
            objetoConexion = new Cconexion();
        }

        private void Matricula_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            cmbIdentificacion.DataSource = IdentificacionesList;
            cmbGenero.DataSource = GenerosList;
            CargarCarreraSemestre();
        }

        private void CargarCarreraSemestre()
        {
            string queryCarrera = "SELECT Nombre FROM Carrera";
            string querySemestre = "SELECT Nombre FROM Semestre";

            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(queryCarrera, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<string> CarrerasList = new List<string>();
                        while (reader.Read())
                        {
                            string NombreC = reader["Nombre"].ToString();
                            CarrerasList.Add(NombreC);
                        }
                        reader.Close();
                        // Asignar los datos recuperados al DataSource del ComboBox
                        cmbCarrera.DataSource = CarrerasList;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos desde la base de datos: " + ex.Message);
                    }
                }
            }
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand(querySemestre, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<string> SemestreList = new List<string>();
                        while (reader.Read())
                        {
                            string NombreS = reader["Nombre"].ToString();
                            SemestreList.Add(NombreS);
                        }
                        reader.Close();
                        // Asignar los datos recuperados al DataSource del ComboBox
                        cmbSemestre.DataSource = SemestreList;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos desde la base de datos: " + ex.Message);
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string TipoIdentificacion = cmbIdentificacion.SelectedItem.ToString();
            string TipoGenero = cmbGenero.SelectedItem.ToString();
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellidos.Text;
            string Cedula = txtCedula.Text;
            string Telefono = txtTelefono.Text;
            string Nacionalidad = txtNacionalidad.Text;
            string Direccion = txtDireccion.Text;
            string Provincia = txtProvincia.Text;
            string Canton = txtCanton.Text;
            string Distrito = txtDistrito.Text;
            string Email = txtEmail.Text;
            DateTime fechaNacimiento = dtp1.Value;
            string Carrera = cmbCarrera.SelectedItem.ToString();
            string Semestre = cmbSemestre.SelectedItem.ToString();
            
            if (string.IsNullOrEmpty(TipoIdentificacion) || string.IsNullOrEmpty(TipoGenero) || string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Apellidos) || string.IsNullOrEmpty(Cedula) || string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Nacionalidad) ||
                string.IsNullOrEmpty(Direccion) || string.IsNullOrEmpty(Provincia) || string.IsNullOrEmpty(Canton) || string.IsNullOrEmpty(Distrito) ||
                string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Carrera) || string.IsNullOrEmpty(Semestre))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }
            AgregarEstudiante(Nacionalidad, TipoIdentificacion, TipoGenero, Nombre, Direccion, Email, Carrera, Semestre, fechaNacimiento, Cedula, Telefono, Apellidos, Provincia, Canton, Distrito);
            MessageBox.Show("Registro de la matricula exitoso!");
            
        }
  
        private int AgregarEstudiante(string Nacionalidad, string TipoIdenficacion, string TipoGenero, string Nombre, string Direccion, string Email, string Carrera, string Semestre,  DateTime fechaNacimiento, string Cedula, string Telefono, string Apellidos, string Provincia, string Canton, string Distrito)
        {
            // Realizar la lógica para agregar el estudiante a la base de datos
            // Puedes insertar un nuevo registro en la tabla 'Estudiantes' y obtener el ID del estudiante recién agregado.
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Matricula(Nacionalidad, TipoIdentificacion, Genero, Nombre, Direccion, Email, Carrera, Semestre, FechaNacimiento, Cedula, Telefono, Apellidos, Provincia, Canton, Distrito) VALUES(@Nacionalidad, @TipoIdentificacion, @Genero, @Nombre, @Direccion, @Email, @Carrera, @Semestre, @FechaNacimiento, @Cedula, @Telefono, @Apellidos, @Provincia, @Canton, @Distrito)", connection))
                {
                    command.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
                    command.Parameters.AddWithValue("@TipoIdentificacion", TipoIdenficacion);
                    command.Parameters.AddWithValue("@Genero", TipoGenero);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Direccion", Direccion);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Carrera", Carrera);
                    command.Parameters.AddWithValue("@Semestre", Semestre);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Cedula", Cedula);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Apellidos", Apellidos);
                    command.Parameters.AddWithValue("@Provincia", Provincia);
                    command.Parameters.AddWithValue("@Canton", Canton);
                    command.Parameters.AddWithValue("@Distrito", Distrito);

                    // Ejecutar la consulta para realizar la inserción
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se insertó al menos una fila (rowsAffected > 0)
                    if (rowsAffected > 0)
                    {
                        return 1;
                    }
                }
            }
            return -1;
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario después de guardar la matrícula
            cmbIdentificacion.SelectedIndex = -1; ;
            cmbGenero.SelectedIndex = -1;
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";
            txtProvincia.Text = "";
            txtCanton.Text = "";
            txtDistrito.Text = "";
            txtEmail.Text = "";
            dtp1.Value = DateTime.Now;
            cmbCarrera.SelectedIndex = -1;
            cmbSemestre.SelectedIndex = -1;
            txtNacionalidad.Text = "";
            txtApellidos.Text = "";
            cmbSemestre.SelectedIndex = -1;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario de matrícula sin guardar cambios
            this.Close();
        }

        private void cmbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Identificacion_Click(object sender, EventArgs e)
        {

        }

        private void TxTNombreUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

