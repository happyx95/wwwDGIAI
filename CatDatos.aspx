<%@ Page Title="Configuracion del Sistema" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CatDatos.aspx.cs" Inherits="CatDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="Server">
    <style>
        .panel-danger > .panel-heading {
            border-color: #ef3e2e;
            background-color: #ef3e2e;
            color: white;
        }

        .panel-danger {
            border-color: #ef3e2e;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">
    <br />
    <br />
    <div class="form-group form-inline">
        <asp:HyperLink ID="HplNueva" runat="server" CssClass="btn btn-lg btn-circle" Text="<i class='fa fa-cog fa-2x'></i>"></asp:HyperLink>
        <label class="control-label">Configuración del sistema</label>
    </div>
    <asp:UpdatePanel ID="UpDatos" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <div class="panel-title" style="text-align: center">
                                <h3>Agrega Paises</h3>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label " for="<%= TxtPais.ClientID %>">Nombre:</label>
                                        <asp:TextBox ID="TxtPais" runat="server" CssClass="form-control input-sm tam" MaxLength="20" Style="text-transform: capitalize"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp
                                        <asp:LinkButton ID="LbkPais" runat="server" CssClass="btn btn-circle btn-sm btn-success " Text="<i class='fa fa-plus'></i>"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label" for="<%= DdlPais.ClientID %>">Lista de Paises:</label>
                                        <asp:DropDownList ID="DdlPais" runat="server" DataValueField="idPais" DataTextField="Pais" CssClass="form-control input-sm tam select2me">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <div class="panel-title" style="text-align: center">
                                <h3>Agrega Areas de Estudio</h3>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label " for="<%= TxtArea.ClientID %>">Nombre:</label>
                                        <asp:TextBox ID="TxtArea" runat="server" CssClass="form-control input-sm tam" MaxLength="20" Style="text-transform: capitalize"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp
                                <asp:LinkButton ID="LnkArea" runat="server" CssClass="btn btn-circle btn-sm btn-success " Text="<i class='fa fa-plus'></i>"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label" for="<%= DdlPais.ClientID %>">Lista de Areas:</label>
                                        <asp:DropDownList ID="DdlArea" runat="server" DataValueField="idArea" DataTextField="AreaEstudio" CssClass="form-control input-sm tam select2me">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

