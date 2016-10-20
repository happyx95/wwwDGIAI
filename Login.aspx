<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de administracion DGIAI</title>
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
    </style>
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
                <img alt="Sistema de Administración DGIAI" class="pull-right" src="http://www.sonora.gob.mx/images/logo-sonora-2015.png" />
            </nav>
            <div class="container-fluid" style="margin-top:7% !important; margin-bottom:7%!important;">
                <div class="content">
                    <form id="form1" runat="server" class="login-form">
                        <h3 class="form-title">Inicia sesion</h3>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-1">
                                    <i class="fa fa-user" style="font-size: x-large"></i>
                                </div>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TxtUsuario" runat="server" placeholder="Usuario" CssClass="form-control input-sm placeholder-no-fix"></asp:TextBox>
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
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="form-group">
                            <div class="row">
                                <div style="text-align:left;" class="col-md-12">
                                    <asp:CheckBox ID="ChkTemporal" runat="server" CssClass="checkbox checkbox-inline" Text="Agregar Usuario" AutoPostBack="false" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-12" style="text-align: center">
                                    <asp:Button ID="BtnIngresar" runat="server" CssClass="btn btn-primary" Text="Ingresar" />
                                </div>
                            </div>
                            <div>
                                
                            </div>
                        </div>
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
