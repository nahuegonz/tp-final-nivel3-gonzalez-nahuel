<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Comercio.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="m-5">Mi Perfil</h2>

<div class="row d-flex justify-content-center">

    <div class="row d-flex justify-content-center">
        <div class="col-md-4">
            <label class="form-label">Email</label>
            <div class="input-group mb-3">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:Button Text="Editar" runat="server" ID="btnEditarEmail" Class="btn btn-outline-secondary" type="button" OnClick="btnEditarEmail_Click" />
            </div>
            <label class="form-label">Contraseña</label>
            <div class="input-group mb-3">
                <asp:TextBox runat="server" Type="Password" CssClass="form-control" ID="txtPass" />
                <asp:Button Text="Editar" runat="server" ID="btnEditarPass" Class="btn btn-outline-secondary" type="button" OnClick="btnEditarPass_Click" />
            </div>
            <label class="form-label">Nombre</label>
            <div class="input-group mb-3">
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
                <asp:Button Text="Editar" runat="server" ID="btnEditarNombre" Class="btn btn-outline-secondary" type="button" OnClick="btnEditarNombre_Click" />
                <%--<asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />--%>
            </div>
            <label class="form-label">Apellido</label>
            <div class="input-group mb-3">
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" ></asp:TextBox>
                <asp:Button Text="Editar" runat="server" ID="btnEditarApellido" Class="btn btn-outline-secondary" type="button" OnClick="btnEditarApellido_Click" />
                <%--<asp:RangeValidator ErrorMessage="Fuera de rango.." ControlToValidate="txtApellido" Type="Integer" MinimumValue="1" MaximumValue="20" runat="server" />--%>
                <%--<asp:RegularExpressionValidator ErrorMessage="Formato email por favor" ControlToValidate="txtApellido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>

                <%--<asp:RegularExpressionValidator ErrorMessage="Formato incorrecto..." ControlToValidate="txtApellido" ValidationExpression="^[0-9]+$" runat="server"/>--%>
            </div>

        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />

        </div>

    </div>
    <div class="row d-flex justify-content-center">
        <div class="col-md-4 m-5">
            <asp:Button Text="Guardar" CssClass="btn btn-primary me-3" ID="btnGuardar" runat="server" />
            <a href="Default.aspx">Regresar</a>
        </div>
    </div>
</div>





</asp:Content>
