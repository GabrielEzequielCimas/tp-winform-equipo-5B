using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPWinForm_equipo_5B
{
    public partial class frmMarcasCategorias : Form
    {
        public frmMarcasCategorias()
        {
            InitializeComponent();
        }

        private void frmMarcasCategorias_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            cboMarca.DataSource = marcaNegocio.ListarMarcas();
            cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
        } 

        private void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Marca seleccionado;
            try
            {
                DialogResult = MessageBox.Show("¿Seguro quiere eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    seleccionado = (Marca)cboMarca.SelectedItem;
                    negocio.eliminarMarca(seleccionado.idMarca);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                DialogResult = MessageBox.Show("¿Seguro quiere agregarlo?", "Agregando", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    if (negocio.BuscarMarca(txtAgregarMarca.Text) == true)
                    {
                        MessageBox.Show("La marca ya existe");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtAgregarMarca.Text))
                    {
                        MessageBox.Show("Debe poner una marca");
                        return;
                    }
                    negocio.agregarMarca(txtAgregarMarca.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                DialogResult = MessageBox.Show("¿Seguro quiere agregarlo?", "Agregando", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    if (negocio.BuscarCategoria(txtAgregarCategoria.Text) == true)
                    {
                        MessageBox.Show("La cartegoria ya existe");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtAgregarCategoria.Text))
                    {
                        MessageBox.Show("Debe poner una cartegoria");
                        return;
                    }
                    negocio.agregarCategoria(txtAgregarCategoria.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria seleccionado;
            try
            {
                DialogResult = MessageBox.Show("¿Seguro quiere eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    seleccionado = (Categoria)cboCategoria.SelectedItem;
                    negocio.eliminarCategoria(seleccionado.idCategoria);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
