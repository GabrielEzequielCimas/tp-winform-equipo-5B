using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;
using System.IO;

namespace TPWinForm_equipo_5B
{
    
    public partial class frmAgregarImagen : Form
    {
        private OpenFileDialog archivo = null;
        private Articulo articuloSeleccionado;

        public frmAgregarImagen(Articulo articulo)
        {
            InitializeComponent();
            articuloSeleccionado = articulo;
        }
        private void cargarImagenes(string imagen)
        {
            try
            {
                pbxAgregarImagen.Load(imagen);
            }
            catch (Exception)
            {

                pbxAgregarImagen.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }
        }
        public frmAgregarImagen()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            try
            {
                cargarImagenes(txtCargarImagen.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelarEliminacion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAgregarImagen_Load(object sender, EventArgs e)
        {
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            Imagenes imagen = new Imagenes();
            imagen.url = txtCargarImagen.Text;
            try
            {
                if (archivo != null && !(txtCargarImagen.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, "C:\\PROGRA3-APP-ARTICULOS\\" + archivo.SafeFileName);
                }
                negocio.agregar(imagen, articuloSeleccionado.idArticulo);
                MessageBox.Show("Imagen agregada correctamente");
                Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnImagenLocal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog archivo = new OpenFileDialog();
                archivo.Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    txtCargarImagen.Text = archivo.FileName;
                    cargarImagenes(archivo.FileName);
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
