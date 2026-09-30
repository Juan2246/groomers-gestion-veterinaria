namespace Presentacion
{
    partial class FrmMenu
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
            this.btnMostrarAcciones = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMedicamentos = new System.Windows.Forms.Button();
            this.btnVeterinarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMostrarAcciones
            // 
            this.btnMostrarAcciones.Location = new System.Drawing.Point(361, 425);
            this.btnMostrarAcciones.Name = "btnMostrarAcciones";
            this.btnMostrarAcciones.Size = new System.Drawing.Size(150, 40);
            this.btnMostrarAcciones.TabIndex = 13;
            this.btnMostrarAcciones.Text = "Mostrar Resumen de Acciones";
            this.btnMostrarAcciones.Click += new System.EventHandler(this.btnMostrarAcciones_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(22, 297);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(150, 40);
            this.btnReportes.TabIndex = 12;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(22, 343);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Location = new System.Drawing.Point(22, 251);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(150, 40);
            this.btnCitas.TabIndex = 8;
            this.btnCitas.Text = "Gestión Citas";
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Location = new System.Drawing.Point(22, 113);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(150, 40);
            this.btnPacientes.TabIndex = 11;
            this.btnPacientes.Text = "Gestión Pacientes";
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(20, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "GROOMERS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Bienvenido al Menu principal de Groomers:";
            // 
            // btnMedicamentos
            // 
            this.btnMedicamentos.Location = new System.Drawing.Point(22, 206);
            this.btnMedicamentos.Name = "btnMedicamentos";
            this.btnMedicamentos.Size = new System.Drawing.Size(150, 40);
            this.btnMedicamentos.TabIndex = 23;
            this.btnMedicamentos.Text = "Gestión Medicamentos";
            this.btnMedicamentos.Click += new System.EventHandler(this.btnMedicamentos_Click);
            // 
            // btnVeterinarios
            // 
            this.btnVeterinarios.Location = new System.Drawing.Point(22, 160);
            this.btnVeterinarios.Name = "btnVeterinarios";
            this.btnVeterinarios.Size = new System.Drawing.Size(150, 40);
            this.btnVeterinarios.TabIndex = 24;
            this.btnVeterinarios.Text = "Gestión Veterinarios";
            this.btnVeterinarios.Click += new System.EventHandler(this.btnVeterinarios_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 477);
            this.Controls.Add(this.btnMedicamentos);
            this.Controls.Add(this.btnVeterinarios);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMostrarAcciones);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCitas);
            this.Controls.Add(this.btnPacientes);
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMostrarAcciones;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMedicamentos;
        private System.Windows.Forms.Button btnVeterinarios;
    }
}