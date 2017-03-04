using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NovaPagina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //pega os parametros enviados pela url via Query String
        lbl1.Text = "Conteudo: Nome = " + Request.Params.Get("idNome") + " | Idade = " + Request.Params.Get("idIdade");
        lbl2.Text = "Conteudo: Nome = " + Session["idNome"] + " | Idade = " + Session["idIdade"];
    }

    protected void btnVolta_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
}