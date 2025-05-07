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
using System.IO;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPWinForm_equipo_5B
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        private OpenFileDialog archivo = null;

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
            txtCodArt.Enabled = false;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Imagenes imagenes = new Imagenes();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodArt.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text) ||string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Faltan uno o mas campos");
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("El precio solo admite números");
                    return;
                }
                if (articulo == null)
                    articulo = new Articulo();
                articulo.codigo = txtCodArt.Text;
                articulo.nombre = txtNombre.Text;
                articulo.descripcion = txtDescripcion.Text;
                articulo.precio = decimal.Parse(txtPrecio.Text);
                articulo.marca = (Marca)cboMarca.SelectedItem;
                articulo.categoria = (Categoria)cboCategoria.SelectedItem;
                imagenes.url = txtUrlImagen.Text;
                Imagenes imagenSeleccionada = (Imagenes)cmbCambioImagen.SelectedItem;
                if(articulo.precio <=0)
                {
                    MessageBox.Show("El precio debe ser mayor a cero");
                    return;
                }
                if (articulo.idArticulo != 0)
                {
                    articuloNegocio.modificar(articulo);
                    imagenNegocio.modificar(imagenSeleccionada.idImagen,txtUrlImagen.Text);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    if (articuloNegocio.BuscarArticulo(articulo.codigo) == true)
                    {
                        MessageBox.Show("El codigo ya  existe");
                        return;
                    }
                    articuloNegocio.agregar(articulo);
                    imagenNegocio.agregar(imagenes, 0);
                    MessageBox.Show("Agregado exitosamente");
                }
                if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, "C:\\PROGRA3-APP-ARTICULOS\\" + archivo.SafeFileName);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
                Close();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {   
            if (articulo == null)
            {
                cmbCambioImagen.Enabled = false;
                lblSeleccion.Enabled = false;
                cmbCambioImagen.Visible = false;
                lblSeleccion.Visible = false;
            }
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;// busque como setearlo manual porque no econtre la propiedad
            cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;// busque como setearlo manual porque no econtre la propiedad
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.ListarMarcas();
                cboMarca.ValueMember = "idMarca";
                cboMarca.DisplayMember = "descripcion";
                cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
                cboCategoria.ValueMember = "idCategoria";
                cboCategoria.DisplayMember = "descripcion";

                if (articulo != null)
                {
                    txtNombre.Text = articulo.nombre;
                    txtPrecio.Text = articulo.precio.ToString();
                    txtCodArt.Text = articulo.codigo;
                    txtDescripcion.Text = articulo.descripcion;
                    cboCategoria.SelectedValue = articulo.categoria.idCategoria;
                    cboMarca.SelectedValue = articulo.marca.idMarca;
                    foreach (Imagenes imagen in articulo.imagenes)
                    {
                        cmbCambioImagen.Items.Add(imagen);
                    }
                    if (articulo.imagenes.Count > 0)
                    {
                        cmbCambioImagen.SelectedItem = articulo.imagenes[0];
                        txtUrlImagen.Text = articulo.imagenes[0].url;
                        cargarImagen(articulo.imagenes[0].url);
                    }
                    else
                    {
                        txtUrlImagen.Text = "";
                        cargarImagen("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxCargaImagenArt.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxCargaImagenArt.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }
        }

        private void cmbCambioImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCambioImagen.SelectedItem != null)
                {
                    Imagenes imagenSeleccionada = (Imagenes)cmbCambioImagen.SelectedItem;
                    cargarImagen(imagenSeleccionada.url);
                    txtUrlImagen.Text = imagenSeleccionada.url;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar imagen: " + ex.Message);
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog archivo = new OpenFileDialog();
                archivo.Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    txtUrlImagen.Text = archivo.FileName;
                    cargarImagen(archivo.FileName);
                    string ruta = "C:\\PROGRA3-APP-ARTICULOS\\";
                    if (!Directory.Exists(ruta))
                    {
                        Directory.CreateDirectory(ruta);
                    }
                    File.Copy(archivo.FileName, ruta + archivo.SafeFileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al seleccionar imagen: " + ex.Message); ;
            }
            
        }
    }
}
