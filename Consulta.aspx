<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublico.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="Server">
    <style>
        .tam {
            display: inline;
            width: 500px !important;
        }
        div.well {
            height: 250px;
        }

        .Absolute-Center {
            margin: auto;
            position: absolute;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
        }

            .Absolute-Center.is-Responsive {
                width: 70%;
                height: 70%;
                min-width: 400px;
                max-width: 800px;
                padding: 40px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">
    <div class="Absolute-Center is-Responsive">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title" style="text-align: center">
                    <h3>Convocatorias</h3>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-12" style="text-align:center">
                        <h4>Soy</h4>
                    </div>
                </div>
                <div class="form-group form-inline">
                    <label class="col-lg-4 control-label" for="<%= DdlNivelEstudio.ClientID %>">Nivel de Estudio*</label>
                    <asp:DropDownList ID="DdlNivelEstudio" runat="server" DataValueField="idNivel" DataTextField="Nivel" CssClass="form-control input-sm tam select2me">
                    </asp:DropDownList>
                </div>
                <div class="form-group form-inline">
                    <label class="col-lg-4 control-label" for="<%= DdlEdad.ClientID %>">Edad*</label>
                    <asp:DropDownList ID="DdlEdad" runat="server" CssClass="form-control input-sm tam select2me">
                    </asp:DropDownList>
                </div>
                <div class="form-group form-inline">
                    <label class="col-lg-4 control-label" for="<%= DdlSexo.ClientID %>">Sexo*</label>
                    <asp:DropDownList ID="DdlSexo" runat="server" DataValueField="idPais" DataTextField="Pais" CssClass="form-control input-sm tam select2me">
                        <asp:ListItem Text="Hombre" Value="Hombre"></asp:ListItem>
                        <asp:ListItem Text="Mujer" Value="Mujer"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="row">
                    <div class="col-xs-12" style="text-align:center">
                        <h4>Quiero</h4>
                    </div>
                </div>
                <div class="form-group form-inline">
                    <label class="col-lg-4 control-label" for="<%= DdlNivel.ClientID %>">Nivel de Estudio de Interes:</label>
                    <asp:DropDownList ID="DdlNivel" runat="server" DataValueField="idNivel" DataTextField="Nivel" CssClass="form-control input-sm tam select2me">
                    </asp:DropDownList>
                </div>
                <div class="form-group form-inline">
                    <label class="col-lg-4 control-label" for="<%= DdlArea.ClientID %>">Area de Estudio:</label>
                    <asp:DropDownList ID="DdlArea" runat="server" DataValueField="idArea" DataTextField="AreaEstudio" CssClass="form-control input-sm tam select2me">
                    </asp:DropDownList>
                </div>
                <div class="form-group form-inline">
                    <label class="col-lg-4 control-label" for="<%= DdlPais.ClientID %>">Pais:</label>
                    <asp:DropDownList ID="DdlPais" runat="server" DataValueField="idPais" DataTextField="Pais" CssClass="form-control input-sm tam select2me">
                    </asp:DropDownList>
                </div>
                <br />
                <br />
                <div class="row">
                    <div class="col-xs-12" style="text-align:center">
                        <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-lg btn-success" Text="Buscar" />
                    </div>
                </div>
            </div>
            <div class="panel-footer">
            </div>
        </div>
    </div>
</asp:Content>

