<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="Comercio.Buscador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container-fluid d-flex col justify-content-center">

        <div class="accordion accordion-flush border d-flex row align-self-start me-5 mt-5 w-50" id="acdFiltros">
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" aria-controls="flush-collapseOne">
                        Categoria
                    </button>
                </h2>
                <div id="flush-collapseOne" class="accordion-collapse collapse">
                    <div class="accordion-body">

                        <asp:Repeater runat="server" ID="repCategoria">
                            <ItemTemplate>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="" id="chkCategoria">
                                    <label class="form-check-label" for="flexCheckDefault">
                                        <%#Eval("Descripcion") %>
                                    </label>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseTwo" aria-expanded="false" aria-controls="flush-collapseTwo">
                        Marca
                    </button>
                </h2>
                <div id="flush-collapseTwo" class="accordion-collapse collapse">
                    <div class="accordion-body">


                        <asp:Repeater runat="server" ID="repMarca">
                            <ItemTemplate>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="" id="chkMarca">
                                    <label class="form-check-label" for="flexCheckDefault">
                                        <%#Eval("Descripcion") %>
                                    </label>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>
                </div>
            </div>
            <div class="accordion-item">
                <h2 class="accordion-header">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseThree" aria-expanded="false" aria-controls="flush-collapseThree">
                        Precio
                    </button>
                </h2>
                <div id="flush-collapseThree" class="accordion-collapse collapse">
                    <div class="accordion-body">
                        <input type="range" class="form-range" id="Range1" runat="server">
                    </div>
                </div>
            </div>
        </div>






        <div class="row row-cols-1 row-cols-md-4 g-4 mt-4">


            <asp:Repeater runat="server" ID="repArticulos">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("UrlImagen") %>" id="imgArticulo" alt="Imagen <%#Eval("Nombre") %>" class="object-fit-contain rounded mw-100 p-3" style="height: 300px; width: 500px; object-fit:contain"  />
                            <div class="card-body">
                                <h6 class="card-title"><%#Eval("Nombre") %></h6>
                                <p class="card-text"><%#Eval("Precio") %></p>
                                <a href="Detalles.aspx?id=<%#Eval("Id") %>"></a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>
    </div>





















</asp:Content>
