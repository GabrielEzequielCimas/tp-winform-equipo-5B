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
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
                return;

            Articulo seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            if (seleccion == null || seleccion.imagenes == null)
                return;

            cmbListaImagenes.Items.Clear();

            foreach (Imagenes imagen in seleccion.imagenes)
            {
                cmbListaImagenes.Items.Add(imagen);
            }

            if (seleccion.imagenes.Count > 0)
            {
                cmbListaImagenes.SelectedIndex = 0;
                Imagenes imagenSeleccionada = (Imagenes)cmbListaImagenes.SelectedItem;
                cargarImagen(imagenSeleccionada.url);
            }
            else
            {
                cargarImagen("");
            }
        }


        private void cmbListaImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Imagenes imagenSeleccionada = (Imagenes)cmbListaImagenes.SelectedItem;
                cargarImagen(imagenSeleccionada.url);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); ;
            }
        }

        private void cargar()
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            try
            {
                dgvArticulos.SelectionChanged -= dgvArticulos_SelectionChanged; //Desconecta
                listaArticulo = articulo.Listar();
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.Columns["idArticulo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dgvArticulos.SelectionChanged += dgvArticulos_SelectionChanged; //Reconecta
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxListarArticulo.Load(imagen);
            }
            catch (Exception)
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
            try
            {   
                if (dgvArticulos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Tenés que seleccionar un artículo");
                    return;
                }
                Articulo seleccionado;
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo modificacion = new frmAltaArticulo(seleccionado);
                modificacion.ShowDialog();
                cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
        private bool soloNumeros(string cadena)
        {   foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter))) return false;
            }
            return true;
        }
        private bool validarFiltro()
        {
            if(cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un campo a filtrar");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un criterio a filtrar");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltro.Text))
                {
                    MessageBox.Show("Carga un numero en el filtro");
                    return true;
                }
                if (!(soloNumeros(txtFiltro.Text)))
                {
                    MessageBox.Show("Solo numero por favor");
                    return true;
                }
            }
            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro()) return;
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnEliminarImagen_Click_1(object sender, EventArgs e)
        {
            ImagenNegocio imgNegocio = new ImagenNegocio();
            Imagenes objImagenes = new Imagenes();
            try
            {
                if (cmbListaImagenes.SelectedItem != null)
                {
                    objImagenes = (Imagenes)cmbListaImagenes.SelectedItem;
                    DialogResult = MessageBox.Show("¿Seguro quiere eliminarla?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DialogResult == DialogResult.Yes)
                    {
                        imgNegocio.eliminar(objImagenes.idImagen);
                        MessageBox.Show("Imagen eliminada correctamente");
                        cargar();
                    }
                    else return;
                }
                else
                {
                    MessageBox.Show("El articulo no tiene imagenes");
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            frmAgregarImagen alta = new frmAgregarImagen((Articulo)dgvArticulos.CurrentRow.DataBoundItem);
            alta.ShowDialog();
            cargar();
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Listar();
                cargar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnMarcasCategorias_Click(object sender, EventArgs e)
        {
            frmMarcasCategorias alta = new frmMarcasCategorias();
            alta.ShowDialog();
            cargar();
        }
    }
}
