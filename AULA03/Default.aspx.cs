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
            ddlOperacoes.Visible = false;
            ddlOperacoes.Items.Clear();             //limpa o drop down list
            ddlOperacoes.Items.Add("Soma");         //Adiciona itens no drop down list
            ddlOperacoes.Items.Add("Multiplicação");
            ddlOperacoes.Items.Add("Divisão");
            ddlOperacoes.Items.Add("Subtração");
        }            
    }

    protected void btnProcesso_Click(object sender, EventArgs e)
    {
        Pessoa pessoa = new Pessoa(txtValor1.Text, txtValor2.Text);
        /*
         * Errado muitas classes para instaciar, usar o facede para executar apenas um comando
        SPC spc = new SPC();
        spc.estaNoSpc(pessoa);
        Serasa serasa = new Serasa();
        serasa.estaNoSarasa(pessoa);
        */

        FacedeCredito facede = new FacedeCredito();
        lblResultado.Text = facede.VerificaFinanceiro(pessoa, Convert.ToDouble(txtValor3.Text));
    }

    protected void btnProcesso_Click2(object sender, EventArgs e)
    {
        int val1, val2;
        val1 = Convert.ToInt32(txtValor1.Text);
        val2 = Convert.ToInt32(txtValor2.Text);

        Operacao op = null;

        string result = "";

        string ope = ddlOperacoes.SelectedValue;    //pega o valor do drop down list

        if (txtValor3.Text.Equals("soma") || ope.Contains("So")) //verifica o valor do textbox ou se ope contain as letras(preguiça de digitar)
            op = new Soma();
        else if (txtValor3.Text.Equals("mult") || ope.Contains("Mu"))
            op = new Multiplicacao();
        else if (txtValor3.Text.Equals("subt") || ope.Contains("Su"))
            op = new Subtracao();
        else if (txtValor3.Text.Equals("divi") || ope.Contains("Di"))
            op = new Divisao();
        else
            result = "Operação Inválida";

        if (result.Equals(""))
        {
            result = "Resultado: " + op.EfetuaOperacao(val1, val2).ToString();
        }

        lblResultado.Text = result;
    }
}