<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Gestionar Articulos</h2>
     </section>

    <div class="row">

        <div class="col-8">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
         </div>

         <div class="col-2">
                    <asp:Label Text="Criterio:" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="CriterioFRapido"  DataTextField="Seleccione" OnSelectedIndexChanged="CriterioFRapido_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" Selected="True"/>
                    <asp:ListItem Text="Codigo" />
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
                    <asp:ListItem Text="Codigo" selected="True"/>
                    <asp:ListItem Text="Nombre" />
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
                <asp:DropDownList ID="DropDownMarca" 
                    Cssclass="form-control" 
                    type="button" 
                    data-toggle="dropdown" 
                    aria-haspopup="true" 
                    aria-expanded="false" 
                    runat="server">
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

   <br>
    <asp:GridView ID="dgvlistaArticulos" runat="server"
                  DataKeyNames="artid"
                  CssClass= "table table-striped table-bordered table-condensed" 
                  AutoGenerateColumns="false"
                  OnSelectedIndexChanged="dgvlistaArticulos_SelectedIndexChanged"
                  OnPageIndexChanging="dgvlistaArticulos_PageIndexChanging"
                  EnableSortingAndPagingCallbacks="false"
                  AllowPaging="True"
                  AllowSorting="True"
                  PageSize="10"
                  OnSorting="dgvlistaArticulos_Sorting"
                  
         >

            <PagerStyle CssClass="pagination1" />
            <Columns>
            <asp:BoundField HeaderText="ID"            DataField="artid"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="1%" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
            <asp:BoundField HeaderText="Codigo"        DataField="artcodigo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%"  SortExpression="artcodigo"/>
            <asp:BoundField HeaderText="Nombre"        DataField="artnombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="53%" SortExpression="artnombre" />
            <asp:BoundField HeaderText="Marca"         DataField="artmarca.descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="12.5%" SortExpression="artmarca"/>
            <asp:BoundField HeaderText="Categoria"     DataField="artcategoria.descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="12.5%" SortExpression="artcategoria"/>
            <asp:BoundField HeaderText="Precio"        DataField="artprecio" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="10%" SortExpression="artprecio"/>
            <asp:CheckBoxField HeaderText="Estado"     DataField="artestado" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width ="3%" SortExpression="artestado"/>
            <asp:BoundField HeaderText="❤️​"            DataField ="artfav" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="2%" SortExpression="artfav"/>
            <asp:CommandField HeaderText="✏️"          ShowSelectButton="true" SelectText="📝​" ItemStyle-Width="2%" />
            </Columns>

    </asp:GridView>

    <a href="Articulo.aspx" class="btn btn-primary">Agregar</a>

    </main>

</asp:Content>
