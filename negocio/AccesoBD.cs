using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class AccesoBD

    {
        //Creacion de Variables para conexion a la BD
        private SqlConnection conexionbd;
        private SqlCommand comando;
        private SqlDataReader lector;

        //Como lector (SqlDataReader) es private creamos variable "Lectorbd" public que devuelve la variable lector
        public SqlDataReader Lectorbd
        {
            get { return lector; }
        }

        //Acceso a los datos y set de la conexion con bd
        //El server es tomado de una appseting
        public AccesoBD()
        {

            conexionbd = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            //Configuration server = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //conexionbd = new SqlConnection("server=" + server.AppSettings.Settings["server"].Value + "; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        //Constructor que recibe la consulta a la BD
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Metodo que ejecuta la lectura sobre la bd
        public void ejecutarLectura()
        {
            comando.Connection = conexionbd;
            try
            {
                conexionbd.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Este metodo recibe dos strings y las devuelve como parametros
        public void setearParametro(string nombre, object valor)
            {
                comando.Parameters.AddWithValue(nombre, valor);
            }

        //Este metodo recibe el nombre de un procedimiento almacenado y lo setea
        public void setearProcedimiento(string pa)
        {

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = pa;

            //Esta linea sirve para setearle un parametro al stored procedure q vamos a llamar (no lo usamos en este caso)
            //Podriamos hacer un stored que pida un id
            //comando.Parameters.Add("@Id", SqlDbType.VarChar).Value = editar;

        }

        //Metodo para cerrar conexion con la bd
        public void cerrarConexion()
           {
                if (lector != null)
                    lector.Close();
                conexionbd.Close();
            }

        //Metodo que ejecuta la accion sobre la BD
        public void ejecutarAccion()
        {
            comando.Connection = conexionbd;
            try
            {
                conexionbd.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo que ejecuta la accion sobre la BD pero nos devuelve el indice editado
        public int ejecutarAccionconreturn()
        {
            comando.Connection = conexionbd;
            try
            {
                conexionbd.Open();
                comando.ExecuteScalar().ToString();


                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
