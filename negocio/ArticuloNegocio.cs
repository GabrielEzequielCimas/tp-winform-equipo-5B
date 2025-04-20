using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Imagenes> ListarImagenes(int idArticulo)
        {
            List<Imagenes> lista = new List<Imagenes>();
            ConexionDB imagenes = new ConexionDB();
            imagenes.setearConsulta("select ImagenUrl from Imagenes where IdArticulo = " + idArticulo + ";");
            imagenes.ejecutarLectura();
            try
            {
                int contador = 0;
                while (imagenes.Lector.Read())
                {
                    Imagenes aux = new Imagenes();
                    aux.url = (string)imagenes.Lector["ImagenUrl"];
                    aux.numeroImagen = contador += 1;
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("select a.Id, Codigo, Nombre, a.Descripcion, M.Descripcion as marca, a.IdCategoria, C.Descripcion as categoria, Precio from ARTICULOS A left join MARCAS M on a.IdMarca = M.Id left join CATEGORIAS C on A.IdCategoria = c.Id;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.idArticulo = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.categoria = new Categoria();
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Categoria"))))
                        aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    else aux.categoria.descripcion = "";
                    aux.marca = new Marca();
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.imagenes = ListarImagenes(aux.idArticulo);
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

