using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Extensiones.Extensiones;

public partial class CatConvocatorias : PaginaWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        initEvents();
        if (!IsPostBack)
        {
            CargaDatos();
        }
    }
    private void initEvents() {
        BtnConvocatoria.Click += BtnConvocatoria_Click;
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

    private void CargaDatos() {
        ConPaises ObjPaises = new ConPaises();
        DdlPais.DataSource = ObjPaises.getPaises();
        DdlPais.DataBind();
        ObjPaises.Dispose();
        GvConvocatorias.DataSource = DtEjemplo();
        GvConvocatorias.DataBind();
        UpConvocatorias.Update();
        
    }
    protected void BtnConvocatoria_Click(object sender, EventArgs e)
    {
        ConConvocatorias ObjConvocatorias = new ConConvocatorias();
        int idPais = DdlPais.SelectedValue.ToEntero();
        DateTime FechaI = txtFechaI.Text.ToDate();
        DateTime FechaF = txtFechaF.Text.ToDate();
        string duracion = DdlDuracion.SelectedValue;
        string link = TxtLink.Text.Trim();
        bool estado = true;
        string info = TxtInfo.Text;
        int idUsuario = Session["idUsuario"].ToString().ToEntero();
        if (ObjConvocatorias.addConvocatoria(idPais, FechaI, FechaF, duracion, link, estado, idUsuario,info))
        {
            Notificar(this, "Convocatoria agregada correctamente", TipoMensaje.Informacion);
        }
        ObjConvocatorias.Dispose();
    }
}