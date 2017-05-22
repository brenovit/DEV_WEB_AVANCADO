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

    protected void btn1_Click(object sender, EventArgs e)
    {
        SireneConcreta sirene = new SireneConcreta();
        OperarioConcreto obs1 = new OperarioConcreto(sirene);
        OperarioConcreto obs2 = new OperarioConcreto(sirene);
        OperarioConcreto obs3 = new OperarioConcreto(sirene);
        OperarioConcreto obs4 = new OperarioConcreto(sirene);
        OperarioConcreto obs5 = new OperarioConcreto(sirene);

        sirene.alteraAlerta();
        sirene.alteraAlerta();
        sirene.alteraAlerta();
        sirene.alteraAlerta();

    }
    

    protected void btn2_Click(object sender, EventArgs e)
    {
        TesteDelegate testa = new TesteDelegate();
        lblResultado.Text = "" + testa.getNum();
    }
}