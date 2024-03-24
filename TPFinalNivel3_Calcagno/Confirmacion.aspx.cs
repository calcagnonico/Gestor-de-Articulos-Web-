﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Calcagno
{



    public partial class Confirmacion : System.Web.UI.Page
    {

        public string Email { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva((Usuario)Session["nuevousuario"]))
                    {
                        try
                        {
                            btnEnviarCorreo_Click(sender, new EventArgs());
                            Usuario user = new Usuario();
                            user = (Usuario)Session["nuevousuario"];
                            Email = user.Email;
                        }
                        catch (Exception ex)
                        {
                            Session.Add("error", ex.ToString());
                            Response.Redirect("Error.aspx");
                        }

                    }
                    else
                    {
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length >= 6)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        protected void CustomConfirmarRegistro_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int codigoint = Int32.Parse(codigo.Text);
                if (codigoint == (int)Session["codigoverificacion"])
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
                throw;
            }

        }
        protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {

                Usuario user = new Usuario();
                user = (Usuario)Session["nuevousuario"];
                EmailService emailService = new EmailService();
                int codigo = emailService.numrandom();
                Session.Add("codigoverificacion", codigo);


                //Create a request using a URL that can receive a post. 
                //  WebRequest request = WebRequest.Create("http://gestordearticulos.somee.com/Images/banner.png");

                // Set the Method property of the request to POST.
                //  request.Method = "GET";
                //  WebResponse response = null;
                // Get the response.
                //  try
                //  {
                //      response = request.GetResponse();
                //  }
                //  catch (Exception Ex)
                //  {
                //  }
                // Display the status.
                // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                //  Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                //   StreamReader reader = new StreamReader(dataStream);
                //path to save image
                //string ImagePath = HttpContext.Current.Server.MapPath("~/Images/") + "banner.jpg";//check your extension

                string ImagePath = HttpContext.Current.Server.MapPath("~/Images/");//check your extension

                //Save the image in your server
                //  using (Stream s = File.Create(ImagePath))
                //  {
                //      dataStream.CopyTo(s);
                //  }
                emailService.armarCorreo(user.Email, user.Nombre, codigo, ImagePath);
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
                throw ex;
            }
        }

        protected void btnConfirmarRegistro_Click(object sender, EventArgs e)
        {
            int codigoint = Int32.Parse(codigo.Text);
            if (codigoint == (int)Session["codigoverificacion"])
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario user = new Usuario();
                user = (Usuario)Session["nuevousuario"];
                user.Id = usuarioNegocio.insertarNuevo(user);
                Session.Clear();
                Session.Add("usuario", user);
                Response.Redirect("Default.aspx", false);
            }
            else
            {
            }
        }

    }
}