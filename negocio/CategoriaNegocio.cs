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

        public List<Categoria> listar()
        {

            //Creamos Lista de tipo categoria
            List<Categoria> lista = new List<Categoria>();

            //Creamos la variable datos de tipo AccesoBD
            AccesoBD datos = new AccesoBD();

            try
            {

            //A traves de la variable "datos" de tipo "AccesoBD" llamamos a sus metodos para enviar la consulta sql y la ejecutamos
            datos.setearConsulta("Select Id, Descripcion from CATEGORIAS");
            datos.ejecutarLectura();
            
                //Por medio de un ciclo cargamos los datos que traemos de la bd y los vamos agregando a la lista
                while (datos.Lectorbd.Read())
                {
                    Categoria aux = new Categoria();

                    aux.Id = (int)datos.Lectorbd["Id"];
                    aux.Descripcion = (string)datos.Lectorbd["Descripcion"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
