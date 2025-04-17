using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPWinForm_equipo_5B
{
    internal class Articulo
    {
        public int idArticulo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public Imagenes imagen { get; set; }
        public float precio { get; set; }
    }
}
