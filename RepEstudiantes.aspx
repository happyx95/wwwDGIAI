<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RepEstudiantes.aspx.cs" Inherits="RepEstudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="Server">
    <br />
    <br />
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="form-group form-inline">
                <asp:HyperLink runat="server" CssClass="btn btn-lg btn-circle" Text="<i class='fa fa-address-card fa-2x'></i>"></asp:HyperLink>
                <label class="control-label">
                    <h2>Reporte de consultas</h2>
                </label>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6" style="text-align: center">
            <asp:GridView ID="GvConsultas" runat="server" GridLines="None"
                CssClass="pure-table pure-table-horizontal ordenar table-responsive"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Numero de consultas" DataField="NumeroConsultas" />
                    <asp:BoundField HeaderText="Sexo" DataField="Sexo" />
                    <asp:BoundField HeaderText="Área de Estudio" DataField="AreaEstudio" />
                    <asp:BoundField HeaderText="Edad Promedio" DataField="EdadPromedio" />
                    <asp:BoundField HeaderText="Nivel de Interés" DataField="NivelInteres" />
                    <asp:BoundField HeaderText="País" DataField="Pais" />
                </Columns>
                <HeaderStyle CssClass="btn-danger" />
                <AlternatingRowStyle CssClass="pure-table-odd" />
            </asp:GridView>
        </div>
        <div class="col-md-3"></div>
    </div>
</asp:Content>

