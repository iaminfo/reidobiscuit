using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using reibiscuit.Bussiness;
using reibiscuit.Bussiness.Model;

namespace reibiscuit.Admin
{
    public partial class Idiomas : System.Web.UI.Page
    {
        private readonly NIdioma nIdioma = new NIdioma();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrid();
            }
            
        }

        private void CarregarGrid()
        {
            var lista = nIdioma.ReronarIdiomas();
            Session.Add("idiomas", lista);
            if (lista.Count == 0)
            {
                Mensagem.EscreverMensagem(Mensagem.TiposMensagem.erro, Master.DivMensagem, "Nao existem idiomas Cadastrados");
                return;
            }
            
            gvIdiomas.DataSource = lista;
            gvIdiomas.DataBind();
        }

        protected void bIncluir_Click(object sender, EventArgs e)
        {
            IList<Idioma> lista = nIdioma.ReronarIdiomas();
            if (lista == null || lista.Count == 0)
            {
                lista = new List<Idioma>();
            }
            lista.Add(new Idioma());
            gvIdiomas.DataSource = lista;
            Session.Add("idiomas", lista);
            gvIdiomas.EditIndex = lista.Count-1;
            gvIdiomas.DataBind();
            
            
        }

        protected void gvIdiomas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIdiomas.EditIndex = e.NewEditIndex;
            CarregarGrid();
        }

        protected void gvIdiomas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState != (DataControlRowState.Normal | DataControlRowState.Alternate)) return;
            LinkButton lbDelete = e.Row.FindControl("lbDelete") as LinkButton;
            lbDelete.OnClientClick = "return confirm('Tem certeza que deseja excluir o idioma?')";

        }

        protected void gvIdiomas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var lista = nIdioma.ReronarIdiomas();
            Idioma idioma = lista[e.RowIndex];
            nIdioma.Excluiridioma(idioma.IdIdioma);            
            CarregarGrid();
        }

        protected void gvIdiomas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvIdiomas.DataSource = new List<Idioma>();
            gvIdiomas.DataBind();
            CarregarGrid();
        }

        protected void gvIdiomas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            IList<Idioma> lista = Session["idiomas"] as IList<Idioma>;
            if (lista == null) return;

            var row = gvIdiomas.Rows[e.RowIndex];
            TextBox tbDescricao = row.FindControl("tbDescricao") as TextBox;
            Idioma idioma = lista[e.RowIndex];
            if (string.IsNullOrEmpty(tbDescricao.Text))
            {
                Mensagem.EscreverMensagem(Mensagem.TiposMensagem.erro, Master.DivMensagem, "Idioma é obrigatório.");
                return;
            }
            idioma.Descricao = tbDescricao.Text;

            if (idioma.IdIdioma == 0)
                nIdioma.InserirIdioma(idioma.Descricao);
            else
                nIdioma.AlterarIdioma(idioma);
            gvIdiomas.EditIndex = -1;
            CarregarGrid();
        }


    }
}