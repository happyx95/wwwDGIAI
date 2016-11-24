<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de administracion DGIAI</title>   
    <link rel="shortcut icon" type="image/x-icon" href="icono.png" />
    <link rel="stylesheet" href="http://servicios.sonora.gob.mx/scripts/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="http://servicios.sonora.gob.mx/scripts/bootstrap/css/bootstrap-theme.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.3/css/font-awesome.min.css" />
    <%--    <link rel="stylesheet" href="http://servicios.sonora.gob.mx/scripts/bootstrap/fonts/font-awesome/css/font-awesome.min.css" />--%>
    <link href="http://keenthemes.com/preview/metronic/theme/assets/pages/css/login.min.css" rel="stylesheet" type="text/css" />
    <link href="http://keenthemes.com/preview/metronic/theme/assets/pages/css/login-3.min.css" rel="stylesheet" type="text/css" />
    <script src="http://servicios.sonora.gob.mx/scripts/jquery-1.11.1.min.js"></script>
    <script src="http://servicios.sonora.gob.mx/scripts/bootstrap/js/bootstrap.min.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <script src="http://keenthemes.com/preview/metronic/theme/assets/pages/scripts/login.min.js" type="text/javascript"></script>
    <style type="text/css">
        .login {
            background-color: #d21f1f !important;
        }

        body, html {
            font-family: 'Lato', sans-serif;
            font-size: 14px;
            height: inherit;
            background: #f2f2f2;
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
                width: 50%;
                height: 50%;
                min-width: 200px;
                max-width: 400px;
                padding: 40px;
            }
    </style>
    <link rel="stylesheet" href="http://alertifyjs.com/build/css/alertify.css" />
    <link rel="stylesheet" href="http://alertifyjs.com/build/css/themes/default.css" />
    <link rel="stylesheet" href="http://alertifyjs.com/css/normalize.min.css" />
    <script defer="defer" src="http://alertifyjs.com/build/alertify.js"></script>
    <script defer="defer" src="http://alertifyjs.com/scripts/script.js"></script>
    <script defer="defer" src="http://alertifyjs.com/js/semantic.min.js"></script>
    <script defer="defer" src="http://alertifyjs.com/js/jquery.mobile.custom.min.js"></script>
    <script type="text/javascript" src="Scripts/Alertas.js"></script>
</head>
<body class="login">
    <div class="container-fluid_">
        <div class="row">
            <nav id="header" class="navbar navbar-default" role="navigation">
                <div class="navbar-header">
                    <a class="navbar-brand">&nbsp&nbsp&nbsp&nbsp
                         <h2>Sistema de Administración DGIAI</h2>
                    </a>
                </div>
                <img alt="Sistema de Administración DGIAI" class="pull-right" src="http://www.sec.gob.mx/dgiai/images/logo-dgiai.png" />
            </nav>
            <div class="container-fluid" style="margin-top: 7% !important; margin-bottom: 7%!important;">
                <div class="content">
                    <form id="form1" runat="server" class="login-form">
                        <asp:ScriptManager ID="TSM" runat="server" EnableHistory="true" EnableSecureHistoryState="true" ScriptMode="Release" EnableScriptGlobalization="true" AsyncPostBackTimeout="600">
                            <CompositeScript>
                                <Scripts>
                                </Scripts>
                            </CompositeScript>
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpLogin" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <h3 class="form-title">Inicia sesion</h3>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-1">
                                            <i class="fa fa-user" style="font-size: x-large"></i>
                                        </div>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TxtUsuario" runat="server" placeholder="Usuario" CssClass="form-control input-sm placeholder-no-fix"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFVUsuario" runat="server" Display="None" ControlToValidate="TxtUsuario" ErrorMessage="El campo usuario es necesario" ValidationGroup="GrpLogin"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="VCEUsuario" runat="server" HighlightCssClass="VCO" TargetControlID="RFVUsuario" Width="300px"></ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-1">
                                            <i class="fa fa-key" style="font-size: x-large"></i>
                                        </div>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" placeholder="Contraseña" CssClass="form-control input-sm placeholder-no-fix"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFVPassword" runat="server" Display="None" ControlToValidate="TxtPassword" ErrorMessage="El campo contraseña es necesario" ValidationGroup="GrpLogin"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="VCOPassword" runat="server" HighlightCssClass="VCO" TargetControlID="RFVPassword" Width="300px"></ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            <%--    <div class="form-group">
                                    <div class="row">
                                        <div style="text-align: left;" class="col-md-12">
                                            <asp:CheckBox ID="ChkTemporal" runat="server" CssClass="checkbox checkbox-inline" Text="Agregar Usuario" AutoPostBack="false" />
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12" style="text-align: center">
                                            <asp:Button ID="BtnIngresar" runat="server" CssClass="btn btn-primary" Text="Ingresar" ValidationGroup="GrpLogin" />
                                        </div>
                                    </div>
                                    <div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </form>
                </div>
            </div>
            <section id="footer" class="footer">
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <footer>
                            <div style="text-align: center" class="copyright">
                                <p class="text-center">
                                    <img width="200" height="25" src="http://www.sonora.gob.mx/images/dap-rets/unidos-logramos-mas.png" />
                                </p>
                                <p>
                                    <strong>Gobierno del Estado de Sonora</strong>
                                    <br />
                                </p>
                            </div>
                        </footer>
                    </div>
                </div>
            </section>
        </div>
    </div>

</body>
</html>
