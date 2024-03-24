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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Usuario user = (Usuario)Session["usuario"];
                    if (user is null)
                    { }
                    else
                    {
                        if (Seguridad.esAdmin(user))
                            {
                            UsuarioNegocio negociouser = new UsuarioNegocio();
                            Session.Add("listausuarios", negociouser.listarusuarios(user.Id));
                            dgvlistaUsuarios.DataSource = Session["listausuarios"];
                            dgvlistaUsuarios.DataBind();
                            }
                        else
                        {
                            Response.Redirect("Main.aspx", false);
                        }
                    }
            }
            else
            {
            }
        }

        protected void dgvlistaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvlistaUsuarios.SelectedDataKey.Value.ToString();
            Response.Redirect("Perfil.aspx?idusuarioedicion=" + id);
        }


        protected void dgvlistaUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvlistaUsuarios.DataSource = Session["listausuarios"];
            dgvlistaUsuarios.PageIndex = e.NewPageIndex;
            dgvlistaUsuarios.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            List<Usuario> listaFiltrada = new List<Usuario>();

            if (txtFiltro.Text == "")
            {

                Usuario user = (Usuario)Session["usuario"];
                UsuarioNegocio negociouser = new UsuarioNegocio();
                Session.Add("listausuarios", negociouser.listarusuarios(user.Id));
                dgvlistaUsuarios.DataSource = Session["listaUsuarios"];
                dgvlistaUsuarios.DataBind();
            }

            else
            {
                //Estas dos lineas son para que la lista se cargue completa antes de filtrar
                //Pq si fiiltramos primero, y despues volvemos a escribir va a filtrar sobre la lista ya filtrada al principio
                UsuarioNegocio negociouser = new UsuarioNegocio();
                Usuario user = (Usuario)Session["usuario"];
                lista = negociouser.listarusuarios(user.Id);

                switch (CriterioFRapido.SelectedIndex)
                {
                    case 0:
                        listaFiltrada = lista.FindAll(x => x.Email.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                        break;
                    case 1:
                        listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                        break;
                    case 2:
                        listaFiltrada = lista.FindAll(x => x.Apellido.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                        break;
                    default:
                        break;
                }
                dgvlistaUsuarios.DataSource = listaFiltrada;
                Session.Add("listausuarios", listaFiltrada);
                dgvlistaUsuarios.DataBind();
            }
        }


        protected void dgvlistaUsuarios_Sorting(object sender, GridViewSortEventArgs e)
        {

            List<Usuario> listaordenada = (List<Usuario>)Session["listausuarios"];
            string sortexp = e.SortExpression.ToString();

            if (listaordenada.SequenceEqual(listaordenada.OrderBy(x => x.GetType().GetProperty(sortexp).GetValue(x, null))))
                listaordenada = listaordenada.OrderByDescending(x => x.GetType().GetProperty(sortexp).GetValue(x, null)).ToList();
            else
                listaordenada = listaordenada.OrderBy(x => x.GetType().GetProperty(sortexp).GetValue(x, null)).ToList();

            Session.Add("listausuarios", listaordenada);
            dgvlistaUsuarios.DataSource = Session["listausuarios"];
            dgvlistaUsuarios.DataBind();
        }
    }
}