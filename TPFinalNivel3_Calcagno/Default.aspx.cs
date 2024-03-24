using dominio;
using System;
using System.Web.UI;
using negocio;

namespace TPFinalNivel3_Calcagno
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Main.aspx", false);
            }
            else
            {
                Session.Clear();
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                //Validacion de campos en este nivel
                if (Validaciones.validaTextoVacio(txtEmail) || Validaciones.validaTextoVacio(txtPassword))
                {
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx", false);
                }

                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPassword.Text;

                //Inicio de sesion o error
                if (negocio.Login(usuario))
                {
                   Session.Add("usuario", usuario);
                   Response.Redirect("Main.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}