using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            ConexionDB marcas = new ConexionDB();
            marcas.setearConsulta("select Id,Descripcion from marcas;");
            marcas.ejecutarLectura();
            try
            {
                while (marcas.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.idMarca = (int)marcas.Lector["Id"];
                    aux.descripcion = (string)marcas.Lector["Descripcion"];
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
