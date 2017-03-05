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

    protected void LnkEditPais_Click(object sender, EventArgs e)
    {
        string pais = DdlPais.SelectedItem.Text;
        TxtEditarPais.Text = pais;
        HdnIDPais.Value = DdlPais.SelectedValue;
        
        UpEditPais.Update();
        UpDatos.Update();
        RegistraScript(this, "$('#DivEditarPais').modal('show');");
    }


    protected void LnkEditArea_Click(object sender, EventArgs e)
    {
        string area = DdlArea.SelectedItem.Text;
        TxtEditArea.Text = area;
        HdnIDArea.Value = DdlArea.SelectedValue;
       
        UpEditArea.Update();
        UpDatos.Update();

        RegistraScript(this, "$('#DivEditarArea').modal('show');");
    }

    protected void BtnEliminarArea_Click(object sender, EventArgs e)
    {
        var objDatos = new ConDatos();
        if (objDatos.deleteArea(DdlArea.SelectedValue.ToEntero()))
        {
            Notificar(this, "Area de estudio eliminada correctamente", TipoMensaje.Informacion);
            DtAreas = objDatos.getAreas();
            DdlArea.DataSource = DtAreas;
        }
        else
        {
            Notificar(this, "Ocurrio un error al eliminar el area de estudio", TipoMensaje.Error);
        }
        objDatos.Dispose();
        DdlArea.DataBind();
        UpDatos.Update();
        RegistraScript(this, "$('#DivEliminarArea').modal('hide');");
    }

    protected void BtnEliminarPais_Click(object sender, EventArgs e)
    {
        var objDatos = new ConDatos();
        if (objDatos.deletePais(DdlPais.SelectedValue.ToEntero()))
        {
            Notificar(this, "Pais eliminado correctamente", TipoMensaje.Informacion);
            DtPaises = objDatos.getPaises();
            DdlPais.DataSource = DtPaises;
        }
        else
        {
            Notificar(this, "Ocurrio un error al eliminar el pais", TipoMensaje.Error);
        }
        objDatos.Dispose();
        DdlPais.DataBind();
        UpDatos.Update();
        RegistraScript(this, "$('#DivEliminarPais').modal('hide');");
    }

    protected void BtnEditPais_Click(object sender, EventArgs e)
    {
        if (TxtEditarPais.Text.Trim() != "")
        {
            var objDatos = new ConDatos();
            if (objDatos.updatePais(HdnIDPais.Value.ToEntero(),TxtEditarPais.Text.Trim()))
            {
                Notificar(this, "El pais se modifico correctamente", TipoMensaje.Informacion);
                DtPaises = objDatos.getPaises();
                DdlPais.DataSource = DtPaises;
            }
            else
            {

                Notificar(this, "Ocurrio un error al modificar el pais", TipoMensaje.Error);
            }
            objDatos.Dispose();
            DdlPais.DataBind();
            UpDatos.Update();

        }

        RegistraScript(this, "$('#DivEditarPais').modal('hide');");
    }

    protected void BtnEditArea_Click(object sender, EventArgs e)
    {
        if (TxtEditArea.Text.Trim() != "")
        {
            var objDatos = new ConDatos();
            if (objDatos.updateArea(HdnIDArea.Value.ToEntero(), TxtEditArea.Text.Trim()))
            {
                Notificar(this, "El area de estudio se modifico correctamente", TipoMensaje.Informacion);
                DtAreas = objDatos.getAreas();
                DdlArea.DataSource = DtAreas;
            }
            else
            {

                Notificar(this, "Ocurrio un error al modificar el area de estudio", TipoMensaje.Error);
            }
            objDatos.Dispose();
            DdlArea.DataBind();
            UpDatos.Update();

        }

        RegistraScript(this, "$('#DivEditarArea').modal('hide');");
    }
}