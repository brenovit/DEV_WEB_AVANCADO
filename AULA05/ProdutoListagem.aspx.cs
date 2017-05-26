using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProdutoListagem : System.Web.UI.Page
{
    private ProdutoBLL bll = new ProdutoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        ProdutoDTO prod = MontaProduto();
        CarregarGrid(prod);
    }

    protected void CarregarGrid(ProdutoDTO proTela)
    {       
        grdProdutos.DataSource = bll.buscaTodos(proTela);
        grdProdutos.DataBind();
    }

    protected ProdutoDTO MontaProduto()
    {
        ProdutoDTO prod = new ProdutoDTO();
        prod.dsDescricao = txtDescricao.Text;
        prod.dsFornecedor = txtFornecedor.Text;
        prod.qtEstoque = txtEstoque.Text.Trim() == "" ? 0 : Convert.ToInt32(txtEstoque.Text);
        prod.vlValor = txtPreco.Text.Trim() == "" ? 0 : Convert.ToDouble(txtPreco.Text);       

        return prod;
    }

    protected void btnVisualizar_Click(object sender, EventArgs e)
    {        
        //bll.buscaPorID()
    }

    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Session["idProduto"] = lblId.Text;
        Response.Redirect("~/ProdutoAlterar.aspx");
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        ProdutoDTO prod = new ProdutoDTO();
        prod.idProduto = int.Parse(lblId.Text);
        bll.excluir(prod);
        CarregarGrid(MontaProduto());
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/mercadinho.aspx");
    }

    protected void btnInserir_Click(object sender, EventArgs e)
    {
        Session["idProduto"] = "";
        Response.Redirect("~/ProdutoAlterar.aspx");
    }

    private void InseriProduto(ProdutoDTO prod)
    {        
        bll.cadastrar(prod);
    }

    private void MostrarProdutoTela(ProdutoDTO prod)
    {
        txtDescricao.Text = prod.dsDescricao;
        txtFornecedor.Text = prod.dsFornecedor;
        txtEstoque.Text = prod.qtEstoque.ToString();
        txtPreco.Text = prod.vlValor.ToString();
    }

    protected void grdProdutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = grdProdutos.SelectedIndex;
        lblId.Text = grdProdutos.DataKeys[index].Value.ToString();
    }

    protected void grdProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdProdutos.PageIndex = e.NewPageIndex;
        CarregarGrid(MontaProduto());
    }

    protected void grdProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
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