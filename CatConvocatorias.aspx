<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CatConvocatorias.aspx.cs" Inherits="CatConvocatorias" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CSS" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="Server">
    <div class="row" style="vertical-align: central; display: inline">
        <div class="col-md-6" style="text-align: left;">
            <div class="row" style="align-content: center">
                <div class="col-md-1" style="display: inline">
                    <asp:HyperLink ID="HplNueva" runat="server" NavigateUrl="#" data-toggle="modal" data-target="#DivConvocatoria" CssClass="btn btn-lg btn-circle" Text="<i class='fa fa-plus-circle fa-2x'></i>"></asp:HyperLink>
                </div>
                <div class="col-md-5" style="display: inline">
                    <h4>Nueva Convocatoria</h4>
                </div>
            </div>
        </div>
        <div class="col-md-6" style="text-align: right">
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpConvocatorias" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GvConvocatorias" runat="server" GridLines="None"
                        CssClass="table table-hover table-responsive"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre de Convocatoria" DataField="Convocatoria" />
                            <asp:BoundField HeaderText="Vigencia" DataField="Vigencia" />
                            <asp:BoundField HeaderText="País" DataField="Pais" />
                            <asp:BoundField HeaderText="Duración de Intercambio" DataField="Duracion" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            <asp:TemplateField HeaderText="Opciones">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-circle btn-sm btn-success " Text="<i class='fa fa-pencil'></i>"></asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-circle btn-sm btn-danger " Text="<i class='fa fa-trash-o'></i>"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="DivConvocatoria" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

