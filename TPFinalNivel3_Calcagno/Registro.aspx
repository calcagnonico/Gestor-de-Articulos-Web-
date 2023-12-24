<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Registro" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Crea tu perfil</h2>
     </section>
    <div class="row">
        <div class="col-4">

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail"/>
            </div>

            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" TextMode="Password"/>
            </div>

            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtNombre"/>
            </div>



            <asp:Button Text="Registrarse" cssclass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="Default" class="btn btn-primary btn-md">Salir</a>
        </div>
    </div>
    </main>


</asp:Content>
