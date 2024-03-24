using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace TPFinalNivel3_Calcagno
{
    public partial class Registro : System.Web.UI.Page
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

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            try
            {
                Usuario user = new Usuario();
                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Nombre = txtNombre.Text;
                DateTime dateTime = DateTime.Now;
                user.FechaNacimiento = dateTime;
                user.Id = 1;
                if (UsuarioNegocio.chequearemailusuario(user.Email))
                {
                    Session.Add("nuevousuario", user);
                    Response.Redirect("Confirmacion.aspx", false);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void Validaemailexistente_ServerValidate(object source, ServerValidateEventArgs args)
        {
        UsuarioNegocio usuarionegocio = new UsuarioNegocio();
        args.IsValid = (usuarionegocio.chequearemailusuario(args.Value));
        }
    }

}