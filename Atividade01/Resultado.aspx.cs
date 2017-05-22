using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //pega os parametros enviados pela url via Query String
        
        double imc = Convert.ToDouble(Session["imc"].ToString());
        string mensagem = "";
        
        if (imc < 17)
            mensagem = "IMC: " + imc.ToString("N") + " - Muito abaixo do peso";
        else if (imc > 17 && imc < 18.49)
            mensagem = "IMC: " + imc.ToString("N") + " - Abaixo do peso";
        else if (imc > 18.5 && imc < 24.99)
            mensagem = "IMC: " + imc.ToString("N") + " - Peso normal";
        else if (imc > 25 && imc < 29.99)
            mensagem = "IMC: " + imc.ToString("N") + " - Acima do peso";
        else if (imc > 30 && imc < 34.99)
            mensagem = "IMC: " + imc.ToString("N") + " - Obesidade I";
        else if (imc > 35 && imc < 39.99)
            mensagem = "IMC: " + imc.ToString("N") + " - Obesidade II (severa)";
        else
            mensagem = "IMC: " + imc.ToString("N") + " - Obesidade III (mórbida)";

        lbl1.Text = mensagem;
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
}