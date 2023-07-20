
namespace SistemaDeMatriculas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Login = new System.Windows.Forms.Button();
            this.ChMostrar = new System.Windows.Forms.CheckBox();
            this.TxTContraseña = new System.Windows.Forms.Label();
            this.TxTNombreUsuario = new System.Windows.Forms.Label();
            this.Contraseña = new System.Windows.Forms.TextBox();
            this.Usuario = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Salir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(438, 250);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 25);
            this.Login.TabIndex = 18;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // ChMostrar
            // 
            this.ChMostrar.AutoSize = true;
            this.ChMostrar.BackColor = System.Drawing.Color.Transparent;
            this.ChMostrar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChMostrar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChMostrar.Location = new System.Drawing.Point(443, 192);
            this.ChMostrar.Name = "ChMostrar";
            this.ChMostrar.Size = new System.Drawing.Size(70, 19);
            this.ChMostrar.TabIndex = 17;
            this.ChMostrar.Text = "Mostrar";
            this.ChMostrar.UseVisualStyleBackColor = false;
            this.ChMostrar.CheckedChanged += new System.EventHandler(this.ChMostrar_CheckedChanged_1);
            // 
            // TxTContraseña
            // 
            this.TxTContraseña.AutoSize = true;
            this.TxTContraseña.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxTContraseña.Location = new System.Drawing.Point(319, 196);
            this.TxTContraseña.Name = "TxTContraseña";
            this.TxTContraseña.Size = new System.Drawing.Size(71, 15);
            this.TxTContraseña.TabIndex = 16;
            this.TxTContraseña.Text = "Contraseña:";
            // 
            // TxTNombreUsuario
            // 
            this.TxTNombreUsuario.AutoSize = true;
            this.TxTNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.TxTNombreUsuario.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxTNombreUsuario.Location = new System.Drawing.Point(319, 145);
            this.TxTNombreUsuario.Name = "TxTNombreUsuario";
            this.TxTNombreUsuario.Size = new System.Drawing.Size(117, 15);
            this.TxTNombreUsuario.TabIndex = 15;
            this.TxTNombreUsuario.Text = "Nombre de Usuario:";
            // 
            // Contraseña
            // 
            this.Contraseña.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contraseña.Location = new System.Drawing.Point(322, 212);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(191, 23);
            this.Contraseña.TabIndex = 14;
            // 
            // Usuario
            // 
            this.Usuario.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.Location = new System.Drawing.Point(322, 161);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(191, 23);
            this.Usuario.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(286, 205);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(286, 154);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.White;
            this.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salir.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.Location = new System.Drawing.Point(373, 302);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(75, 25);
            this.Salir.TabIndex = 10;
            this.Salir.Text = "Salir";
            this.Salir.UseVisualStyleBackColor = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(286, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 19;
            this.button1.Text = "Registrarse";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.ChMostrar);
            this.Controls.Add(this.TxTContraseña);
            this.Controls.Add(this.TxTNombreUsuario);
            this.Controls.Add(this.Contraseña);
            this.Controls.Add(this.Usuario);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Salir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.CheckBox ChMostrar;
        private System.Windows.Forms.Label TxTContraseña;
        private System.Windows.Forms.Label TxTNombreUsuario;
        private System.Windows.Forms.TextBox Contraseña;
        private System.Windows.Forms.TextBox Usuario;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Button button1;
    }
}

