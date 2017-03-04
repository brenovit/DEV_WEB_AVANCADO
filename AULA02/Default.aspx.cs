using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Unica a = Unica.Instance;
        a.Nome = txtNome.Text;

        Unica b = Unica.instance;
        txtOutroNome.Text = b.Nome;
    }

    protected void btnVai_Click(object sender, EventArgs e)
    {
        string parametros = "";

        parametros = "idNome="+txtNome.Text;
        parametros += "&idIdade=" + txtOutroNome.Text;
        //envia os valores das variaveis concatenados na variavel parametros via url Query String
        Response.Redirect("/NovaPagina.aspx?"+parametros);
    }

    protected void btnOutro_Click(object sender, EventArgs e)
    {
        Session["idNome"] = txtNome.Text;
        Session["idIdade"] = txtOutroNome.Text;
        Response.Redirect("/NovaPagina.aspx");
    }
}