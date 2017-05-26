using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProdutoAlterar : System.Web.UI.Page
{
    private ProdutoBLL bll = new ProdutoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblId.Text = Session["idProduto"].ToString();
            if (!lblId.Text.Equals(""))
            {
                ProdutoDTO prod = new ProdutoDTO();
                prod.idProduto = Convert.ToInt32(lblId.Text);
                prod = bll.buscaPorID(prod);
                MostrarProdutoTela(prod);
            }
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/mercadinho.aspx");
    }
    private void MostrarProdutoTela(ProdutoDTO prod)
    {
        txtDescricao.Text = prod.dsDescricao;
        txtFornecedor.Text = prod.dsFornecedor;
        txtEstoque.Text = prod.qtEstoque.ToString();
        txtPreco.Text = prod.vlValor.ToString();
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        ProdutoDTO prod = MontaProduto();
        if (lblId.Text.Equals(""))
        {
            bll.cadastrar(prod);
        }
        else
        {
            prod.idProduto = Convert.ToInt32(lblId.Text);
            bll.alterar(prod);
        }
        Response.Redirect("~/ProdutoListagem.aspx");
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
}