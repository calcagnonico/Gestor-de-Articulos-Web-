using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Calcagno
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public List<Articulo> dgvlistaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario user = (Usuario)Session["usuario"];
            if (user is null)
            { }
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSP(0, user.Id));
                dgvlistaArticulos = negocio.listarConSP(0, user.Id);

            }



            if (!IsPostBack)
            {
                repRepetidor.DataSource = dgvlistaArticulos;
                repRepetidor.DataBind();
                            CategoriaNegocio cnegocio = new CategoriaNegocio();
                MarcaNegocio negocio2 = new MarcaNegocio();

                List<Categoria> listacategorias = cnegocio.listar();
                List<Marca> listamarcas = negocio2.listar();

                DropDownCategoria.Items.Add(new ListItem("Todas"));
                foreach (Categoria categorias in listacategorias)
                {
                    DropDownCategoria.Items.Add(new ListItem(categorias.Descripcion.ToString()));
                }
                DropDownCategoria.DataBind();
                DropDownCategoria.SelectedIndex = 0;

                DropDownMarca.Items.Add(new ListItem("Todas"));
                foreach (Marca marcas in listamarcas)
                {
                    DropDownMarca.Items.Add(new ListItem(marcas.Descripcion.ToString()));
                }
                DropDownMarca.DataBind();
                DropDownMarca.SelectedIndex = 0;
            }

        }




        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = new List<Articulo>();

            if (txtFiltro.Text == "")
            {
                Usuario user = (Usuario)Session["usuario"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSP(0, user.Id));
                repRepetidor.DataSource = Session["listaArticulos"];
                repRepetidor.DataBind();
            }

            else
            {
                switch (CriterioFRapido.SelectedIndex)
                {
                    case 0:
                        listaFiltrada = lista.FindAll(x => x.artnombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                        break;
                    case 1:
                        listaFiltrada = lista.FindAll(x => x.artdescripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                        break;
                    default:
                        break;
                }
                repRepetidor.DataSource = listaFiltrada;
                Session.Add("listaArticulos", listaFiltrada);
                repRepetidor.DataBind();
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario user = (Usuario)Session["usuario"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                repRepetidor.DataSource = negocio.filtrar(
                ddlCampo.SelectedItem.ToString(),
                ddlCriterio.SelectedItem.ToString(),
                txtFiltroAvanzado.Text,
                ddlEstado.SelectedItem.ToString(),
                DropDownMarca.SelectedItem.ToString(),
                DropDownCategoria.SelectedItem.ToString(),
                Precioentre.Text,
                Preciohasta.Text,
                user.Id, Favoritos.SelectedItem.ToString()
                );

                Session.Add("listaArticulos", repRepetidor.DataSource);
                repRepetidor.DataBind();


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }


        protected void TipodeFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listarConSP(0, user.Id));
            repRepetidor.DataSource = Session["listaArticulos"];
            repRepetidor.DataBind();


            if (TipodeFiltro.SelectedItem.Text == "Avanzado")
            {
                txtFiltro.Enabled = false;
                CriterioFRapido.Enabled = false;

                //REVISAR ESTO SI PUEDO LLAMAR AL EVENTO
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedItem.ToString() == "Número")
                {
                    ddlCriterio.Items.Add("Igual a");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                }
                else
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                }

            }
            else
            {
                txtFiltro.Enabled = true;
                CriterioFRapido.Enabled = true;
            }

            txtFiltro.Text = "";

        }

        protected void CriterioFRapido_SelectedIndexChanged(object sender, EventArgs e)
        {
                Usuario user = (Usuario)Session["usuario"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSP(0, user.Id));
                dgvlistaArticulos = negocio.listarConSP(0, user.Id);
                repRepetidor.DataSource = dgvlistaArticulos;
                repRepetidor.DataBind();
        }
    }
}