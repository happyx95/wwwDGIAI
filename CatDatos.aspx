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
                                <h3>Paises</h3>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label " for="<%= TxtPais.ClientID %>">Nombre:</label>
                                        <asp:TextBox ID="TxtPais" runat="server" CssClass="form-control input-sm tam" MaxLength="20" Width="70%" Style="text-transform: capitalize"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp
                                        <asp:LinkButton ID="LbkPais" runat="server" CssClass="btn btn-circle btn-sm btn-success " Text="<i class='fa fa-plus'></i>"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label" for="<%= DdlPais.ClientID %>">Lista de Paises:</label>
                                        <asp:DropDownList ID="DdlPais" runat="server" DataValueField="idPais" DataTextField="Pais" Width="47%" CssClass="form-control input-sm tam select2me">
                                        </asp:DropDownList>&nbsp&nbsp
                                        <asp:LinkButton ID="LnkEditPais" runat="server" CssClass="btn btn-circle btn-sm btn-success " OnClick="LnkEditPais_Click" Text="<i class='fa fa-pencil'></i>"></asp:LinkButton>&nbsp&nbsp
                                        <asp:HyperLink ID="LnkEliminarPais" runat="server" CssClass="btn btn-circle btn-sm btn-danger" NavigateUrl="javascript:$('#DivEliminarPais').modal('show');" Text="<i class='fa fa-trash-o'></i>"></asp:HyperLink>
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
                                <h3>Areas de Estudio</h3>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label " for="<%= TxtArea.ClientID %>">Nombre:</label>
                                        <asp:TextBox ID="TxtArea" runat="server" CssClass="form-control input-sm tam" MaxLength="20" Width="70%" Style="text-transform: capitalize"></asp:TextBox>&nbsp&nbsp&nbsp&nbsp
                                        <asp:LinkButton ID="LnkArea" runat="server" CssClass="btn btn-circle btn-sm btn-success " Text="<i class='fa fa-plus'></i>"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-4 control-label" for="<%= DdlPais.ClientID %>">Lista de Areas:</label>
                                        <asp:DropDownList ID="DdlArea" runat="server" DataValueField="idArea" DataTextField="AreaEstudio" Width="47%" CssClass="form-control input-sm tam select2me">
                                        </asp:DropDownList>&nbsp&nbsp
                                        <asp:LinkButton ID="LnkEditArea" runat="server" CssClass="btn btn-circle btn-sm btn-success " OnClick="LnkEditArea_Click" Text="<i class='fa fa-pencil'></i>"></asp:LinkButton>&nbsp&nbsp
                                        <asp:HyperLink ID="LnkEliminarArea" runat="server" CssClass="btn btn-circle btn-sm btn-danger" NavigateUrl="javascript:$('#DivEliminarArea').modal('show');" Text="<i class='fa fa-trash-o'></i>"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="DivEliminarPais" class="modal fade">
        <div class="modal-dialog ">
            <asp:UpdatePanel ID="UpEliminarPais" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Eliminar</h4>
                        </div>
                        <div class="modal-body">
                            <h4>¿Desea eliminar este pais?</h4>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnEliminarPais" runat="server" OnClick="BtnEliminarPais_Click" class="btn btn-danger" Text="Eliminar" />
                            <button type="button" class="btn default" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="DivEliminarArea" class="modal fade">
        <div class="modal-dialog ">
            <asp:UpdatePanel ID="UpEliminarArea" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Eliminar</h4>
                        </div>
                        <div class="modal-body">
                            <h4>¿Desea eliminar esta area de estudio?</h4>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnEliminarArea" runat="server" OnClick="BtnEliminarArea_Click" class="btn btn-danger" Text="Eliminar" />
                            <button type="button" class="btn default" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="DivEditarPais" class="modal fade">
        <div class="modal-dialog ">
            <asp:UpdatePanel ID="UpEditPais" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Editar Pais</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group form-inline">
                                <label class="col-lg-3 control-label " for="<%= TxtEditarPais.ClientID %>">Pais:</label>
                                <asp:TextBox ID="TxtEditarPais" runat="server" CssClass="form-control input-sm tam"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnEditPais" runat="server" OnClick="BtnEditPais_Click" class="btn btn-success" Text="Aceptar" />
                            <button type="button" class="btn default" data-dismiss="modal">Cancelar</button>
                        </div>
                        <asp:HiddenField ID="HdnIDPais" runat="server" Value="-1" ClientIDMode="Static" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="DivEditarArea" class="modal fade">
        <div class="modal-dialog ">
            <asp:UpdatePanel ID="UpEditArea" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Editar Area de estudio</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group form-inline">
                                <label class="col-lg-3 control-label " for="<%= TxtEditArea.ClientID %>">Area de estudio:</label>
                                <asp:TextBox ID="TxtEditArea" runat="server" CssClass="form-control input-sm tam"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnEditArea" runat="server" OnClick="BtnEditArea_Click" class="btn btn-success" Text="Aceptar" />
                            <button type="button" class="btn default" data-dismiss="modal">Cancelar</button>
                        </div>
                        <asp:HiddenField ID="HdnIDArea" runat="server" Value="-1" ClientIDMode="Static" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

