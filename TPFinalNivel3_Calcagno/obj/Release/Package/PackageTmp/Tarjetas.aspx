<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tarjetas.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <script>
// Funcion q muestra la imagen de error si la ruta no esta correcta
     function imgError(me) {
         var AlterNativeImg = "/Images/error.jpeg";    
         if (AlterNativeImg != me.src)
             me.src = AlterNativeImg;
     }
     </script>   

     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Gestionar Articulos</h2>
     </section>

                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

      

    <div class="row">
        <div class="col-8">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
         </div>

         <div class="col-2">
                    <asp:Label Text="Criterio:" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="CriterioFRapido" OnSelectedIndexChanged="CriterioFRapido_SelectedIndexChanged" DataTextField="Seleccione">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Descripcion" />
                    </asp:DropDownList>
          </div>
          <div class="col-2">

          <asp:Label Text="Tipo:" runat="server" />
              <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="TipodeFiltro" OnSelectedIndexChanged="TipodeFiltro_SelectedIndexChanged" DataTextField="Seleccione">
                    <asp:ListItem Text="Rápido" />
                    <asp:ListItem Text="Avanzado" />
                   </asp:DropDownList>
           </div>
        </div>
      

        <%if (TipodeFiltro.SelectedItem.Text == "Avanzado")
            {
                %>
         <BR>
        <div class="row">
            <div class="col-2">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" DataTextField="Seleccione">
                    <asp:ListItem Text="Nombre" selected="True" />
                    <asp:ListItem Text="Descripcion" />
                    </asp:DropDownList>
            </div>

            <div class="col-2">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="col-4">
                    <asp:Label Text="Filtrar:" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>

            <div class="col-2">
                    <asp:Label Text="Marca" runat="server" />
                    <asp:DropDownList runat="server" ID="DropDownMarca"
                    Cssclass="form-control" 
                    type="button" 
                    data-toggle="dropdown" 
                    aria-haspopup="true" 
                    aria-expanded="false" 
                    >
                    </asp:DropDownList>
            </div>
     
             <div class="col-2">
                  <asp:Label Text="Categoria" runat="server" />
                    <asp:DropDownList ID="DropDownCategoria" 
                    Cssclass="form-control" 
                    type="button" 
                    data-toggle="dropdown" 
                    aria-haspopup="true" 
                    aria-expanded="false" 
                    runat="server">
                    </asp:DropDownList>
            </div>


</div>

         <BR>
         <div class="row">
            <div class="col-4">
            </div>
             <div class="col-2">
                    <asp:Label Text="Precio desde:" runat="server" />
                    <asp:TextBox runat="server" ID="Precioentre" CssClass="form-control" />
                    <asp:RegularExpressionValidator ControlToValidate="Precioentre" ErrorMessage="Valor inválido"
                    ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server" ValidationGroup="Numbers" ForeColor="red"></asp:RegularExpressionValidator>
             </div>
            <div class="col-2">
                    <asp:Label Text="Precio hasta:" runat="server" />
                    <asp:TextBox runat="server" ID="Preciohasta" CssClass="form-control"/>
                    <asp:RegularExpressionValidator ControlToValidate="Preciohasta" ErrorMessage="Valor inválido"
                    ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server" ValidationGroup="Numbers" ForeColor="red"></asp:RegularExpressionValidator>
            </div>

                    <div class="col-2">
                    <asp:Label Text="Estado" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>    
             </div>

            <div class="col-2">
                   <asp:Label Text="Favoritos" runat="server" />
                    <asp:DropDownList runat="server" ID="Favoritos" CssClass="form-control">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Favoritos" />
                    <asp:ListItem Text="No favoritos" />
                    </asp:DropDownList>    
            </div>

</div>


<div class="row">

    <div class="col-10">
        </div>
            <div class="col-2">
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" id="btnBuscar" OnClick="btnBuscar_Click" width="100%"/>
            </div>

</div>


        <%} %>

<br />
           
    <div class="row row-cols-1 row-cols-md-3 g-0" style="gap:17px">
        <asp:Repeater runat="server" id="repRepetidor">

            <ItemTemplate>
                    <div class="card" style="width:24%;">
                 <div class="card-header">
                        <h5 class="card-title"><%#Eval("artnombre") %></h5>
                     </div>

               <div class="card-body" style="align-items:center;
               vertical-align:middle;
               display:flex; align-items:center;"/>


               <img src="<%#Eval("artimagen") %>" class="card-img-top" alt="..." onerror="imgError(this)"/>

                      </div>
                      <div class="card-footer" style="height:135px; background-color:white" >
               <p class="card-text"><%#Eval("artdescripcion") %>
                        </div>
                      <div class="card-footer" >
                        <a href="Articulo.aspx?id=<%#Eval("artid") %>" class="btn btn-primary" >Ver Detalle</a>  
                        </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>
                                                        </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
