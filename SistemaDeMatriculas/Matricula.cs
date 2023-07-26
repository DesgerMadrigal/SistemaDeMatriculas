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
        public Matricula()
        {
            InitializeComponent();
            objetoConexion = new Cconexion();
        }

        private void Matricula_Load(object sender, EventArgs e)
        {
            //CargarCursos();
        }
        private void CargarCursos()
        {
            cmbSemestre.Items.Clear(); // Limpiamos los elementos del ComboBox para evitar duplicados

            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT ID, Nombre FROM Cursos", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Obtenemos el ID y Nombre del curso desde la consulta
                            int idCurso = Convert.ToInt32(reader["ID"]);
                            string nombreCurso = reader["Nombre"].ToString();

                            // Agregamos el curso al ComboBox
                            cmbSemestre.Items.Add(new CursoItem(idCurso, nombreCurso));
                        }
                    }
                }
            }

            // Si hay cursos disponibles en el ComboBox, seleccionamos el primer curso
            if (cmbSemestre.Items.Count > 0)
            {
                cmbSemestre.SelectedIndex = 0;
            }
        }

        // Clase para almacenar el ID y Nombre del curso en el ComboBox
        private class CursoItem
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public CursoItem(int id, string nombre)
            {
                Id = id;
                Nombre = nombre;
            }

            public override string ToString()
            {
                return Nombre;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los datos ingresados por el usuario en los campos del formulario
            string nombreEstudiante = txtNacionalidad.Text;
            string apellidoEstudiante = txtApellidos.Text;
            DateTime fechaNacimiento = dtp1.Value;
            string direccion = txtDireccion.Text;
            string cedula = txtCedula.Text;
            string telefono = txtTelefono.Text;
            string correoElectronico = txtEmail.Text;
            string nombreCurso = cmbSemestre.Text; // Obtener el nombre del curso seleccionado en el ComboBox

            // Verificar que se hayan completado todos los campos requeridos
            if (string.IsNullOrEmpty(nombreEstudiante) || string.IsNullOrEmpty(apellidoEstudiante)
                || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(cedula)
                || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(correoElectronico)
                || string.IsNullOrEmpty(nombreCurso))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            // Realizar la lógica para insertar el estudiante en la base de datos
            int idEstudiante = AgregarEstudiante(nombreEstudiante, apellidoEstudiante, fechaNacimiento, direccion, cedula, telefono, correoElectronico);

            if (idEstudiante != -1)
            {
                // Realizar la lógica para insertar la matrícula en la base de datos
                // Aquí debes hacer las consultas necesarias para obtener el ID del curso
                // y luego insertar un registro en la tabla 'Matriculas' con la información de la matrícula.

                int idCurso = ObtenerIdCurso(nombreCurso);

                if (idCurso != -1)
                {
                    if (GuardarMatricula(idEstudiante, idCurso))
                    {
                        MessageBox.Show("Matrícula guardada exitosamente.");
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la matrícula. Inténtelo nuevamente.");
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el ID del curso. Verifique el nombre del curso ingresado.");
                }
            }
            else
            {
                MessageBox.Show("Error al agregar el estudiante. Inténtelo nuevamente.");
            }

        }
        private int ObtenerIdCurso(string nombreCurso)
        {
            // Realizar la consulta a la base de datos para obtener el ID del curso según su nombre
            int idCurso = -1;

            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT ID FROM Cursos WHERE Nombre = @NombreCurso", connection))
                {
                    command.Parameters.AddWithValue("@NombreCurso", nombreCurso);

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out idCurso))
                    {
                        return idCurso;
                    }
                }
            }

            return idCurso;
        }
        private bool GuardarMatricula(int idEstudiante, int idCurso)
        {
            // Realizar la lógica para guardar la matrícula en la base de datos
            // Puedes insertar un nuevo registro en la tabla 'Matriculas' con los IDs del estudiante y el curso
            // Además, puedes guardar la fecha de matrícula actual usando DateTime.Now

            // Ejemplo de inserción en la tabla 'Matriculas' (adaptar a tu estructura de tabla)
            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Matriculas (IDEstudiante, IDCurso, FechaMatricula) VALUES (@IDEstudiante, @IDCurso, @FechaMatricula)", connection))
                {
                    command.Parameters.AddWithValue("@IDEstudiante", idEstudiante);
                    command.Parameters.AddWithValue("@IDCurso", idCurso);
                    command.Parameters.AddWithValue("@FechaMatricula", DateTime.Now);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        private int AgregarEstudiante(string nombre, string apellido, DateTime fechaNacimiento, string direccion, string cedula, string telefono, string correoElectronico)
        {
            // Realizar la lógica para agregar el estudiante a la base de datos
            // Puedes insertar un nuevo registro en la tabla 'Estudiantes' y obtener el ID del estudiante recién agregado.

            using (SqlConnection connection = objetoConexion.ObtenerConexion())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Estudiantes (Nombre, Apellido, FechaNacimiento, Direccion, Cedula, Telefono, CorreoElectronico) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Direccion, @Cedula, @Telefono, @CorreoElectronico); SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Cedula", cedula);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int idEstudiante))
                    {
                        return idEstudiante;
                    }
                }
            }

            return -1; // Retornar -1 si hubo un error al agregar el estudiante.
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario después de guardar la matrícula
            txtNacionalidad.Text = "";
            txtApellidos.Text = "";
            dtp1.Value = DateTime.Now;
            txtDireccion.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
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

