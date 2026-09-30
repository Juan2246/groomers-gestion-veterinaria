namespace Presentacion
{
    partial class FrmGestionPacientes
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
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGestiondeMascotas = new System.Windows.Forms.Button();
            this.btnGestiondePropietarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(17, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 25);
            this.label13.TabIndex = 119;
            this.label13.Text = "GROOMERS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(365, 16);
            this.label14.TabIndex = 120;
            this.label14.Text = "Bienvenido a la Gestión de Pacientes de Groomers:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(321, 221);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(63, 30);
            this.btnSalir.TabIndex = 121;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGestiondeMascotas
            // 
            this.btnGestiondeMascotas.Location = new System.Drawing.Point(128, 167);
            this.btnGestiondeMascotas.Name = "btnGestiondeMascotas";
            this.btnGestiondeMascotas.Size = new System.Drawing.Size(141, 30);
            this.btnGestiondeMascotas.TabIndex = 122;
            this.btnGestiondeMascotas.Text = "Gestion de Mascotas";
            this.btnGestiondeMascotas.Click += new System.EventHandler(this.btnGestiondeMascotas_Click);
            // 
            // btnGestiondePropietarios
            // 
            this.btnGestiondePropietarios.Location = new System.Drawing.Point(128, 113);
            this.btnGestiondePropietarios.Name = "btnGestiondePropietarios";
            this.btnGestiondePropietarios.Size = new System.Drawing.Size(141, 30);
            this.btnGestiondePropietarios.TabIndex = 123;
            this.btnGestiondePropietarios.Text = "Gestion de Propietarios";
            this.btnGestiondePropietarios.Click += new System.EventHandler(this.btnGestiondePropietarios_Click);
            // 
            // FrmGestionPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 263);
            this.Controls.Add(this.btnGestiondePropietarios);
            this.Controls.Add(this.btnGestiondeMascotas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Name = "FrmGestionPacientes";
            this.Text = "Gestión de Pacientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGestiondeMascotas;
        private System.Windows.Forms.Button btnGestiondePropietarios;
    }
}