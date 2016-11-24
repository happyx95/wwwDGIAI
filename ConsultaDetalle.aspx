<%@ Page Title="Resultados de la busqueda" Language="C#" MasterPageFile="~/SitePublico.master" AutoEventWireup="true" CodeFile="ConsultaDetalle.aspx.cs" Inherits="ConsultaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="Server">
    <style>
        .tam {
            display: inline;
            width: 500px !important;
        }

        .modal-body p {
            word-wrap: break-word;
        }
    </style>
    <script src="lib/jquery.popdown.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">
    <br />
    <br />
    <div class="row">
        <div class="col-md-6">
            <h3>Resultado de la busqueda</h3>
            <br />
            <br />
            <div class="form-group form-inline">
                <label class="col-md-2 control-label " for="TxtBusqueda2" style="width: 100px">Buscar:</label>
                <input type="text" id="TxtBusqueda2" class="form-control input-sm tam" onkeyup="<%= String.Format("FiltrarTabla('TxtBusqueda2','{0}')", GvConvocatorias.ClientID) %>" />
            </div>
        </div>
        <div class="col-md-6">
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
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpConvocatorias" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GvConvocatorias" runat="server" GridLines="None"
                        DataKeyNames="Info"
                        CssClass="pure-table pure-table-horizontal ordenar"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre de Convocatoria" DataField="Convocatoria" />
                            <asp:BoundField HeaderText="Vigencia" DataField="Vigencia" />
                            <asp:BoundField HeaderText="País" DataField="Pais" />
                            <asp:BoundField HeaderText="Duración de Intercambio" DataField="Duracion" />
                            <asp:BoundField HeaderText="Area de Estudio" DataField="AreaEstudio" />
                            <asp:BoundField HeaderText="Nivel" DataField="Nivel" />
                            <asp:TemplateField HeaderText="Informacion Adicional" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:Button ID="BtnInfo" runat="server" OnClick="BtnInfo_Click" CssClass="btn btn-sm btn-success" Width="70%" Text="Ver" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="btn-danger" />
                        <AlternatingRowStyle CssClass="pure-table-odd" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="DivInfo" class="modal fade " tabindex="-1" role="dialog" aria-labelledby="DivInfoLabel" aria-hidden="true">
        <div class="modal-dialog" role="contentinfo">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpInfo" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">Informacion</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <p id="LblInfo" runat="server"></p>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerar</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

