using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageIMC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtAltura.Text = "";
            txtPeso.Text = "";
            panelAlerta.Visible = false;
            labelAlerta.Text = "";
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["peso"] = Convert.ToDouble(txtPeso.Text);
            Session["altura"] = Convert.ToDouble(txtAltura.Text);
            Response.Redirect("/pageIMCResultado.aspx");
        }
        catch(Exception ex)
        {
            Alerta(string.Format("ERRO! {0} | {1}","Erro ao enviar os dados.",ex.Message));
        }
    }

    public void Alerta(string mensagem)
    {
        panelAlerta.Visible = true;
        labelAlerta.Text = mensagem;
    }
}