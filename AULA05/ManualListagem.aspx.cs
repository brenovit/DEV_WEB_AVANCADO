using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManualListagem : System.Web.UI.Page
{
    private ManualBLL manuBll = new ManualBLL();
    private ProdutoBLL prodBll = new ProdutoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarGrid(MontaManual());
        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        ManualDTO manu = MontaManual();
        CarregarGrid(manu);
    }

    protected void CarregarGrid(ManualDTO proTela)
    {       
        grdManual.DataSource = manuBll.buscaTodos(proTela);
        grdManual.DataBind();
    }

    protected ManualDTO MontaManual()
    {
        ManualDTO manu = new ManualDTO();
        manu.dsDescricao = txtDescricao.Text;
        manu.dtValidade = string.IsNullOrWhiteSpace(txtValidade.Text) ? DateTime.Today : Convert.ToDateTime(txtValidade.Text);
        dropDownProdutos.DataSource = prodBll.buscaTodos(new ProdutoDTO()).ToList();
        dropDownProdutos.DataTextField = "dsdescricao";
        dropDownProdutos.DataValueField = "idProduto";
        dropDownProdutos.DataBind();
        return manu;
    }

    protected void btnVisualizar_Click(object sender, EventArgs e)
    {
        Session["idManual"] = lblId.Text;
        Session["isView"] = true;
        Response.Redirect("~/ManualAlterar.aspx");
    }

    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Session["idManual"] = lblId.Text;
        Session["isView"] = false;
        Response.Redirect("~/ManualAlterar.aspx");
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        ManualDTO manu = new ManualDTO();
        manu.idManual = int.Parse(lblId.Text);
        manuBll.excluir(manu);
        lblId.Text = "";
        CarregarGrid(MontaManual());
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/mercadinho.aspx");
    }

    protected void btnInserir_Click(object sender, EventArgs e)
    {
        Session["idManual"] = "";
        Session["isView"] = false;
        Response.Redirect("~/ManualAlterar.aspx");
    }

    private void InseriManual(ManualDTO manu)
    {        
        manuBll.cadastrar(manu);
    }

    private void MostrarManualTela(ManualDTO manu)
    {
        ProdutoBLL bll = new ProdutoBLL();
        txtDescricao.Text = manu.dsDescricao;
        txtValidade.Text = manu.dtValidade.ToShortDateString();        
        //usa drop down list        
    }

    protected void grdManual_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = grdManual.SelectedIndex;
        lblId.Text = grdManual.DataKeys[index].Value.ToString();
    }

    protected void grdManual_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdManual.PageIndex = e.NewPageIndex;
        CarregarGrid(MontaManual());
    }

    protected void grdManual_RowDataBound(object sender, GridViewRowEventArgs e)
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