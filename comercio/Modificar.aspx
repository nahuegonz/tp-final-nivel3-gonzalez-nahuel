<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="Comercio.Modificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <%--<%if () %>--%>

    <h2 class="m-5">Modificar Producto</h2>
    <h2 class="m-5">Agregar Producto</h2>

    <div class="row d-flex justify-content-center">

        <div class="row d-flex justify-content-center">
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombreProducto" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcionProducto" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Código</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigoProducto" />
                </div>


                <label class="form-label">Marca</label>
                <div class="dropdown mb-3">
                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control btn btn-secondary">
                        <asp:ListItem Text="Marca" />
                    </asp:DropDownList>
                </div>

                <label class="form-label">Categoría</label>
                <div class="dropdown mb-3">
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control btn btn-secondary">
                        <asp:ListItem Text="Categoría" />
                    </asp:DropDownList>
                </div>
            </div>




            <div class="col-md-4">

                <label class="form-label">Precio</label>
                <div class="input-group mb-3">
                    <label class="input-group-text">$</label>
                    <asp:TextBox runat="server" Class="form-control" ID="txtPrecioProducto" Style="max-width: 250px" />
                </div>


                <label class="form-label">Imagen del Producto</label>
                <div class="mb-3">
                    <input type="text" runat="server" id="txtImagenProducto" class="form-control" style="max-width: 285px" />
                </div>
                <asp:Image ID="imgNuevoProducto" runat="server" CssClass="img-fluid mb-3 mt-3" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" />
            </div>

        </div>
        <div class="row d-flex justify-content-center">
            <div class="col-md-4 m-5">
                <asp:Button Text="Guardar" CssClass="btn btn-primary me-3" ID="btnGuardarProducto" runat="server" OnClick="btnGuardarProducto_Click" />
                <a href="Default.aspx">Regresar</a>
            </div>
        </div>
    </div>
















</asp:Content>
