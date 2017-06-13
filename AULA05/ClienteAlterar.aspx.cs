using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClienteAlterar : System.Web.UI.Page
{
    private ClienteBLL bll = new ClienteBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool isView = bool.Parse(Session["isView"].ToString());
            lblId.Text = Session["idCliente"].ToString();
            if (!lblId.Text.Equals(""))
            {
                ClienteDTO clie = new ClienteDTO();
                clie.idCliente = Convert.ToInt32(lblId.Text);
                clie = bll.buscaPorID(clie);
                MostrarClienteTela(clie);
                btnSalvar.Visible = !isView;
            }
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ClienteListagem.aspx");
    }
    private void MostrarClienteTela(ClienteDTO cli)
    {
        txtNome.Text = cli.dsNome;
        txtCpfCnpj.Text = cli.dsCPFCNPJ;
        txtNomeComum.Text = cli.dsNomeComum;
        txtVlCapital.Text = cli.vlCapital.ToString();
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        ClienteDTO clie = MontaCliente();
        if (lblId.Text.Equals(""))
        {
            bll.cadastrar(clie);
        }
        else
        {
            clie.idCliente = Convert.ToInt32(lblId.Text);
            bll.alterar(clie);
        }
        Response.Redirect("~/ClienteListagem.aspx");
    }

    protected ClienteDTO MontaCliente()
    {
        ClienteDTO cli = new ClienteDTO();
        cli.dsCPFCNPJ = txtCpfCnpj.Text;
        cli.dsNome = txtNome.Text;
        cli.dsNomeComum = txtNomeComum.Text;
        cli.vlCapital = txtVlCapital.Text.Trim() == "" ? 0 : Convert.ToDouble(txtVlCapital.Text);

        return cli;
    }
}