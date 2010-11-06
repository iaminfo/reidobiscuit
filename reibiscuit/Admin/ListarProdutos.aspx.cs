using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using reibiscuit.Bussiness.Model;
using reibiscuit.Bussiness;

namespace reibiscuit.Admin
{
    public partial class ListarProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarProdutos();
            }
        }

        private void CarregarProdutos()
        {
            IList<Produto> lista = NProduto.RecuperarProdutos();
            if (lista.Count == 0)
            {
                Mensagem.EscreverMensagem(Mensagem.TiposMensagem.Info, divMensagem, "Nenhum Produto encontrado.");
                return;
            }
            gvProdutos.DataSource = lista;
            gvProdutos.DataBind();

        }

        protected void gvProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            LinkButton lDelete = e.Row.FindControl("lDelete") as LinkButton;
            lDelete.OnClientClick = "return confirm('Tem certeza que deseja excluir o Produto?')";
        }

        protected void bIncluir_Click(object sender, EventArgs e)
        {
            Session.Add("IdProduto", 0);
            Response.Redirect("EditarProduto.aspx", true);
        }

        protected void gvProdutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LinkButton lDelete = (LinkButton)gvProdutos.Rows[e.RowIndex].FindControl("lDelete");
            Produto p = NProduto.RecuperarProduto(int.Parse(lDelete.CommandArgument));
            NProduto.Apagar(p);
            CarregarProdutos();
        }

        protected void gvProdutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            LinkButton lAlterar = (LinkButton)gvProdutos.Rows[e.NewEditIndex].FindControl("lAlterar");
            Session.Add("IdProduto", lAlterar.CommandArgument);
            Response.Redirect("EditarProduto.aspx", true);
        }
    }
}