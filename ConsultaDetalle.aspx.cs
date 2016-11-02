using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Extensiones.Extensiones;

public partial class ConsultaDetalle : PaginaWeb
{
    public int idPais { get { return ViewState["idPais"].ToString().ToEntero(); } set { ViewState["idPais"] = value; } }
    public int idArea { get { return ViewState["idArea"].ToString().ToEntero(); } set { ViewState["idArea"] = value; } }
    public int idNivel { get { return ViewState["idNivel"].ToString().ToEntero(); } set { ViewState["idNivel"] = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["P"] != null)
            {
                var UrlParametros = Parametros(Decripta(Request["P"].ToString()));
                idPais = UrlParametros["IDPAIS"].ToString().ToEntero();
                idNivel = UrlParametros["IDNIVEL"].ToString().ToEntero();
                idArea = UrlParametros["IDAREA"].ToString().ToEntero();
                CargaDatos();
            }
        }
    }
    private Hashtable Parametros(string cadena)
    {
        Hashtable URLParametros = new Hashtable();
        string[] p1 = cadena.Split('&');
        string[] p2;
        foreach (string tmp in p1)
        {
            p2 = tmp.Split('=');
            URLParametros.Add(p2[0].ToString().ToUpper(), p2[1]);
        }
        return URLParametros;
    }
    private void CargaDatos()
    {
        var ObjDatos = new ConDatos();
        var ObjConvocatorias = new ConConvocatorias(ObjDatos.startTransactionSQL());

        DdlNivel.DataSource = ObjDatos.getNiveles();
        DdlArea.DataSource = ObjDatos.getAreas();
        DdlPais.DataSource = ObjDatos.getPaises();

        DdlPais.DataBind();
        DdlArea.DataBind();
        DdlNivel.DataBind();

        GvConvocatorias.DataSource = ObjConvocatorias.getConsultaConvocatorias(idPais, idNivel, idArea);
        GvConvocatorias.DataBind();
        ObjDatos.Commit();
        ObjDatos.Dispose();

        DdlArea.SelectedValue = idArea.ToString();
        DdlNivel.SelectedValue = idNivel.ToString();
        DdlPais.SelectedValue = idPais.ToString();
    }


    protected void BtnInfo_Click(object sender, EventArgs e)
    {
        var BtnInfo = sender as Button;
        var GvRow = BtnInfo.NamingContainer as GridViewRow;
        LblInfo.Text = GvRow.DataKey("Info");
        RegistraScript(this, "$('#DivInfo').modal('show')");
    }
}