<%@ Page Title="Confirmar E-Mail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Confirmacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Confirmar usuario</h2>
            <div class="row">
            <label class="form-label">Hemos enviado un código de confirmación a <%Response.Write(Email);%></label>

                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>

        <div class="col-6">
        <div class="col-6">
        <div class="form-floating mb-3" placeholder="Código">

        <asp:TextBox ID="codigo" runat="server" Cssclass="form-control" REQUIRED="1" placeholder="Introducir Código" TextMode="Number" MaxLength="5"/>
        <label for="floatingcodigo" cssclass="form-control">Introducir Código
        <asp:CustomValidator runat="server" id="CustomConfirmarRegistro" ControlToValidate="codigo" 
         onservervalidate="CustomConfirmarRegistro_ServerValidate"   
         ErrorMessage="El código es incorrecto" ForeColor="red"></asp:CustomValidator>
</label>
</div>
</div>


        <div class="mb-3">
        <asp:Button Text="Reenviar codigo"  cssclass="btn btn-dark" ID="btnEnviarCorreo" OnClick="btnEnviarCorreo_Click" runat="server" CausesValidation="false" UseSubmitBehavior="false"/>
        </div>
       <div class="mb-3">
       <asp:Button Text="Confirmar"  cssclass="btn btn-primary" ID="btnConfirmarRegistro" OnClick="btnConfirmarRegistro_Click" runat="server"/>
        </div>

        </ContentTemplate>
            </asp:UpdatePanel>

        </div>
</div>
     </section>
</main>


</asp:Content>
