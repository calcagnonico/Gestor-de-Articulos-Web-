using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Calcagno
{



    public partial class WebForm4 : System.Web.UI.Page
    {

        public bool BAgregarCategoria = false;
        public bool BEditarCategoria = false;
        public bool BEliminarCategoria = false;

        public bool BAgregarMarca = false;
        public bool BEditarMarca = false;
        public bool BEliminarMarca = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user is null)
                { }
                else
                {
                    cargarmarcas();
                    cargarcategorias();
                    UsuarioNegocio negociouser = new UsuarioNegocio();
                }
            }

        }

        //Botones Primarios (Solo muestran los demas controles)
        protected void AgregarCategoria_Click(object sender, EventArgs e)
        {
            ActivarOpcion(1);
        }
        protected void EditarCategoria_Click(object sender, EventArgs e)
        {
            if (ListaCategorias.SelectedItem != null)
            {
                ActivarOpcion(2);
                TxtEditarCategoria.Text = ListaCategorias.SelectedItem.Text;
            }
        }
        protected void EliminarCategoria_Click(object sender, EventArgs e)
        {
            if (ListaCategorias.SelectedItem != null)
            {
                ActivarOpcion(3);
            }
        }
        protected void AgregarMarca_Click(object sender, EventArgs e)
        {
            ActivarOpcion(4);
        }
        protected void EditarMarca_Click(object sender, EventArgs e)
        {

            if (ListaMarcas.SelectedItem != null)
            {
                ActivarOpcion(5);
                TxtEditarMarca.Text = ListaMarcas.SelectedItem.Text;
            }


        }
        protected void EliminarMarca_Click(object sender, EventArgs e)
        {
            if (ListaMarcas.SelectedItem != null)
            {
                ActivarOpcion(6);
            }
        }


        /////////Metodo para mostrar u ocultar controles segun el boton apretado
        public void ActivarOpcion(int IdEdicion)
        {
            switch (IdEdicion)
            {
                case 1:
                    BAgregarCategoria = true;
                    BEditarCategoria = false;
                    BEliminarCategoria = false;
                    BAgregarMarca = false;
                    BEditarMarca = false;
                    BEliminarMarca = false;
                    break;

                case 2:
                    BAgregarCategoria = false;
                    BEditarCategoria = true;
                    BEliminarCategoria = false;
                    BAgregarMarca = false;
                    BEditarMarca = false;
                    BEliminarMarca = false;
                    break;

                case 3:
                    BAgregarCategoria = false;
                    BEditarCategoria = false;
                    BEliminarCategoria = true;
                    BAgregarMarca = false;
                    BEditarMarca = false;
                    BEliminarMarca = false;
                    break;

                case 4:
                    BAgregarCategoria = false;
                    BEditarCategoria = false;
                    BEliminarCategoria = false;
                    BAgregarMarca = true;
                    BEditarMarca = false;
                    BEliminarMarca = false;
                    break;


                case 5:
                    BAgregarCategoria = false;
                    BEditarCategoria = false;
                    BEliminarCategoria = false;
                    BAgregarMarca = false;
                    BEditarMarca = true;
                    BEliminarMarca = false;
                    break;

                case 6:
                    BAgregarCategoria = false;
                    BEditarCategoria = false;
                    BEliminarCategoria = false;
                    BAgregarMarca = false;
                    BEditarMarca = false;
                    BEliminarMarca = true;
                    break;
                default:
                    BAgregarCategoria = false;
                    BEditarCategoria = false;
                    BEliminarCategoria = false;
                    BAgregarMarca = false;
                    BEditarMarca = false;
                    BEliminarMarca = false;
                    break;
            }
        }


        ///////Botones de confirmacion (3er Columna) que borran/editan los elementos de la bd
        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (TxtAgregarMarca.Text != "Soy Maxi haceme admin")
            {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            articulonegocio.AgregarMarca(TxtAgregarMarca.Text);
            ListaMarcas.Items.Clear();
            cargarmarcas();
            }
            else
            {
                bool maxi = true;
                Session.Add("maxi", maxi);
                Response.Redirect("MaxAdmin.aspx", false);
            }
        }

        protected void btnEditarMarca_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            int id = Convert.ToInt32(ListaMarcas.SelectedItem.Value);
            articulonegocio.EditarMarca(id, TxtEditarMarca.Text);
            ListaMarcas.Items.Clear();
            cargarmarcas();
        }

        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (ListaMarcas.SelectedItem != null)
            {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            int id = Convert.ToInt32(ListaMarcas.SelectedItem.Value);
            articulonegocio.EliminarMarca(id);
            ListaMarcas.Items.Clear();
            cargarmarcas();
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            articulonegocio.AgregarCategoria(TxtAgregarCategoria.Text);
            ListaCategorias.Items.Clear();
            cargarcategorias();
        }

        protected void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            int id = Convert.ToInt32(ListaCategorias.SelectedItem.Value);
            articulonegocio.EditarCategoria(id, TxtEditarCategoria.Text);
            ListaCategorias.Items.Clear();
            cargarcategorias();
        }

        protected void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulonegocio = new ArticuloNegocio();
            int id = Convert.ToInt32(ListaCategorias.SelectedItem.Value);
            articulonegocio.EliminarCategoria(id);
            ListaCategorias.Items.Clear();
            cargarcategorias();
        }


        protected void ListaCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarOpcion(default);
        }

        protected void ListaMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarOpcion(default);
        }



        public void cargarmarcas()
        {
            MarcaNegocio MarcaNegocio = new MarcaNegocio();
            List<Marca> lista = new List<Marca>();
            lista = MarcaNegocio.listarsin1();

            foreach (Marca item in lista)
            {
                var marcaaux = new ListItem();
                marcaaux.Value = item.Id.ToString();
                marcaaux.Text = item.Descripcion;
                ListaMarcas.Items.Add(marcaaux);
            }
            ListaMarcas.DataBind();
        }

        public void cargarcategorias()
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            List<Categoria> lista = new List<Categoria>();
            lista = CategoriaNegocio.listarsin1();

            foreach (Categoria item in lista)
            {
                var categoriaaux = new ListItem();
                categoriaaux.Value = item.Id.ToString();
                categoriaaux.Text = item.Descripcion;
                ListaCategorias.Items.Add(categoriaaux);
            }
            ListaCategorias.DataBind();
        }

    }

}


