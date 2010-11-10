using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using reibiscuit.Bussiness;
using reibiscuit.Bussiness.Model;

namespace reibiscuit
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
                Mensagem.EscreverMensagem(Mensagem.TiposMensagem.Info, Master.DivMensagem, "Nenhum Produto encontrado.");
                return;
            }
            gvProdutos.DataSource = lista;
            gvProdutos.DataBind();

        }
    }
}