<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Iniciar Sesion</h2>
     </section>
        
       <div class="row">
        <div class="col-md-4">

        <div class="form-floating mb-3" placeholder="usuario@email.com">
        <asp:TextBox ID="txtEmail" runat="server" Cssclass="form-control" REQUIRED="1" placeholder="usuario@email.com"/>
        <label for="floatingEmail" cssclass="form-control">E-Mail
        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ErrorMessage="Campo Inválido" runat="server" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"  ForeColor="Red" 
        Type="Integer" Enabled="True" Display="Dynamic"/>
        </label>
        </div>

        <div class="form-floating">
        <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword"  REQUIRED="1"  type="password" TextMode="Password" placeholder="Password"/>
        <label for="floatingPassword" cssclass="form-control">Contraseña</label>
        <p>
        </div>
        <p>

        <asp:Button Text="Ingresar" cssclass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server"/>
        <a href="Registro" class="btn btn-primary btn-md">Crear usuario &raquo;</a>
        </p>
       </div>
                   <div class="col-md-4">
                       <a href="https://maxiprograma.com//">
                       <img src="/Images/maxi-programa-banner.jpg" alt="Maxi Programa" height="200"/></a>
                    </div>

                     <div class="col-md-4">
                       <a href="https://maxiprograma.com//mim">
                       <img src="/Images/nivel-3.jpg" alt="Maxi Programa" height="200"/></a>
                    </div>
      </div>
    </main>

</asp:Content>
