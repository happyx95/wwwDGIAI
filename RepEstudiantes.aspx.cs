using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RepEstudiantes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargaDatos();
        }
    }
    private void CargaDatos() {
        var ObjDatos = new ConDatos();
        GvConsultas.DataSource = ObjDatos.getConsultas();
        ObjDatos.Dispose();
        GvConsultas.DataBind();
    }
}