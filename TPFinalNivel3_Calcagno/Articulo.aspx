<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <style> 
svg{
  cursor:pointer; overflow:visible; width:60px;
  #heart{transform-origin:center; animation:animateHeartOut .3s linear forwards;}
  #main-circ{transform-origin:29.5px 29.5px;}
}

#checkbox{display:none;}

#checkbox:checked + label svg{
    #heart{transform:scale(.2); fill:#E2264D; animation:animateHeart .3s linear forwards .25s;}
    #main-circ{transition:all 2s; animation:animateCircle .3s linear forwards; opacity:1;}
    #grp1{
      opacity:1; transition:.1s all .3s;
      #oval1{
        transform:scale(0) translate(0, -30px);
        transform-origin:0 0 0;
        transition:.5s transform .3s;}
      #oval2{
        transform:scale(0) translate(10px, -50px);
        transform-origin:0 0 0;
        transition:1.5s transform .3s;}
    }
    #grp2{
      opacity:1; transition:.1s all .3s;
      #oval1{
        transform:scale(0) translate(30px, -15px); 
        transform-origin:0 0 0;
        transition:.5s transform .3s;}
      #oval2{
        transform:scale(0) translate(60px, -15px); 
        transform-origin:0 0 0;
        transition:1.5s transform .3s;}
    }
    #grp3{
      opacity:1; transition:.1s all .3s;
      #oval1{
        transform:scale(0) translate(30px, 0px);
        transform-origin:0 0 0;
        transition:.5s transform .3s;}
      #oval2{
        transform:scale(0) translate(60px, 10px);
        transform-origin:0 0 0;
        transition:1.5s transform .3s;}
    }
    #grp4{
      opacity:1; transition:.1s all .3s;
      #oval1{
        transform:scale(0) translate(30px, 15px);
        transform-origin:0 0 0;
        transition:.5s transform .3s;}
      #oval2{
        transform:scale(0) translate(40px, 50px);
        transform-origin:0 0 0;
        transition:1.5s transform .3s;}
    }
    #grp5{
      opacity:1; transition:.1s all .3s;
      #oval1{
        transform:scale(0) translate(-10px, 20px);
        transform-origin:0 0 0;
        transition:.5s transform .3s;}
      #oval2{
        transform:scale(0) translate(-60px, 30px);
        transform-origin:0 0 0;
        transition:1.5s transform .3s;}
    }
    #grp6{
      opacity:1; transition:.1s all .3s;
      #oval1{
        transform:scale(0) translate(-30px, 0px);
        transform-origin:0 0 0;
        transition:.5s transform .3s;}
      #oval2{
        transform:scale(0) translate(-60px, -5px);
        transform-origin:0 0 0;
        transition:1.5s transform .3s;}
    }
    #grp7{
      opacity:1; transition:.1s all .3s;
      #oval1{
        transform:scale(0) translate(-30px, -15px);
        transform-origin:0 0 0;
        transition:.5s transform .3s;}
      #oval2{
        transform:scale(0) translate(-55px, -30px);
        transform-origin:0 0 0;
        transition:1.5s transform .3s;}
    }
    #grp2{opacity:1; transition:.1s opacity .3s;}
    #grp3{opacity:1; transition:.1s opacity .3s;}
    #grp4{opacity:1; transition:.1s opacity .3s;}
    #grp5{opacity:1; transition:.1s opacity .3s;}
    #grp6{opacity:1; transition:.1s opacity .3s;}
    #grp7{opacity:1; transition:.1s opacity .3s;}
}

