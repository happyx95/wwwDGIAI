using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

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

        //Insertar los seleccione
        DdlArea.Items.Insert(0, new ListItem("Todos","-1"));
        DdlPais.Items.Insert(0, new ListItem("Todos", "-1"));
        DdlNivelEstudio.Items.Insert(0, new ListItem("Todos", "-1"));
        DdlNivel.Items.Insert(0, new ListItem("Todos", "-1"));

        DdlPais.DataBind();
        DdlArea.DataBind();
        DdlNivel.DataBind();
        DdlNivelEstudio.DataBind();
        int indice = 0;
        for (int i = 15; i < 40; i++)
        {
            DdlEdad.Items.Insert(indice,new ListItem($"{i} años", i.ToString()));
            indice++;
        }

    }

    private void BtnBuscar_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"idNivel={DdlNivelEstudio.SelectedValue}&");
        sb.Append($"idArea={DdlArea.SelectedValue}&");
        sb.Append($"idPais={DdlPais.SelectedValue}");
        string url = $"ConsultaDetalle.aspx?P={Encripta(sb.ToString())}";
        Response.Redirect(url);
    }

}