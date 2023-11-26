using dominio;
using System;
using System.Web.UI;
using negocio;

namespace TPFinalNivel3_Calcagno
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario trainee = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                if (Validaciones.validaTextoVacio(txtEmail) || Validaciones.validaTextoVacio(txtPassword))
                {
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx");
                }

                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;
                if (negocio.Login(trainee))
                {
                   // Session.Add("trainee", trainee);
                   // Response.Redirect("Main.aspx", false);

                    Session.Add("error", "Ingreso correcto..");
                    Response.Redirect("Error.aspx");

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