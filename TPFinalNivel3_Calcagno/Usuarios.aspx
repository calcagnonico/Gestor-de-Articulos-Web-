<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

         <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Gestionar Usuarios</h2>
     </section>

    <div class="row">

        <div class="col-8">
                <asp:Label Text="Filtrar por" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
         </div>
                 <div class="col-2">
                    <asp:Label Text="Criterio:" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="CriterioFRapido"  DataTextField="Seleccione">
                    <asp:ListItem Text="E-Mail" Selected="True"/>
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Apellido" />
                    </asp:DropDownList>
          </div>






<div class="row">

<label for="ListaUsuarios" class="form-label">Lista de usuarios registrados: </label>

    <asp:GridView ID="dgvlistaUsuarios" runat="server"
                  DataKeyNames="Id"
                  CssClass= "table table-striped table-bordered table-condensed" 
                  AutoGenerateColumns="false"
                  OnSelectedIndexChanged="dgvlistaUsuarios_SelectedIndexChanged"
                  OnPageIndexChanging="dgvlistaUsuarios_PageIndexChanging"
                  EnableSortingAndPagingCallbacks="false"
                  AllowPaging="True"
                  AllowSorting="True"
                  PageSize="10"
                  OnSorting="dgvlistaUsuarios_Sorting"
         >

            <PagerStyle CssClass="pagination1" />
            <Columns>
            <asp:BoundField HeaderText="Id"            DataField="Id"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="1%" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
            <asp:BoundField HeaderText="E-Mail"        DataField="Email" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="12.5%" SortExpression="Email"/>
            <asp:BoundField HeaderText="Nombre"        DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%"  SortExpression="Nombre"/>
            <asp:BoundField HeaderText="Apellido"      DataField="Apellido" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="53%" SortExpression="Apellido" />
            <asp:CheckBoxField HeaderText="Admin"      DataField="Admin" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width ="3%" SortExpression="Admin"/>
            <asp:CommandField HeaderText="✏️"          ShowSelectButton="true" SelectText="📝​" ItemStyle-Width="2%" />
            </Columns>

    </asp:GridView>



</div>


         </div>































</asp:Content>
