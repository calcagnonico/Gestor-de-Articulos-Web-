<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div aria-labelledby="title">
        <p></p>
        <h2 id="title"><%: Title %></h2>
        <address>
        <div class="row">
        <div class="col-md-4">
           <a href="mailto:calcagno.nico@gmail.com"> <img src="~/Images/email.jpg" id="Img2" runat="server" width="40"/></a>
           <a href="https://wa.me/5493415401404">  <img src="~/Images/whatsapp.jpg" id="Img1" runat="server" width="40"/></a>
           <a href="https://github.com/calcagnonico">  <img src="~/Images/github.jpg" id="github" runat="server" width="40"/></a>
           <a href="https://linkedin.com/in/nicolas-calcagno">  <img src="~/Images/linkedin.jpg" id="linkedin" runat="server" width="40"/></a>
        <br>
            Nicolás Calcagno<br />
            Rosario, Santa Fe, Argentina<br />
        </div>
</div> 
</address>
           </div>  
</asp:Content>
