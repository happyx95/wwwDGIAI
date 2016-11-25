<%@ Page Title="Registro de Usuarios" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CatUsuarios.aspx.cs" Inherits="CatUsuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CSS" runat="Server">

    <script type="text/javascript">
        function SetValue(Hidden, Value) {
            document.getElementById(Hidden).value = Value;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="Server">
    <div class="row" style="vertical-align: central; display: inline">
        <div class="col-md-6" style="text-align: left;">
            <div class="form-group form-inline">
                <asp:HyperLink ID="HplNueva" runat="server" NavigateUrl="javascript:$('#DivUsuario').modal('show');$('#Titulo').text('Agregar Usuario');SetValue('HdnModalidad', 'A');$('#Contenido_CambioContraseña').hide();" CssClass="btn btn-lg btn-circle" Text="<i class='fa fa-plus-circle fa-2x'></i>"></asp:HyperLink>
                <label class="control-label">Nuevo Usuario</label>
            </div>
        </div>
        <div class="col-md-6" style="text-align: left">
            <br />
            <div class="form-group form-inline">
                <label class="col-md-2 control-label " for="TxtBusqueda2" style="width: 100px">Buscar:</label>
                <input type="text" id="TxtBusqueda2" class="form-control input-sm tam" onkeyup="<%= String.Format("FiltrarTabla('TxtBusqueda2','{0}')", GvUsuarios.ClientID) %>" />
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpUsuarios" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GvUsuarios" runat="server" GridLines="None" ClientIDMode="Static"
                        DataKeyNames="idUsuario,idRol,Username,Contrasenia,Rol"
                        CssClass="pure-table pure-table-horizontal ordenar"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Usuario" DataField="Username" />
                            <asp:BoundField HeaderText="Rol" DataField="Rol" />
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
    <div id="DivUsuario" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="UpDivUsuario" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title" id="Titulo">Agregar Usuario</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group form-inline">
                                        <label class="col-lg-3 control-label " for="<%= TxtNombre.ClientID %>">Nombre:</label>
                                        <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control input-sm tam" ValidationGroup="GrpUsuario"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVA" runat="server" ControlToValidate="TxtNombre" Display="None" ErrorMessage="<b><span style='text-decoration: underline'>ERROR:</span></b><br />El campo <b>''Nombre''</b> es necesario, por favor ingréselo." ValidationGroup="GrpUsuario"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group form-inline">
                                        <label class="col-lg-3 control-label" for="<%= DdlRol.ClientID %>">Rol:</label>
                                        <asp:DropDownList ID="DdlRol" runat="server" DataValueField="idRol" DataTextField="Rol" Width="280px" CssClass="form-control input-sm tam select2me">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group form-inline">
                                        <label class="col-lg-3 control-label " for="<%= TxtNombre.ClientID %>">Contraseña:</label>
                                        <asp:TextBox ID="TxtPass" runat="server" TextMode="Password" CssClass="form-control input-sm tam" ValidationGroup="GrpUsuario"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtPass" Display="None" ErrorMessage="<b><span style='text-decoration: underline'>ERROR:</span></b><br />El campo <b>''Contraseña''</b> es necesario, por favor ingréselo." ValidationGroup="GrpUsuario"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group form-inline">
                                        <label class="col-lg-3 control-label " for="<%= TxtConfir.ClientID %>">Confirmar Contraseña:</label>
                                        <asp:TextBox ID="TxtConfir" runat="server" TextMode="Password" CssClass="form-control input-sm tam" ValidationGroup="GrpUsuario"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtConfir" Display="None" ErrorMessage="<b><span style='text-decoration: underline'>ERROR:</span></b><br />El campo <b>''Confirmar contraseña''</b> es necesario, por favor ingréselo." ValidationGroup="GrpUsuario"></asp:RequiredFieldValidator>
                                    </div>
                                    <div id="CambioContraseña" runat="server" visible="false" >
                                        <div class="form-group form-inline">
                                            <asp:CheckBox ID="ChkCambio" runat="server" Enabled="true" AutoPostBack="true" Checked="false" Text="Cambiar contraseña" OnCheckedChanged="ChkCambio_CheckedChanged" ClientIDMode="Static" CssClass="checkbox checkbox-inline" />
                                            
                                        </div>
                                        <div class="form-group form-inline" id="DivNueva" runat="server" visible="false">
                                            <label class="col-lg-3 control-label " for="<%= TxtNombre.ClientID %>">Nueva Contraseña:</label>
                                            <asp:TextBox ID="TxtNuevaPass" runat="server" TextMode="Password" CssClass="form-control input-sm tam" ValidationGroup="GrpUsuario"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtPass" Display="None" ErrorMessage="<b><span style='text-decoration: underline'>ERROR:</span></b><br />El campo <b>''Contraseña''</b> es necesario, por favor ingréselo." ValidationGroup="GrpUsuario"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group form-inline" id="DivNuevaConf" runat="server" visible ="false">
                                            <label class="col-lg-3 control-label " for="<%= TxtConfir.ClientID %>">Confirmar Nueva Contraseña:</label>
                                            <asp:TextBox ID="TxtNuevaPassConf" runat="server" TextMode="Password" CssClass="form-control input-sm tam" ValidationGroup="GrpUsuario"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtConfir" Display="None" ErrorMessage="<b><span style='text-decoration: underline'>ERROR:</span></b><br />El campo <b>''Confirmar contraseña''</b> es necesario, por favor ingréselo." ValidationGroup="GrpUsuario"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnUsuario" runat="server" class="btn btn-danger" OnClick="BtnUsuario_Click1" Text="Aceptar y salir" />
                            <asp:Button ID="BtnUsuarioSeguir" runat="server" class="btn btn-success" OnClick="BtnUsuarioSeguir_Click1" Text="Aceptar y continuar" />
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
        <div class="modal-dialog ">
            <asp:UpdatePanel ID="UpEliminar" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Eliminar</h4>
                        </div>
                        <div class="modal-body">
                            <h4>¿Desea eliminar este usuario?</h4>
                        </div>
                        <div class="form-group form-inline">
                            <label class="col-lg-3 control-label " for="<%= TxtNombre.ClientID %>">Contraseña:</label>
                            <asp:TextBox ID="TxtPassEliminar" runat="server" TextMode="Password" CssClass="form-control input-sm tam" ValidationGroup="GrpUsuarioE"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPassEliminar" Display="None" ErrorMessage="<b><span style='text-decoration: underline'>ERROR:</span></b><br />El campo <b>''Contraseña''</b> es necesario, por favor ingréselo." ValidationGroup="GrpUsuario"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group form-inline">
                            <label class="col-lg-3 control-label " for="<%= TxtNombre.ClientID %>">Confirmar Contraseña:</label>
                            <asp:TextBox ID="TxtConfirEliminar" runat="server" TextMode="Password" CssClass="form-control input-sm tam" ValidationGroup="GrpUsuarioE"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtConfirEliminar" Display="None" ErrorMessage="<b><span style='text-decoration: underline'>ERROR:</span></b><br />El campo <b>''Contraseña''</b> es necesario, por favor ingréselo." ValidationGroup="GrpUsuario"></asp:RequiredFieldValidator>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click1" class="btn btn-danger" Text="Eliminar" />
                            <button type="button" class="btn default" data-dismiss="modal">Cancelar</button>
                        </div>
                        <asp:HiddenField ID="HdnIDEliminar" runat="server" Value="-1" ClientIDMode="Static" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>


