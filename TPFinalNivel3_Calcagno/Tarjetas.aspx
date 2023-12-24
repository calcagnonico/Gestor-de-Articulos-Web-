<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tarjetas.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

                                   <p></p>
 
            <div class="row row-cols-1">
  <p></p>
        <asp:Repeater runat="server" id="repRepetidor">
            <ItemTemplate>
    <div class="card" style="width: 18rem;">
                               </p>
                            <div class="card-body">
                    <img src="<%#Eval("artimagen") %>" class="card-img-top" alt="..."/>
            </div>
                        <h5 class="card-title"><%#Eval("artnombre") %></h5>
                        <p class="card-text"><%#Eval("artdescripcion") %></p>
                        <a href="Articulo.aspx?id=<%#Eval("artid") %>" class="btn btn-primary" >Ver Detalle</a>
                                                 <p></p>
            </div>
            &nbsp; &nbsp;
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
