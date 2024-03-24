<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaxAdmin.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <main aria-labelledby="title">

        <p></p>
        <h2 id="title"><%: Title %></h2>
                 <section class="row" aria-labelledby="aspnetTitle">
 
            <h2 id="aspnetTitle">Bienvenido Maxi</h2>
     </section>
        <div class="row">
        <div class="col-md-4">
        Hola Maxi, espero que te guste el trabajo, <br />
        Te mando un abrazo! <br />
        Nicolas<br />
        </div>

        </div>
<div class="col-md-4">
    <br />
     </div>

 <div class="col-md-4">
    <asp:Button Text="Haceme admin" CssClass="btn btn-dark" OnClick="btnAdmin_Click" ID="btnAdmin" runat="server" />
    <asp:Button Text="No soy Maxi" CssClass="btn btn-primary" OnClick="btnSalir_Click" ID="btnSalir" runat="server" />
     </div>
    </main>


</asp:Content>
