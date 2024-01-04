<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Gestionar Articulos</h2>
     </section>


         <style>
             .pagination1 {
    /*display: inline-block;*/
    padding-left: 0;
    margin: 20px 0;
    border-radius: 4px;
}
 
.pagination1 table > tbody > tr > td {
    display: inline;
}
 
.pagination1 table > tbody > tr > td > a,
.pagination1 table > tbody > tr > td > span {
    position: relative;
    float: left;
    padding: 8px 12px;
    line-height: 1.42857143;
    text-decoration: none;
    color: #2596be;
    background-color: #ffffff;
    border: 1px solid #dddddd;
    margin-left: -1px;
}
 
.pagination1 table > tbody > tr > td > span {
    position: relative;
    float: left;
    padding: 8px 12px;
    line-height: 1.42857143;
    text-decoration: none;    
    margin-left: -1px;
    z-index: 2;
    color: #2596be;
    background-color: #f5f5f5;
    border-color: #dddddd;
    cursor: default;
}
 
.pagination1 table > tbody > tr > td:first-child > a,
.pagination1 table > tbody > tr > td:first-child > span {
    margin-left: 0;
    border-bottom-left-radius: 4px;
    border-top-left-radius: 4px;
}
 
.pagination1 table > tbody > tr > td:last-child > a,
.pagination1 table > tbody > tr > td:last-child > span {
    border-bottom-right-radius: 4px;
    border-top-right-radius: 4px;
}
 
.pagination1 table > tbody > tr > td > a:hover,
.pagination1 table > tbody > tr > td > span:hover,
.pagination1 table > tbody > tr > td > a:focus,
.pagination1 table > tbody > tr > td > span:focus {
    color: #2596be;
    background-color: #eeeeee;
    border-color: #dddddd;
}
         </style>


    <div class="row">
        <div class="col-8">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
         </div>

         <div class="col-2">
                    <asp:Label Text="Criterio:" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="CriterioFRapido" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" DataTextField="Seleccione">
                    <asp:ListItem Text="Codigo" />
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
                    <asp:DropDownList runat="server" ID="DropDownMarca" CssClass="form-control">
                        <asp:ListItem Text="Todas" />
                        <asp:ListItem Text="Samsung" />
                        <asp:ListItem Text="Apple" />
                        <asp:ListItem Text="Sony" />
                        <asp:ListItem Text="Huawei" />
                        <asp:ListItem Text="Motorola" />
                    </asp:DropDownList>
            </div>
     
             <div class="col-2">
                 <asp:Label Text="Estado" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
            </div>

            <div class="col-8">
            </div>

             <div class="col-2">
                    <asp:Label Text="Categoria" runat="server" />
                    <asp:DropDownList runat="server" ID="DropDownCategoria" CssClass="form-control">
                    <asp:ListItem Text="Todas" />
                    <asp:ListItem Text="Celulares" />
                    <asp:ListItem Text="Media" />
                    <asp:ListItem Text="Televisores" />
                    <asp:ListItem Text="Audio" />
                    </asp:DropDownList>
             </div>


            <div class="col-2">
                <br>
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
                  PageSize="10">
            <PagerStyle CssClass="pagination1" />
            <Columns>
            <asp:BoundField HeaderText="Id"            DataField="artid"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"   ItemStyle-Width="3%"/>
            <asp:BoundField HeaderText="Codigo"        DataField="artcodigo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%"/>
            <asp:BoundField HeaderText="Nombre"        DataField="artnombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="9%" />
            <asp:BoundField HeaderText="Descripcion"   DataField="artdescripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%"/>
            <asp:BoundField HeaderText="Marca"         DataField="artmarca.descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="8%"/>
            <asp:BoundField HeaderText="Categoria"     DataField="artcategoria.descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="8%"/>
            <asp:BoundField HeaderText="Precio"        DataField="artprecio" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="8%" />
            <asp:CheckBoxField HeaderText="Estado"     DataField="artestado" ItemStyle-HorizontalAlign="Center"   ItemStyle-Width ="2%"/>
            <asp:CommandField HeaderText="Editar"       ShowSelectButton="true" SelectText="✍" ItemStyle-HorizontalAlign="Center"   ItemStyle-Width="2%" />
            </Columns>
    </asp:GridView>

    <a href="Articulo.aspx" class="btn btn-primary">Agregar</a>
    </main>

</asp:Content>
