using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.ComponentModel;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;



namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;


        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("calcagno.nico.dev@gmail.com", "reai ktqe bqmk aame");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }


        public void armarCorreo(string emailDestino, string nombre, int codigo, string path)
        {

            try
            {
                
                email = new MailMessage();
                email.From = new MailAddress("noresponder@gestordearticulos.com");
                email.To.Add(emailDestino);
                email.Subject = nombre + " Confirme su e-mail";
                email.IsBodyHtml = true;

                Attachment inline = new Attachment(path + "banner.jpg");
                inline.ContentDisposition.Inline = true;
                inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                inline.ContentType.MediaType = "image/png";
                inline.ContentType.Name = Path.GetFileName(path);
                email.Attachments.Add(inline);

                Attachment mail1 = new Attachment(path + "email.jpg");
                mail1.ContentDisposition.Inline = true;
                mail1.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                mail1.ContentType.MediaType = "image/png";
                mail1.ContentType.Name = Path.GetFileName(path);
                email.Attachments.Add(mail1);

                Attachment whatsapp = new Attachment(path + "whatsapp.jpg");
                whatsapp.ContentDisposition.Inline = true;
                whatsapp.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                whatsapp.ContentType.MediaType = "image/png";
                whatsapp.ContentType.Name = Path.GetFileName(path);
                email.Attachments.Add(whatsapp);

                Attachment github = new Attachment(path + "github.jpg");
                github.ContentDisposition.Inline = true;
                github.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                github.ContentType.MediaType = "image/png";
                github.ContentType.Name = Path.GetFileName(path);
                email.Attachments.Add(github);

                Attachment linkedin = new Attachment(path + "linkedin.jpg");
                linkedin.ContentDisposition.Inline = true;
                linkedin.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                linkedin.ContentType.MediaType = "image/png";
                linkedin.ContentType.Name = Path.GetFileName(path);
                email.Attachments.Add(linkedin);

                email.Body =
                    "<center>\r\n" +
                    @"<img src='cid:" + inline.ContentId + @"'/>" +
                "<br>\r\n" +
                    "<br>\r\n" +
                    "<h2>Bienvenido " + nombre + "</h2>\r\n" +
                    "Su código de registro es:\r\n" +
                    "<br>\r\n\r\n" +
                    codigo +
                    "<br>\r\n" +
                     "<h2> </h2>\r\n" +
                    "<div class=\"row\">\r\n" +
                    "</div>" +
                    "<div class=\"row\">\r\n" +
                    "<div class=\"col-md-4\">\r\n" +
                    "<a href=\"mailto:calcagno.nico@gmail.com\">          <img src='cid:" + mail1.ContentId     +  "'id=\"Img2\" runat=\"server\" width=\"40\"/></a>\r\n" +
                    "<a href=\"https://wa.me/5493415401404\">             <img src='cid:" + whatsapp.ContentId  +  "'id=\"Img1\" runat=\"server\" width=\"40\"/></a>\r\n" +
                    "<a href=\"https://github.com/calcagnonico\">         <img src='cid:" + github.ContentId    +  "'id=\"github\" runat=\"server\" width=\"40\"/></a>\r\n" +
                    "<a href=\"https://linkedin.com/in/nicolas-calcagno\"><img src='cid:" + linkedin.ContentId  +  "'id=\"linkedin\" runat=\"server\" width=\"40\"/></a>\r\n" +
                    "</br>" +
                    "<br>" +
                    "\r\n Creado por Nicolás Calcagno<br />\r\n" +
                    "</div>" +
                    "</center>"
                    ;
            }
            catch (Exception ex)
            {
         
            }
           
        }

        public int numrandom()
        {
            int min = 00000;
            int max = 99999;
            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
