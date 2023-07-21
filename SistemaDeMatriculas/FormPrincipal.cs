using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeMatriculas
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //tamaño 1300; 650
            //colores Menu: 12; 22; 24 | Barra: 0; 70; 67 | Contenedor 250; 244; 211
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            // Finalizar el programa
            Application.Exit();
            this.Close();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
