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

namespace TPWinForm_equipo_5B
{
    public partial class frmListarArticulos : Form
    {
        private List<Articulo> listaArticulo;
        public frmListarArticulos()
        {
            InitializeComponent();
        }

        private void frmListarArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cmbListaImagenes.Items.Clear();
            foreach (Imagenes imagen in seleccion.imagenes)
            {
                cmbListaImagenes.Items.Add(imagen);
            }
            if (seleccion.imagenes.Count > 0)
            {
                cmbListaImagenes.SelectedIndex = 0;//tengo q verificar accion si no tiene imagen 
                Imagenes imagenSeleccionada = (Imagenes)cmbListaImagenes.SelectedItem;
                cargarImagen(imagenSeleccionada.url);
            }
            else { cargarImagen(""); }  
        }


        private void cmbListaImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Imagenes imagenSeleccionada = (Imagenes)cmbListaImagenes.SelectedItem;
                cargarImagen(imagenSeleccionada.url);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cargar()
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            try
            {
                listaArticulo = articulo.Listar();
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.Columns["idArticulo"].Visible = false;
                //pbxListarArticulo.Load(listaArticulo[0].imagenes[0].url);
                //dgvArticulos.Columns["imagen"].Visible = false;
                //pbxArticulo.Load(lis) 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw ex;
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxListarArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxListarArticulo.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulo modificacion = new frmAltaArticulo(seleccionado);
            modificacion.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult = MessageBox.Show("¿Seguro quiere eliminarlo?","Eliminando",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado);
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
