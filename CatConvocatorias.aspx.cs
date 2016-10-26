using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Extensiones.Extensiones;

public partial class CatConvocatorias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GvConvocatorias.DataSource = DtEjemplo();
            GvConvocatorias.DataBind();
        }
    }
    private DataTable DtEjemplo() {
        DataTable dt = new DataTable();
        dt.Columns.Add("Convocatoria", typeof(string));
        dt.Columns.Add("Vigencia", typeof(string));
        dt.Columns.Add("Pais", typeof(string));
        dt.Columns.Add("Duracion", typeof(string));
        dt.Columns.Add("Estado", typeof(string));

        dt.Rows.Add("Prueba1", "nose", "Happylandia","2 años", "abierta");
        dt.Rows.Add("Prueba2", "nose", "Alemania","3 años", "cerrada");
        dt.Rows.Add("Prueba3", "nose", "España","1 año", "abierta");

        dt.AcceptChanges();
        return dt;
    }
}