@keyframes animateCircle{
  40%{transform:scale(10); opacity:1; fill:#DD4688;}
  55%{transform:scale(11); opacity:1; fill:#D46ABF;}
  65%{transform:scale(12); opacity:1; fill:#CC8EF5;}
  75%{transform:scale(13); opacity:1; fill:transparent; stroke:#CC8EF5; stroke-width:.5;}
  85%{transform:scale(17); opacity:1; fill:transparent; stroke:#CC8EF5; stroke-width:.2;}
  95%{transform:scale(18); opacity:1; fill:transparent; stroke:#CC8EF5; stroke-width:.1;}
  100%{transform:scale(19); opacity:1; fill:transparent; stroke:#CC8EF5; stroke-width:0;}
}

@keyframes animateHeart{
  0%{transform:scale(.2);}
  40%{transform:scale(1.2);}
  100%{transform:scale(1);}
}

@keyframes animateHeartOut{
  0%{transform:scale(1.4);}
  100%{transform:scale(1);}
}

</style>

     <main>

<div class="row">
    <div class="col-6">
            <div class="row">
                <section class="row" aria-labelledby="aspnetTitle">
                <p></p>
                <h2 id="aspnetTitle">
                <asp:Label ID="Titulo" runat="server" Text="Agregar Articulo">
                </asp:Label>
                </h2>
                </section>
            </div>
            <div class="row">
                <div class="col-2">
                    <div class="mb-3">
                    <label for="TxtId" class="form-label">Id: </label>
                    <asp:TextBox runat="server" ID="TxtId" CssClass="form-control" />
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                    <label for="TxtCodigo" class="form-label">Codigo: </label>
                    <asp:TextBox runat="server" ID="TxtCodigo" CssClass="form-control"  required="1"/>
                    <asp:RegularExpressionValidator 
                    Display="Dynamic" 
                    ControlToValidate="TxtCodigo" 
                    ID="RegularExpressionValidator5" 
                    ValidationExpression = "^[\s\S]{0,50}$" 
                    runat="server" 
                    ErrorMessage="Solo se permiten 50 caracteres"
                    ForeColor="Red">
                   </asp:RegularExpressionValidator>
                   </div>
                </div>
            
                <div class="col-1">
                </div>
            </div>

            <div class="row">
                <div class="mb-3">
                    <label for="TxtNombre" class="form-label">Nombre: </label>
                    <asp:TextBox runat="server" ID="TxtNombre" CssClass="form-control" required="1"/>
                    <asp:RegularExpressionValidator 
                    Display="Dynamic" 
                    ControlToValidate="TxtNombre" 
                    ID="RegularExpressionValidator4" 
                    ValidationExpression = "^[\s\S]{0,50}$" 
                    runat="server" 
                    ErrorMessage="Solo se permiten 50 caracteres"
                    ForeColor="Red">
                   </asp:RegularExpressionValidator>
                </div>
            </div>

          <div class="row">
              <div class="col-3">
                <div class="mb-3">
                <label for="TxtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="TxtPrecio" CssClass="form-control" required="1"/>
                <asp:RegularExpressionValidator 
                    Display="Dynamic" 
                    ControlToValidate="TxtPrecio" 
                    ID="RegularExpressionValidator3" 
                    ValidationExpression = "^(?=.)([+-]?([0-9]*)(\.([0-9]+))?)$" 
                    runat="server" 
                    ErrorMessage="Formato incorrecto"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
             </div>
             </div>
          </div>


          <div class="row">
            <div class="mb-3">
                <label for="TxtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" style="resize:none" height="100px" resize="none" ID="TxtDescripcion" CssClass="form-control" required="1"/>
                <asp:RegularExpressionValidator 
                    Display="Dynamic" 
                    ControlToValidate="TxtDescripcion" 
                    ID="RegularExpressionValidator1" 
                    ValidationExpression = "^[\s\S]{0,150}$" 
                    runat="server" 
                    ErrorMessage="Solo se permiten 150 caracteres"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
             </div>
          </div>

        <div class="row">
                <div class="col-4">

                    <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoria:</label>
                    <asp:DropDownList ID="ddlCategoria" 
                    class="form-control" 
                    type="button" 
                    data-toggle="dropdown"  
                    runat="server">
                    </asp:DropDownList>
                   </div>
                </div>

</div>

         <div class="row">
                <div class="col-4">
                    <div class="mb-3">
                    <label for="ddlMarca" class="form-label">Marca:</label>
                    <asp:DropDownList ID="ddlMarca" 
                    class="form-control" 
                    type="button" 
                    data-toggle="dropdown"
                    runat="server">
                    </asp:DropDownList>
                    </div>
               </div>
          </div>

       <div class="row">
         <div class="mb-3"">
                <label for="Estado" class="form-label">Estado</label>
                <div class="form-check form-switch" align="right">
                <input class="form-check-input" type="checkbox" runat="server" id="estado" clientIdMode="Static" style="align-items:self-end"/>
                </div>
         </div>
       </div>
                <p></p>
                <br />

        <div class="row">
            <div class="col-2">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
            </div>

            <div class="col-2">
                <a href="javascript:history.back()" Class="btn btn-primary" ">Cancelar</a>
            </div>

<%
    if (modificar)
    {%>
             <div class="col-2">
                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />     
                <p></p>
             </div>
    <%}%>
    <%else{%>

    <%}%>

        </div>

             <%if (ConfirmaEliminacion)
            {%>
            
            <div class="row">
                            <div class="col-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                            </div>
            </div>
            <%}%>
             <%else{%>


             <%}%>

    </div>


<div class="col-6">

    <div class="mb-3" align="right">

    <input type="checkbox" id="checkbox" checked runat="server" align="right" clientIdMode="Static"/>
    <label for="checkbox" align="right">
      <svg id="heart-svg" viewBox="467 392 58 57" xmlns="http://www.w3.org/2000/svg">
        <g id="Group" fill="none" fill-rule="evenodd" transform="translate(467 392)">
          <path d="M29.144 20.773c-.063-.13-4.227-8.67-11.44-2.59C7.63 28.795 28.94 43.256 29.143 43.394c.204-.138 21.513-14.6 11.44-25.213-7.214-6.08-11.377 2.46-11.44 2.59z" id="heart" fill="#AAB8C2"/>
          <circle id="main-circ" fill="#E2264D" opacity="0" cx="29.5" cy="29.5" r="1.5"/>

          <g id="grp7" opacity="0" transform="translate(7 6)">
            <circle id="oval1" fill="#9CD8C3" cx="2" cy="6" r="2"/>
            <circle id="oval2" fill="#8CE8C3" cx="5" cy="2" r="2"/>
          </g>

          <g id="grp6" opacity="0" transform="translate(0 28)">
            <circle id="oval1" fill="#CC8EF5" cx="2" cy="7" r="2"/>
            <circle id="oval2" fill="#91D2FA" cx="3" cy="2" r="2"/>
          </g>

          <g id="grp3" opacity="0" transform="translate(52 28)">
            <circle id="oval2" fill="#9CD8C3" cx="2" cy="7" r="2"/>
            <circle id="oval1" fill="#8CE8C3" cx="4" cy="2" r="2"/>
          </g>

          <g id="grp2" opacity="0" transform="translate(44 6)">
            <circle id="oval2" fill="#CC8EF5" cx="5" cy="6" r="2"/>
            <circle id="oval1" fill="#CC8EF5" cx="2" cy="2" r="2"/>
          </g>

          <g id="grp5" opacity="0" transform="translate(14 50)">
            <circle id="oval1" fill="#91D2FA" cx="6" cy="5" r="2"/>
            <circle id="oval2" fill="#91D2FA" cx="2" cy="2" r="2"/>
          </g>

          <g id="grp4" opacity="0" transform="translate(35 50)">
            <circle id="oval1" fill="#F48EA7" cx="6" cy="5" r="2"/>
            <circle id="oval2" fill="#F48EA7" cx="2" cy="2" r="2"/>
          </g>

          <g id="grp1" opacity="0" transform="translate(24)">
            <circle id="oval1" fill="#9FC7FA" cx="2.5" cy="3" r="2"/>
            <circle id="oval2" fill="#9FC7FA" cx="7.5" cy="2" r="2"/>
          </g>
        </g>
      </svg>
    </label>

 </div>


           <p></p>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" 
                        ID="TxtImagenUrl" 
                        CssClass="form-control"
                        AutoPostBack="true" 
                        OnTextChanged="txtImagenUrl_TextChanged"
                        required="1"
                        />
                    <asp:RegularExpressionValidator 
                    Display="Dynamic" 
                    ControlToValidate="TxtImagenUrl" 
                    ID="RegularExpressionValidator2" 
                    ValidationExpression = "^[\s\S]{0,1000}$" 
                    runat="server" 
                    ErrorMessage="Solo se permiten 1000 caracteres"
                    ForeColor="Red">
                    </asp:RegularExpressionValidator>


                    </div>
                    <div class="mx-auto" align="center">
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                    runat="server" 
                    ID="imgArticulo"
                    style="Height: 300px"/>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
         </div>
      </div>
 
     </main>

</asp:Content>
