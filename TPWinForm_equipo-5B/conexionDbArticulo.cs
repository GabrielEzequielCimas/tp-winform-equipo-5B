using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace TPWinForm_equipo_5B
{
    internal class conexionDbArticulo
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = conexion.CreateCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select a.Id, Codigo, Nombre, a.Descripcion, M.Descripcion as marca, a.IdCategoria, C.Descripcion as categoria, Precio from ARTICULOS A left join MARCAS M on a.IdMarca = M.Id left join CATEGORIAS C on A.IdCategoria = c.Id;";
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.codigo = (string)lector["Codigo"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.categoria = new Categoria();
                    if (!(lector.IsDBNull(lector.GetOrdinal("Categoria"))))
                        aux.categoria.descripcion = (string)lector["Categoria"];
                    else aux.categoria.descripcion = "";
                        aux.marca = new Marca();
                    aux.marca.descripcion = (string)lector["Marca"];
                    aux.descripcion = (string)lector["Descripcion"];
                    aux.precio = (decimal)lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conexion.Close(); }
        }
    }
}
