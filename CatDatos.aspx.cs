using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Extensiones.Extensiones;

public partial class CatDatos : PaginaWeb
{
    private DataTable DtPaises { get { return (DataTable)ViewState["DtPaises"]; } set { ViewState["DtPaises"] = value; } }
    private DataTable DtAreas { get { return (DataTable)ViewState["DtAreas"]; } set { ViewState["DtAreas"] = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        initEvents();
        if (!IsPostBack)
        {
            CargaDatos();
        }
    }
    private void initEvents()
    {
        LnkArea.Click += LnkArea_Click;
        LbkPais.Click += LbkPais_Click;
    }
    private void CargaDatos()
    {
        var ObjDatos = new ConDatos();
        DtPaises = ObjDatos.getPaises();
        DtAreas = ObjDatos.getAreas();
        ObjDatos.Dispose();

        DdlPais.DataSource = DtPaises;
        DdlArea.DataSource = DtAreas;

        DdlPais.DataBind();
        DdlArea.DataBind();

        UpDatos.Update();
    }
    private void LbkPais_Click(object sender, EventArgs e)
    {
        string pais = TxtPais.Text.Trim();
        DataRow drPais = DtPaises.FiltroPrimero($" Pais like '%{pais}%'");
        if (drPais == null)
        {
            var ObjDatos = new ConDatos();
            if (ObjDatos.addPais(pais))
            {
                DtPaises = ObjDatos.getPaises();
                DdlPais.DataSource = DtPaises;
                Notificar(this, "El pais ha sido agregado correctamente", TipoMensaje.Informacion);
            }
            else
            {
                Notificar(this, "Ocurrio un error al agregar el pais", TipoMensaje.Error);
            }
            ObjDatos.Dispose();
            DdlPais.DataBind();
        }
        else
        {
            Notificar(this, "Ya existe el pais elegido", TipoMensaje.Error);
        }
        UpDatos.Update();
    }

    private void LnkArea_Click(object sender, EventArgs e)
    {
        string area = TxtArea.Text.Trim();
        DataRow dtArea = DtAreas.FiltroPrimero($" AreaEstudio like '%{area}%'");
        if (dtArea == null)
        {
            var ObjDatos = new ConDatos();
            if (ObjDatos.addArea(area))
            {
                DtAreas = ObjDatos.getAreas();
                DdlArea.DataSource = DtAreas;
                Notificar(this, "El area de estudio ha sido agregado correctamente", TipoMensaje.Informacion);
            }
            else
            {
                Notificar(this, "Ocurrio un error al agregar el area de estudio", TipoMensaje.Error);
            }
            ObjDatos.Dispose();
            DdlArea.DataBind();
        }
        else
        {
            Notificar(this, "Ya existe el area de estudio elegida", TipoMensaje.Error);
        }
        UpDatos.Update();
    }
}