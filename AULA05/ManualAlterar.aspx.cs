using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManualAlterar : System.Web.UI.Page
{
    private ProdutoBLL prodBll = new ProdutoBLL();
    private ManualBLL manuBll = new ManualBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool isView = bool.Parse(Session["isView"].ToString());
            lblId.Text = Session["idProduto"].ToString();
            dropDownProdutos.DataSource = prodBll.buscaTodos(new ProdutoDTO()).ToList();
            dropDownProdutos.DataTextField = "dsdescricao";
            dropDownProdutos.DataValueField = "idProduto";
            dropDownProdutos.DataBind();
            if (!lblId.Text.Equals(""))
            {
                ManualDTO manu = new ManualDTO();
                manu.idManual = Convert.ToInt32(lblId.Text);
                manu = manuBll.buscaPorID(manu);
                MostrarManualTela(manu);
                btnSalvar.Visible = !isView;
            }
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProdutoListagem.aspx");
    }
    private void MostrarManualTela(ManualDTO manu)
    {
        dropDownProdutos.Text = manu.prod.idProduto.ToString();
        txtDescricao.Text = manu.dsDescricao;
        txtValidade.Text = manu.dtValidade.ToShortDateString();
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        ManualDTO manu = MontaManual();

        if (lblId.Text.Equals(""))
        {
            manuBll.cadastrar(manu);
        }
        else
        {
            manu.idManual = Convert.ToInt32(lblId.Text);
            manuBll.alterar(manu);
        }
        Response.Redirect("~/ProdutoListagem.aspx");
    }

    protected ManualDTO MontaManual()
    {
        ProdutoDTO prod = new ProdutoDTO();
        prod.idProduto = int.Parse(dropDownProdutos.Text);
        ManualDTO manu = new ManualDTO();
        manu.dtValidade = string.IsNullOrWhiteSpace(txtValidade.Text) ? DateTime.Today : Convert.ToDateTime(txtValidade.Text);
        manu.dsDescricao = txtDescricao.Text;
        manu.prod = prod;
        return manu;
    }

    
}