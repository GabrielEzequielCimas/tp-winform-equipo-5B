using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPWinForm_equipo_5B;

namespace tp_winform_equipo_5B
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnListarArticulo_Click(object sender, EventArgs e)
        {
            frmListarArticulos ventana = new frmListarArticulos();
            ventana.Show();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
