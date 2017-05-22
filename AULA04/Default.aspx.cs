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

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
       // lbResultado.Text = ddlMes.SelectedItem.Value;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        lbResultado.Text = ddlMes.SelectedItem.Value;
    }

    protected void btnIncluir_Click(object sender, EventArgs e)
    {
        if (lst1.SelectedIndex != -1) //Index porque retorna um inteiro
        {
            lst2.Items.Add(new ListItem(lst1.SelectedItem.Text, lst1.SelectedItem.Value));
            lst1.Items.Remove(lst1.SelectedItem);
        }
    }

    protected void btnRemover_Click(object sender, EventArgs e)
    {
        if(lst2.SelectedIndex != -1)
        {
            lst1.Items.Add(new ListItem(lst2.SelectedItem.Text, lst2.SelectedItem.Value));
            lst2.Items.Remove(lst2.SelectedItem);
        }
    }

    protected void btnTodos_Click(object sender, EventArgs e)
    {
        //lst1.Items.Add(new ListItem(lst2.SelectionMode));
    }
}