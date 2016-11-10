using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Extensiones.Extensiones;

public partial class Consulta : PaginaWeb
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
        BtnBuscar.Click += BtnBuscar_Click;
    }

    private void CargaDatos()
    {
        var ObjDatos = new ConDatos();
        var dtEstudios = ObjDatos.getNiveles();
        DdlNivel.DataSource = dtEstudios;
        DdlNivelEstudio.DataSource = dtEstudios;
        DdlArea.DataSource = ObjDatos.getAreas();
        DdlPais.DataSource = ObjDatos.getPaises();

        DdlPais.DataBind();
        DdlArea.DataBind();
        DdlNivel.DataBind();
        DdlNivelEstudio.DataBind();

        //Insertar los seleccione
        DdlArea.Items.Insert(0, new ListItem("Todos", "-1"));
        DdlPais.Items.Insert(0, new ListItem("Todos", "-1"));
        DdlNivel.Items.Insert(0, new ListItem("Todos", "-1"));

        int indice = 0;
        for (int i = 15; i < 40; i++)
        {
            DdlEdad.Items.Insert(indice,new ListItem($"{i} años", i.ToString()));
            indice++;
        }

    }

    private void BtnBuscar_Click(object sender, EventArgs e)
    {
        GuardarRegistroConsulta();
        StringBuilder sb = new StringBuilder();
        sb.Append($"idNivel={DdlNivelEstudio.SelectedValue}&");
        sb.Append($"idArea={DdlArea.SelectedValue}&");
        sb.Append($"idPais={DdlPais.SelectedValue}");
        string url = $"ConsultaDetalle.aspx?P={Encripta(sb.ToString())}";
        Response.Redirect(url);
    }
    private void GuardarRegistroConsulta()
    {
        var ObjDatos = new ConDatos();

        int idNivelActual = DdlNivelEstudio.SelectedValue.ToEntero();
        int idNivelInteres = DdlNivel.SelectedValue.ToEntero();
        int idArea = DdlArea.SelectedValue.ToEntero();
        int idPais = DdlPais.SelectedValue.ToEntero();
        int Edad = DdlEdad.SelectedValue.ToEntero();
        string sexo = DdlSexo.SelectedValue;

        ObjDatos.addConsulta(idPais, idArea, idNivelActual, idNivelInteres, sexo, Edad);
        ObjDatos.Dispose();
    }

}