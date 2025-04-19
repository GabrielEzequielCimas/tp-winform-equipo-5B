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
            conexionDbArticulo articulo = new conexionDbArticulo();
            try
            {
                listaArticulo = articulo.Listar();
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.Columns["idArticulo"].Visible = false;
                dgvArticulos.Columns["imagen"].Visible = false;
                //pbxArticulo.Load(lis)
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                throw ex;
            }
            
        }
    }
}
