using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageIMCResultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CalcularIMC();
        }
    }

    private void CalcularIMC()
    {
        try
        {
            IMC imc = new IMC();

            imc.Altura = (double)Session["altura"];
            imc.Peso = (double)Session["peso"];

            double resultado = imc.Calcular();

            string mensagem = "";

            if (resultado < 17)
                mensagem = "IMC: " + resultado.ToString("N") + " - Muito abaixo do peso";
            else if (resultado > 17 && resultado < 18.49)
                mensagem = "resultado: " + resultado.ToString("N") + " - Abaixo do peso";
            else if (resultado > 18.5 && resultado < 24.99)
                mensagem = "resultado: " + resultado.ToString("N") + " - Peso normal";
            else if (resultado > 25 && resultado < 29.99)
                mensagem = "resultado: " + resultado.ToString("N") + " - Acima do peso";
            else if (resultado > 30 && resultado < 34.99)
                mensagem = "resultado: " + resultado.ToString("N") + " - Obesidade I";
            else if (resultado > 35 && resultado < 39.99)
                mensagem = "resultado: " + resultado.ToString("N") + " - Obesidade II (severa)";
            else
                mensagem = "resultado: " + resultado.ToString("N") + " - Obesidade III (mórbida)";

            labelIMC.Text = mensagem;
        }
        catch (Exception ex)
        {
            Alerta(string.Format("ERRO! {0} | {1}", "Erro ao calcular IMC.", ex.Message));
        }

    }

    protected void btnVoltarPrincipal_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }

    protected void btnVoltarCalculo_Click(object sender, EventArgs e)
    {
        Response.Redirect("/pageIMC.aspx");
    }

    public void Alerta(string mensagem)
    {
        panelAlerta.Visible = true;
        labelAlerta.Text = mensagem;
    }
}