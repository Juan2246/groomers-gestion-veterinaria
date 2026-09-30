namespace Presentacion
{
    partial class FrmGestionPropietarios
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
            this.dgvPropietarios = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnModificarPropietario = new System.Windows.Forms.Button();
            this.btnEliminarPropietario = new System.Windows.Forms.Button();
            this.btnAgregarPropietario = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombrePropietario = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPropietarios
            // 
            this.dgvPropietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropietarios.Location = new System.Drawing.Point(20, 240);
            this.dgvPropietarios.Name = "dgvPropietarios";
            this.dgvPropietarios.ReadOnly = true;
            this.dgvPropietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropietarios.Size = new System.Drawing.Size(397, 239);
            this.dgvPropietarios.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Telefono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 93;
            this.label4.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "DNI:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Datos del Propietario:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(386, 16);
            this.label14.TabIndex = 90;
            this.label14.Text = "Bienvenido al Registro de un Propietario de Groomers:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(12, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 25);
            this.label13.TabIndex = 89;
            this.label13.Text = "GROOMERS";
            // 
            // btnModificarPropietario
            // 
            this.btnModificarPropietario.Location = new System.Drawing.Point(295, 187);
            this.btnModificarPropietario.Name = "btnModificarPropietario";
            this.btnModificarPropietario.Size = new System.Drawing.Size(75, 30);
            this.btnModificarPropietario.TabIndex = 118;
            this.btnModificarPropietario.Text = "Modificar";
            this.btnModificarPropietario.Click += new System.EventHandler(this.btnModificarPropietario_Click);
            // 
            // btnEliminarPropietario
            // 
            this.btnEliminarPropietario.Location = new System.Drawing.Point(199, 187);
            this.btnEliminarPropietario.Name = "btnEliminarPropietario";
            this.btnEliminarPropietario.Size = new System.Drawing.Size(75, 30);
            this.btnEliminarPropietario.TabIndex = 116;
            this.btnEliminarPropietario.Text = "Eliminar";
            this.btnEliminarPropietario.Click += new System.EventHandler(this.btnEliminarPropietario_Click);
            // 
            // btnAgregarPropietario
            // 
            this.btnAgregarPropietario.Location = new System.Drawing.Point(199, 135);
            this.btnAgregarPropietario.Name = "btnAgregarPropietario";
            this.btnAgregarPropietario.Size = new System.Drawing.Size(75, 30);
            this.btnAgregarPropietario.TabIndex = 117;
            this.btnAgregarPropietario.Text = "Agregar";
            this.btnAgregarPropietario.Click += new System.EventHandler(this.btnAgregarPropietario_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(75, 202);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 114;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(75, 176);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 113;
            // 
            // txtNombrePropietario
            // 
            this.txtNombrePropietario.Location = new System.Drawing.Point(75, 150);
            this.txtNombrePropietario.Name = "txtNombrePropietario";
            this.txtNombrePropietario.Size = new System.Drawing.Size(100, 20);
            this.txtNombrePropietario.TabIndex = 112;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(75, 124);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 111;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(295, 485);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(63, 30);
            this.btnSalir.TabIndex = 119;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmGestionPropietarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 522);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificarPropietario);
            this.Controls.Add(this.btnEliminarPropietario);
            this.Controls.Add(this.btnAgregarPropietario);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtNombrePropietario);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.dgvPropietarios);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Name = "FrmGestionPropietarios";
            this.Text = "Gestion Propietarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPropietarios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnModificarPropietario;
        private System.Windows.Forms.Button btnEliminarPropietario;
        private System.Windows.Forms.Button btnAgregarPropietario;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombrePropietario;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Button btnSalir;
    }
}