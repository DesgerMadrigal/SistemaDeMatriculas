
namespace SistemaDeMatriculas
{
    partial class FormRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro));
            this.Salir = new System.Windows.Forms.Button();
            this.ChMostrar = new System.Windows.Forms.CheckBox();
            this.TxTContraseña = new System.Windows.Forms.Label();
            this.TxTNombreUsuario = new System.Windows.Forms.Label();
            this.TxtContraseñaR = new System.Windows.Forms.TextBox();
            this.TxtNombreUsuarioR = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.White;
            this.Salir.FlatAppearance.BorderSize = 0;
            this.Salir.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.Location = new System.Drawing.Point(306, 233);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(75, 25);
            this.Salir.TabIndex = 11;
            this.Salir.Text = "Salir";
            this.Salir.UseVisualStyleBackColor = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // ChMostrar
            // 
            this.ChMostrar.AutoSize = true;
            this.ChMostrar.BackColor = System.Drawing.Color.Transparent;
            this.ChMostrar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChMostrar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChMostrar.Location = new System.Drawing.Point(427, 184);
            this.ChMostrar.Name = "ChMostrar";
            this.ChMostrar.Size = new System.Drawing.Size(70, 19);
            this.ChMostrar.TabIndex = 24;
            this.ChMostrar.Text = "Mostrar";
            this.ChMostrar.UseVisualStyleBackColor = false;
            this.ChMostrar.CheckedChanged += new System.EventHandler(this.ChMostrar_CheckedChanged);
            // 
            // TxTContraseña
            // 
            this.TxTContraseña.AutoSize = true;
            this.TxTContraseña.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxTContraseña.Location = new System.Drawing.Point(303, 188);
            this.TxTContraseña.Name = "TxTContraseña";
            this.TxTContraseña.Size = new System.Drawing.Size(71, 15);
            this.TxTContraseña.TabIndex = 23;
            this.TxTContraseña.Text = "Contraseña:";
            // 
            // TxTNombreUsuario
            // 
            this.TxTNombreUsuario.AutoSize = true;
            this.TxTNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.TxTNombreUsuario.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxTNombreUsuario.Location = new System.Drawing.Point(303, 137);
            this.TxTNombreUsuario.Name = "TxTNombreUsuario";
            this.TxTNombreUsuario.Size = new System.Drawing.Size(117, 15);
            this.TxTNombreUsuario.TabIndex = 22;
            this.TxTNombreUsuario.Text = "Nombre de Usuario:";
            // 
            // TxtContraseñaR
            // 
            this.TxtContraseñaR.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContraseñaR.Location = new System.Drawing.Point(306, 204);
            this.TxtContraseñaR.Name = "TxtContraseñaR";
            this.TxtContraseñaR.Size = new System.Drawing.Size(191, 23);
            this.TxtContraseñaR.TabIndex = 21;
            this.TxtContraseñaR.TextChanged += new System.EventHandler(this.TxtContraseñaR_TextChanged);
            // 
            // TxtNombreUsuarioR
            // 
            this.TxtNombreUsuarioR.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreUsuarioR.Location = new System.Drawing.Point(306, 153);
            this.TxtNombreUsuarioR.Name = "TxtNombreUsuarioR";
            this.TxtNombreUsuarioR.Size = new System.Drawing.Size(191, 23);
            this.TxtNombreUsuarioR.TabIndex = 20;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(270, 197);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(270, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.BackColor = System.Drawing.Color.White;
            this.BtnRegistrar.FlatAppearance.BorderSize = 0;
            this.BtnRegistrar.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.Location = new System.Drawing.Point(422, 233);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(75, 25);
            this.BtnRegistrar.TabIndex = 25;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = false;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 37);
            this.label1.TabIndex = 26;
            this.label1.Text = "REGISTRO";
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.ChMostrar);
            this.Controls.Add(this.TxTContraseña);
            this.Controls.Add(this.TxTNombreUsuario);
            this.Controls.Add(this.TxtContraseñaR);
            this.Controls.Add(this.TxtNombreUsuarioR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Salir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistro";
            this.Text = "FormRegistro";
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.CheckBox ChMostrar;
        private System.Windows.Forms.Label TxTContraseña;
        private System.Windows.Forms.Label TxTNombreUsuario;
        private System.Windows.Forms.TextBox TxtContraseñaR;
        private System.Windows.Forms.TextBox TxtNombreUsuarioR;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label label1;
    }
}