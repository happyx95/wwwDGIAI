<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CSS" runat="server">
    <style>
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
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-md-6" style="text-align:center">
                                <asp:HyperLink ID="HplVer" runat="server" Target="_blank" NavigateUrl="~/Convocatorias.aspx" CssClass="btn btn-lg btn-circle" Text="<i class='fa fa-eye fa-4x'></i>"></asp:HyperLink>
                                 <h4>Ver</h4>
                            </div>
                            <div class="col-md-6" style="text-align:center">
                                <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/CatConvocatorias.aspx" CssClass="btn btn-lg btn-circle" Text="<i class='fa fa-plus-circle fa-4x'></i>"></asp:HyperLink>
                                <h4>Nueva</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
            </div>
        </div>
    </div>
</asp:Content>

