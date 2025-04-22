namespace TPWinForm_equipo_5B
{
    partial class frmAgregarImagen
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
            this.pbxAgregarImagen = new System.Windows.Forms.PictureBox();
            this.txtCargarImagen = new System.Windows.Forms.TextBox();
            this.btnImagenLocal = new System.Windows.Forms.Button();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.btnCancelarEliminacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAgregarImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxAgregarImagen
            // 
            this.pbxAgregarImagen.Location = new System.Drawing.Point(47, 26);
            this.pbxAgregarImagen.Name = "pbxAgregarImagen";
            this.pbxAgregarImagen.Size = new System.Drawing.Size(379, 239);
            this.pbxAgregarImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAgregarImagen.TabIndex = 0;
            this.pbxAgregarImagen.TabStop = false;
            // 
            // txtCargarImagen
            // 
            this.txtCargarImagen.Location = new System.Drawing.Point(47, 355);
            this.txtCargarImagen.Name = "txtCargarImagen";
            this.txtCargarImagen.Size = new System.Drawing.Size(340, 20);
            this.txtCargarImagen.TabIndex = 1;
            this.txtCargarImagen.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnImagenLocal
            // 
            this.btnImagenLocal.Location = new System.Drawing.Point(396, 355);
            this.btnImagenLocal.Name = "btnImagenLocal";
            this.btnImagenLocal.Size = new System.Drawing.Size(30, 20);
            this.btnImagenLocal.TabIndex = 2;
            this.btnImagenLocal.Text = "+";
            this.btnImagenLocal.UseVisualStyleBackColor = true;
            this.btnImagenLocal.Click += new System.EventHandler(this.btnImagenLocal_Click);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(47, 398);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarImagen.TabIndex = 3;
            this.btnAgregarImagen.Text = "Agregar";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // btnCancelarEliminacion
            // 
            this.btnCancelarEliminacion.Location = new System.Drawing.Point(351, 398);
            this.btnCancelarEliminacion.Name = "btnCancelarEliminacion";
            this.btnCancelarEliminacion.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarEliminacion.TabIndex = 4;
            this.btnCancelarEliminacion.Text = "Cancelar";
            this.btnCancelarEliminacion.UseVisualStyleBackColor = true;
            this.btnCancelarEliminacion.Click += new System.EventHandler(this.btnCancelarEliminacion_Click);
            // 
            // frmAgregarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 450);
            this.Controls.Add(this.btnCancelarEliminacion);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.btnImagenLocal);
            this.Controls.Add(this.txtCargarImagen);
            this.Controls.Add(this.pbxAgregarImagen);
            this.Name = "frmAgregarImagen";
            this.Text = "Agregar imagen";
            this.Load += new System.EventHandler(this.frmAgregarImagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAgregarImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAgregarImagen;
        private System.Windows.Forms.TextBox txtCargarImagen;
        private System.Windows.Forms.Button btnImagenLocal;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Button btnCancelarEliminacion;
    }
}