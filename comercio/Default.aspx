<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comercio._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div id="carouselExampleInterval" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active" data-bs-interval="2000">
                    <img src="https://images.pexels.com/photos/5632363/pexels-photo-5632363.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" class="d-block w-100" alt="..." style="height: 750px; width: 1300px">
                </div>
                <div class="carousel-item" data-bs-interval="2000">
                    <img src="https://images.pexels.com/photos/5727956/pexels-photo-5727956.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" class="d-block w-100" alt="..." style="height: 750px; width: 1300px">
                </div>
                <div class="carousel-item" data-bs-interval="2000">
                    <img src="https://images.pexels.com/photos/3783525/pexels-photo-3783525.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" class="d-block w-100" alt="..." style="height: 750px; width: 1300px">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleInterval" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleInterval" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>


        <asp:Repeater ID="repCategoriasConArticulos" runat="server">
            <ItemTemplate>

                
                <div class="mt-5">
                    <asp:Label Text='<%# Eval("Categoria") %>' runat="server" CssClass="h5" />
                </div>

             
                <div id="carousel<%# Container.ItemIndex %>" class="carousel carousel-dark slide">
                    <div class="carousel-inner mt-3">
                        <asp:Repeater ID="repGruposDeArticulos" runat="server" DataSource='<%# Eval("GruposDeArticulos") %>'>
                            <ItemTemplate>
                                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                    <div class="cards-wrapper d-flex gap-3">
                                        <asp:Repeater ID="repArticulos" runat="server" DataSource='<%# Container.DataItem %>'>
                                            <ItemTemplate>
                                                <div class="card border border-primary border-opacity-50 rounded">
                                                    <img src="<%# Eval("UrlImagenValidada") %>" class="card-img-top mt-1" alt="<%# Eval("Nombre") %>" style="height: 300px; width: 300px; object-fit: contain">
                                                    <div class="card-body">
                                                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                                    </div>
                                                    <div class="card-footer">
                                                        <small class="text-body-secondary">$ <%# Eval("Precio") %></small>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    
                    <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%# Container.ItemIndex %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carousel<%# Container.ItemIndex %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </ItemTemplate>
        </asp:Repeater>


    </main>

</asp:Content>
