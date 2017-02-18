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
        //txtNome.Text = "texto padrão";

        if (!IsPostBack)
        {            
            //txtNome.Text = "texto novo";
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string mensagem = "";
        try
        {
            double peso = Convert.ToDouble(txtPeso.Text);
            double altura = Convert.ToDouble(txtAltura.Text);
            double IMC = peso / (Math.Pow(altura, 2));           

            if (IMC < 17)
                mensagem = "IMC: " + IMC.ToString("N") + " - Muito abaixo do peso";
            else if (IMC > 17 && IMC < 18.49)
                mensagem = "IMC: " + IMC.ToString("N") + " - Abaixo do peso";
            else if (IMC > 18.5 && IMC < 24.99)
                mensagem = "IMC: " + IMC.ToString("N") + " - Peso normal";
            else if (IMC > 25 && IMC < 29.99)
                mensagem = "IMC: " + IMC.ToString("N") + " - Acima do peso";
            else if (IMC > 30 && IMC < 34.99)
                mensagem = "IMC: " + IMC.ToString("N") + " - Obesidade I";
            else if (IMC > 35 && IMC < 39.99)
                mensagem = "IMC: " + IMC.ToString("N") + " - Obesidade II (severa)";
            else
                mensagem = "IMC: " + IMC.ToString("N") + " - Obesidade III (mórbida)";
            
        }
        catch (Exception ex)
        {
            mensagem = "Impossível fazer o calculo. Verifique se os campos estão corretos.";
        }
        finally
        {
            lblResultado.Text = mensagem;
        }
    }
}
 