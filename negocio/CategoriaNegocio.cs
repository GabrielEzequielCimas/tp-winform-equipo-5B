using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            ConexionDB categorias = new ConexionDB();
            categorias.setearConsulta("select Id, Descripcion from Categorias;");
            categorias.ejecutarLectura();
            try
            {
                while (categorias.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.idCategoria = (int)categorias.Lector["Id"];
                    aux.descripcion = (string)categorias.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
