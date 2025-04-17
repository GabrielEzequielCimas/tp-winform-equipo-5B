namespace tp_winform_equipo_5B
{
    partial class frmPrincipal
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
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.btnModificarArticulo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.btnListarArticulo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Location = new System.Drawing.Point(302, 163);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(128, 23);
            this.btnAgregarArticulo.TabIndex = 0;
            this.btnAgregarArticulo.Text = "Agregar artículo";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            // 
            // btnModificarArticulo
            // 
            this.btnModificarArticulo.Location = new System.Drawing.Point(302, 223);
            this.btnModificarArticulo.Name = "btnModificarArticulo";
            this.btnModificarArticulo.Size = new System.Drawing.Size(128, 23);
            this.btnModificarArticulo.TabIndex = 1;
            this.btnModificarArticulo.Text = "Modificar artículo";
            this.btnModificarArticulo.UseVisualStyleBackColor = true;
            this.btnModificarArticulo.Click += new System.EventHandler(this.btnModificarArticulo_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(302, 284);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Eliminar artículo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(302, 350);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(128, 23);
            this.btnVerDetalle.TabIndex = 3;
            this.btnVerDetalle.Text = "Ver detalle articulo";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(302, 106);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(128, 23);
            this.btnBusqueda.TabIndex = 4;
            this.btnBusqueda.Text = "Buscar articulo";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnListarArticulo
            // 
            this.btnListarArticulo.Location = new System.Drawing.Point(302, 53);
            this.btnListarArticulo.Name = "btnListarArticulo";
            this.btnListarArticulo.Size = new System.Drawing.Size(128, 23);
            this.btnListarArticulo.TabIndex = 5;
            this.btnListarArticulo.Text = "Listar articulos";
            this.btnListarArticulo.UseVisualStyleBackColor = true;
            this.btnListarArticulo.Click += new System.EventHandler(this.btnListarArticulo_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnListarArticulo);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnModificarArticulo);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnModificarArticulo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Button btnListarArticulo;
    }
}

