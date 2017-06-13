using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClienteListagem : System.Web.UI.Page
{
    private ClienteBLL bll = new ClienteBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarGrid(MontaCliente());
        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        ClienteDTO cli = MontaCliente();
        CarregarGrid(cli);
    }

    protected void CarregarGrid(ClienteDTO cliTela)
    {       
        grdClientes.DataSource = bll.buscaTodos(cliTela);
        grdClientes.DataBind();
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

    protected void btnVisualizar_Click(object sender, EventArgs e)
    {
        Session["idCliente"] = lblId.Text;
        Session["isView"] = true;
        Response.Redirect("~/ClienteAlterar.aspx");
    }

    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Session["idCliente"] = lblId.Text;
        Session["isView"] = false;
        Response.Redirect("~/ClienteAlterar.aspx");
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        ClienteDTO cli = new ClienteDTO();
        cli.idCliente = int.Parse(lblId.Text);
        bll.excluir(cli);
        lblId.Text = "";
        CarregarGrid(MontaCliente());
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/mercadinho.aspx");
    }

    protected void btnInserir_Click(object sender, EventArgs e)
    {
        Session["idCliente"] = "";
        Session["isView"] = false;
        Response.Redirect("~/ClienteAlterar.aspx");
    }

    private void Insericliuto(ClienteDTO cli)
    {        
        bll.cadastrar(cli);
    }

    private void MostrarClienteTela(ClienteDTO cli)
    {
        txtNome.Text = cli.dsNome;
        txtCpfCnpj.Text = cli.dsCPFCNPJ;
        txtNomeComum.Text = cli.dsNomeComum;
        txtVlCapital.Text = cli.vlCapital.ToString();
    }

    protected void grdClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = grdClientes.SelectedIndex;
        lblId.Text = grdClientes.DataKeys[index].Value.ToString();
    }

    protected void grdClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdClientes.PageIndex = e.NewPageIndex;
        CarregarGrid(MontaCliente());
    }

    protected void grdClientes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        { 
            if (e.Row.RowState != DataControlRowState.Selected)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White';");
                e.Row.Attributes.Add("onmouseout", "this.style.color='Black';this.style.backgroundColor='White';");
            }            
        }
    }
}