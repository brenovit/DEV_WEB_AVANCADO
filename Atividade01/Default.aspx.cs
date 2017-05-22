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
        if (!Page.IsPostBack)
        {

        }
    }
    
    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        
        double peso = Convert.ToDouble(txtPeso.Text);
        double altura = Convert.ToDouble(txtAltura.Text);
        IMC imc = new IMC(peso, altura);

        Session["imc"] = imc.Calculo();
        Response.Redirect("/Resultado.aspx");
    }
}