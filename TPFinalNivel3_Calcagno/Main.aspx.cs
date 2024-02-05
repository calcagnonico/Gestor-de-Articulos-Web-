using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Ajax.Utilities;
using System.Collections;
using System.Drawing;

namespace TPFinalNivel3_Calcagno
{
    public partial class Main : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user is null)
                { }
                else
                {       
                ArticuloNegocio negocio0 = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio0.listarConSP(0, user.Id));
                dgvlistaArticulos.DataSource = Session["listaArticulos"];
                dgvlistaArticulos.DataBind();
                }

                CategoriaNegocio negocio = new CategoriaNegocio();
                MarcaNegocio negocio2 = new MarcaNegocio();

                List<Categoria> listacategorias = negocio.listar();
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
                dgvlistaArticulos.DataSource = Session["listaArticulos"];
                dgvlistaArticulos.DataBind();
            }

        else
        {
                switch (CriterioFRapido.SelectedIndex)
            {
                case 0:
                    listaFiltrada = lista.FindAll(x => x.artnombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    break;
                case 1:
                    listaFiltrada = lista.FindAll(x => x.artcodigo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    break;
                default:
                    break;
            }
            dgvlistaArticulos.DataSource = listaFiltrada;
            Session.Add("listaArticulos", listaFiltrada);
            dgvlistaArticulos.DataBind();
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
                    dgvlistaArticulos.DataSource = negocio.filtrar(
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

                Session.Add("listaArticulos", dgvlistaArticulos.DataSource);
                dgvlistaArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void dgvlistaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvlistaArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Articulo.aspx?id=" + id);
        }

        protected void dgvlistaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgvlistaArticulos.DataSource = Session["listaArticulos"];
            dgvlistaArticulos.PageIndex = e.NewPageIndex;
            dgvlistaArticulos.DataBind();
        }

        protected void TipodeFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listarConSP(0, user.Id));
            dgvlistaArticulos.DataSource = Session["listaArticulos"];
            dgvlistaArticulos.DataBind();


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
            dgvlistaArticulos.DataSource = Session["listaArticulos"];
            dgvlistaArticulos.DataBind();
        }

        protected void dgvlistaArticulos_Sorting(object sender, GridViewSortEventArgs e)
        {

            List<Articulo> listaordenada = (List<Articulo>)Session["listaArticulos"];
            string sortexp = e.SortExpression.ToString();

            switch (sortexp)
            {
                case "artmarca":
                    if (listaordenada.SequenceEqual(listaordenada.OrderBy(x => x.artmarca.Descripcion)))
                    listaordenada = listaordenada.OrderByDescending(x => x.artmarca.Descripcion).ToList();
                    else
                    listaordenada = listaordenada.OrderBy(x => x.artmarca.Descripcion).ToList();
                    break;

                case "artcategoria":
                    if (listaordenada.SequenceEqual(listaordenada.OrderBy(x => x.artcategoria.Descripcion)))
                        listaordenada = listaordenada.OrderByDescending(x => x.artcategoria.Descripcion).ToList();
                    else
                        listaordenada = listaordenada.OrderBy(x => x.artcategoria.Descripcion).ToList();
                    break;
                default:
                    if (listaordenada.SequenceEqual(listaordenada.OrderBy(x => x.GetType().GetProperty(sortexp).GetValue(x, null))))
                        listaordenada = listaordenada.OrderByDescending(x => x.GetType().GetProperty(sortexp).GetValue(x, null)).ToList();
                    else
                        listaordenada = listaordenada.OrderBy(x => x.GetType().GetProperty(sortexp).GetValue(x, null)).ToList();
                    break;
            }

            Session.Add("listaArticulos", listaordenada);
            dgvlistaArticulos.DataSource = Session["listaArticulos"];
            dgvlistaArticulos.DataBind();
        }

    }
}
