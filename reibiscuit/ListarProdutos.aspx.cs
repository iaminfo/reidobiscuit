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
        private int? _idCategoria;
        private GridView gvImagens = new GridView();

        protected int? IdCategoria
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["IdCategoria"]))
                    _idCategoria = Convert.ToInt16(Request.QueryString["IdCategoria"]);
                return _idCategoria;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarProdutos();
            }
        }

        private void CarregarProdutos()
        {
            IList<Produto> lista = NProduto.RecuperarProdutos(null, IdCategoria);
            if (lista.Count == 0)
            {
                Mensagem.EscreverMensagem(Mensagem.TiposMensagem.Info, Master.DivMensagem, "Nenhum Produto encontrado.");
                return;
            }
            Session.Add("lista",lista);
            gvProdutos.DataSource = lista;
            gvProdutos.DataBind();

        }


        protected void GvProdutosOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            IList<Produto> lista = (IList<Produto>) Session["lista"];
            Produto p = lista[e.Row.DataItemIndex];
            //IList<Imagem> listaImagens = NImagem.RecuperarImagens(p.IdProduto);
            //p.Imagems.AddRange(listaImagens);
            Image i = (Image)e.Row.FindControl("ibImagem");

            string sFileName = p.Imagems.First().Nome;
            const string sFileDir = "../Imagem/produtos/";
            i.ImageUrl = sFileDir + sFileName;
            //aImagem.HRef = sFileDir + sFileName;
            gvImagens = (GridView) e.Row.FindControl("gvImagens");
            gvImagens.DataSource = p.Imagems.ToList();
            gvImagens.RowDataBound += new GridViewRowEventHandler(gvImagens_RowDataBound);
            gvImagens.DataBind();
        }

        void gvImagens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            IList<Imagem> lista = (IList<Imagem>) gvImagens.DataSource;
            Image i = (Image)e.Row.FindControl("ibImagem");

            string sFileName = i.AlternateText;
            const string sFileDir = "../Imagem/produtos/";
            i.ImageUrl = sFileDir + sFileName;
            //aImagem.HRef = sFileDir + sFileName;
        }
    }
}