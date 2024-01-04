using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPFinalNivel3_Calcagno
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                Response.Redirect("Default.aspx", false);
                else
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Usuario user = (Usuario)Session["usuario"];
                    Session.Add("listaFavoritos", negocio.listarConSPFavoritos(user.Id));
                    dgvlistaArticulos.DataSource = Session["listaFavoritos"];
                    dgvlistaArticulos.DataBind();
                }

            }
        }


        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaFavoritos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.artnombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvlistaArticulos.DataSource = listaFiltrada;
            dgvlistaArticulos.DataBind();
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
                ArticuloNegocio negocio = new ArticuloNegocio();
                //dgvlistaArticulos.DataSource = negocio.filtrar(
                //ddlCampo.SelectedItem.ToString(),
                //ddlCriterio.SelectedItem.ToString(),
                //txtFiltroAvanzado.Text,
                //ddlEstado.SelectedItem.ToString(),
                //DropDownMarca.SelectedItem.ToString(),
                //DropDownCategoria.SelectedItem.ToString()
                //);




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
            dgvlistaArticulos.DataSource = Session["listaFavoritos"];
            dgvlistaArticulos.PageIndex = e.NewPageIndex;
            dgvlistaArticulos.DataBind();
        }

    }
}