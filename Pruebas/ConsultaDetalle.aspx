﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublico.master" AutoEventWireup="true" CodeFile="ConsultaDetalle.aspx.cs" Inherits="CatConvocatorias2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CSS" runat="Server">
    <style>
        .tam {
            display: inline;
            width: 500px !important;
        }
    </style>
    <%--    <script src="Scripts/jquery-1.8.1.min.js"></script>
    <script src="Scripts/jquery-ui-1.8.23.min.js"></script>
    <script src="Scripts/jquery.json-2.3.min.js"></script>--%>
    <script src="Scripts/DataTables/jquery.dataTables.js"></script>
    <link href="Content/DataTables/css/demo_table_jui.css" rel="stylesheet" />
    <link href="Content/themes/base/jquery.ui.all.css" rel="stylesheet" />
    <script type="text/javascript">
        $.noConflict();
        $(document).ready(function () {
            $(".select2me").select2({
                tags: "true",
                allowClear: true

            });
            var $example = $(".js-example-programmatic").select2();
            var $exampleMulti = $(".js-example-programmatic-multi").select2();

            $(".js-programmatic-set-val").on("click", function () { $example.val("CA").trigger("change"); });
            $(".js-programmatic-open").on("click", function () { $example.select2("open"); });
            $(".js-programmatic-close").on("click", function () { $example.select2("close"); });
            $(".js-programmatic-init").on("click", function () { $example.select2(); });
            $(".js-programmatic-destroy").on("click", function () { $example.select2("destroy"); });
            $(".js-programmatic-multi-set-val").on("click", function () { $exampleMulti.val(["CA", "AL"]).trigger("change"); });
            $(".js-programmatic-multi-clear").on("click", function () { $exampleMulti.val(null).trigger("change"); });


            $('#GvConvocatorias').dataTable();
        });

        var parameter = Sys.WebForms.PageRequestManager.getInstance();

        parameter.add_endRequest(function () {
            //jquery code again for working after postback
            $(".select2me").select2({
                tags: "true",
                allowClear: true

            });
            var $example = $(".js-example-programmatic").select2();
            var $exampleMulti = $(".js-example-programmatic-multi").select2();

            $(".js-programmatic-set-val").on("click", function () { $example.val("CA").trigger("change"); });
            $(".js-programmatic-open").on("click", function () { $example.select2("open"); });
            $(".js-programmatic-close").on("click", function () { $example.select2("close"); });
            $(".js-programmatic-init").on("click", function () { $example.select2(); });
            $(".js-programmatic-destroy").on("click", function () { $example.select2("destroy"); });
            $(".js-programmatic-multi-set-val").on("click", function () { $exampleMulti.val(["CA", "AL"]).trigger("change"); });
            $(".js-programmatic-multi-clear").on("click", function () { $exampleMulti.val(null).trigger("change"); });


            $('#GvConvocatorias').dataTable();
        });
        function SetValue(Hidden, Value) {
            document.getElementById(Hidden).value = Value;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="Server">
    <div class="row" style="vertical-align: central; display: inline">
        <div class="col-md-6" style="text-align: left;">
            <div class="form-group form-inline">
                <asp:HyperLink ID="HplNueva" runat="server" NavigateUrl="javascript:$('#DivConvocatoria').modal('show');$('#Titulo').text('Agregar Convocatoria');SetValue('HdnModalidad', 'A');" CssClass="btn btn-lg btn-circle" Text="<i class='fa fa-plus-circle fa-2x'></i>"></asp:HyperLink>
                <label class="control-label">Nueva convocatoria</label>
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
                    <asp:GridView ID="GvConvocatorias" ClientIDMode="Static" runat="server" GridLines="None"
                        DataKeyNames="idConvocatoria,Convocatoria,idPais,FechaI,FechaF,Duracion,Link,Info,idArea,idNivel"
                        CssClass="pure-table pure-table-horizontal ordenar"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre de Convocatoria" DataField="Convocatoria" SortExpression="Convocatoria" />
                            <asp:BoundField HeaderText="Vigencia" DataField="Vigencia" SortExpression="Vigencia" />
                            <asp:BoundField HeaderText="País" DataField="Pais" SortExpression="Pais" />
                            <asp:BoundField HeaderText="Duración de Intercambio" DataField="Duracion" SortExpression="Duracion" />
                            <asp:BoundField HeaderText="Area de Estudio" DataField="AreaEstudio" SortExpression="AreaEstudio" />
                            <asp:BoundField HeaderText="Nivel" DataField="Nivel" SortExpression="Nivel" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" SortExpression="Estado" />
                            <asp:TemplateField HeaderText="Opciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkEditar" runat="server" OnClick="LnkEditar_Click" CssClass="btn btn-circle btn-sm btn-success " Text="<i class='fa fa-pencil'></i>"></asp:LinkButton>
                                    <asp:LinkButton ID="LnkDelete" runat="server" OnClick="LnkDelete_Click" CssClass="btn btn-circle btn-sm btn-danger " Text="<i class='fa fa-trash-o'></i>"></asp:LinkButton>
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
    <div id="DivConvocatoria" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="UpDivConvocatoria" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title" id="Titulo">Agregar Convocatoria</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-2 control-label " for="<%= TxtNombre.ClientID %>">Nombre:</label>
                                        <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control input-sm tam"></asp:TextBox>
                                    </div>
                                    <div class="form-group form-inline">
                                        <label class="col-lg-2 control-label" for="<%= DdlPais.ClientID %>">Pais:</label>
                                        <div class="input-group">
                                            <span class="input-group-btn">
                                                <button class="btn btn-default btn-sm btn-circle js-programmatic-open" type="button" data-select2-open="<%= DdlPais.ClientID %>">
                                                    <span class="glyphicon glyphicon-search"></span>
                                                </button>
                                            </span>
                                            <asp:DropDownList ID="DdlPais" runat="server" DataTextField="Pais" DataValueField="idPais" CssClass="form-control form-control select2me input-sm js-example-programmatic" Width="250px"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row" style="text-align: center">
                                        <label>Vigencia</label>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <label style="text-align: center" class="col-md-2 control-label" for="<%= txtFechaI.ClientID %>">Desde:</label>
                                                <div class="col-md-4">
                                                    <div class="input-group input-sm input-small date date-picker" data-date-format="dd/mm/yyyy" style="width: 140px !important; padding: 0px;">
                                                        <asp:TextBox ID="txtFechaI" runat="server" CssClass="form-control" CausesValidation="true" MaxLength="10"></asp:TextBox>
                                                        <span class="input-group-btn ">
                                                            <asp:LinkButton ID="imgCalendario" class="btn default " Text="<i class='fa fa-calendar'></i>" runat="server"></asp:LinkButton>
                                                        </span>
                                                        <ajaxToolkit:MaskedEditExtender ID="MEEFechaI" runat="server" TargetControlID="txtFechaI" Mask="99/99/9999" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"></ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender runat="server" ID="Calendario" TargetControlID="txtFechaI" PopupButtonID="ImgCalendario" PopupPosition="BottomRight" Enabled="True" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="rfvFechaI" runat="server" ControlToValidate="txtFechaI" Display="None" ErrorMessage="El campo <b>''Desde''</b> es requerido por la aplicación, por favor ingrese una fecha." ValidationGroup="Valida"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cvFechaI" runat="server" ControlToValidate="txtFechaI" Display="None" ErrorMessage="El campo <b>''Fecha Inicial''</b> no tienes el formato correcto, por favor intente de nuevo con el siguiente formato: (dd/mm/yyyy)." Operator="DataTypeCheck" Type="Date" ValidationGroup="Valida"></asp:CompareValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcoFfvFI" runat="server" HighlightCssClass="vco" TargetControlID="rfvFechaI" Width="350px"></ajaxToolkit:ValidatorCalloutExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcoCvFI" runat="server" HighlightCssClass="vco" TargetControlID="cvFechaI" Width="350px"></ajaxToolkit:ValidatorCalloutExtender>
                                                    </div>
                                                </div>
                                                <label style="text-align: center" class="col-md-2 control-label" for="<%= txtFechaF.ClientID %>">Hasta:</label>
                                                <div class="col-md-4">
                                                    <div class="input-group input-sm input-small date date-picker " data-date-format="dd/mm/yyyy" style="width: 140px !important; padding: 0px;">
                                                        <asp:TextBox ID="txtFechaF" runat="server" CssClass="form-control" CausesValidation="true" MaxLength="10"></asp:TextBox>
                                                        <span class="input-group-btn ">
                                                            <asp:LinkButton ID="imgCalendarioF" class="btn default " Text="<i class='fa fa-calendar'></i>" runat="server"></asp:LinkButton>
                                                        </span>
                                                        <ajaxToolkit:MaskedEditExtender ID="MEEFechaF" runat="server" TargetControlID="txtFechaF" Mask="99/99/9999" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"></ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender runat="server" ID="Calendario2" TargetControlID="txtFechaF" PopupButtonID="imgCalendarioF" PopupPosition="BottomRight" Enabled="True" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="rfvFechaF" runat="server" ControlToValidate="txtFechaF" Display="None" ErrorMessage="El campo <b>''Hasta''</b> es requerido por la aplicación, por favor ingrese una fecha." ValidationGroup="Valida"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cvFechaF" runat="server" ControlToValidate="txtFechaF" Display="None" ErrorMessage="El campo <b>''Fecha Final''</b> no tienes el formato correcto, por favor intente de nuevo con el siguiente formato: (dd/mm/yyyy)." Operator="DataTypeCheck" Type="Date" ValidationGroup="Valida"></asp:CompareValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcoRfvFF" runat="server" HighlightCssClass="vco" TargetControlID="rfvFechaF" Width="350px"></ajaxToolkit:ValidatorCalloutExtender>
                                                        <ajaxToolkit:ValidatorCalloutExtender ID="vcoCvFF" runat="server" HighlightCssClass="vco" TargetControlID="cvFechaF" Width="350px"></ajaxToolkit:ValidatorCalloutExtender>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group form-inline">
                                        <label class="col-lg-2 control-label" for="<%= DdlDuracion.ClientID %>">Duración:</label>
                                        <asp:DropDownList ID="DdlDuracion" runat="server" CssClass="form-control input-sm tam">
                                            <asp:ListItem Text="1 Año" Value="1 año"></asp:ListItem>
                                            <asp:ListItem Text="2 Años" Value="2 años"></asp:ListItem>
                                            <asp:ListItem Text="3 Años" Value="3 años"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group form-inline">
                                        <label class="col-lg-2 control-label" for="<%= DdlNivel.ClientID %>">Nivel:</label>
                                        <asp:DropDownList ID="DdlNivel" runat="server" DataValueField="idNivel" DataTextField="Nivel" CssClass="form-control input-sm tam">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group form-inline">
                                        <label class="col-lg-2 control-label" for="<%= DdlAreas.ClientID %>">Area:</label>
                                        <asp:DropDownList ID="DdlAreas" DataTextField="AreaEstudio" DataValueField="idArea" runat="server" CssClass="form-control input-sm tam">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group form-inline">
                                        <label class="col-lg-2 control-label " for="<%= TxtLink.ClientID %>">Link:</label>
                                        <asp:TextBox ID="TxtLink" runat="server" CssClass="form-control input-sm tam"></asp:TextBox>
                                    </div>
                                    <div class="form-group form-horizontal">
                                        <label class="control-label " for="<%= TxtInfo.ClientID %>">Información Adicional:</label>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:TextBox ID="TxtInfo" TextMode="MultiLine" runat="server" CssClass="form-control input-sm tam"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnConvocatoria" runat="server" class="btn btn-success" Text="Aceptar" ValidationGroup="GrpConvocatoria" />
                            <button id="BtnCancelar" runat="server" type="button" class="btn default" data-dismiss="modal">Cancelar</button>
                        </div>
                        <asp:HiddenField ID="HdnModalidad" runat="server" Value="A" ClientIDMode="Static" />
                        <asp:HiddenField ID="HdnID" runat="server" Value="-1" ClientIDMode="Static" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="DivEliminar" class="modal fade">
        <div class="modal-dialog modal-sm">
            <asp:UpdatePanel ID="UpEliminar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Eliminar</h4>
                        </div>
                        <div class="modal-body">
                            <h4>¿Desea eliminar la convocatoria?</h4>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnEliminar" runat="server" class="btn btn-danger" Text="Eliminar" ValidationGroup="GrpConvocatoria" />
                            <button type="button" class="btn default" data-dismiss="modal">Cancelar</button>
                        </div>
                        <asp:HiddenField ID="HdnIDEliminar" runat="server" Value="-1" ClientIDMode="Static" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>


