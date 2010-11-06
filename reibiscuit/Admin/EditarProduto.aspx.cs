using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using reibiscuit.Bussiness.Model;
using reibiscuit.Bussiness;
using System.IO;
using System.Web.UI.HtmlControls;

namespace reibiscuit.Admin
{
    public partial class EditarProduto : System.Web.UI.Page
    {
        private int IdProduto
        {
            get
            {
                if (Session["IdProduto"] == null)
                    return 0;
                return int.Parse(Session["IdProduto"].ToString());
            }
            set
            {
                Session.Add("IdProduto", value);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCategorias();
                CarregarProduto();
            }
        }

        private void CarregarProduto()
        {
            Produto produto = new Produto();
            pImagens.Visible = false;
            if (IdProduto>0)
            {
                produto = NProduto.RecuperarProduto((int)IdProduto);                
            }
            PreencherForm(produto);
        }

        private void CarregarImagens(Produto produto)
        {
            IList<Imagem> lista = NImagem.RecuperarImagens(IdProduto);
            gvImagens.DataSource = lista;
            gvImagens.DataBind();
        }

        private void PreencherForm(Produto produto)
        {
            tbDescricao.Text = produto.Descricao;
            tbQuantidade.Text = produto.QuantidadeEstoque.ToString();
            rblDisponibilidade.SelectedValue = produto.Disponibilidade ? "S" : "N";
            tbPreco.Text = produto.Preco.ToString("#0.00");
            ddlCategoria.SelectedIndex = -1;            
            if (produto.Categoria != null)
            {
                ListItem li = ddlCategoria.Items.FindByValue(produto.Categoria.IdCategoria.ToString());
                if (li != null)
                    li.Selected = true;
            }
            if (IdProduto > 0)
            {
                pImagens.Visible = true;
                CarregarImagens(produto);
            }
        }

        private void CarregarCategorias()
        {
            IList<Categoria> lista = NCategoria.RecuperarCategorias();
            ddlCategoria.DataTextField = "Descricao";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataSource = lista;
            ddlCategoria.DataBind();
        }

        protected void bSalvar_Click(object sender, EventArgs e)
        {
            #region Validacoes
            #endregion

            Produto produto = new Produto();
            if (IdProduto>0)
            {
                produto = NProduto.RecuperarProduto((int) IdProduto);
            }

            produto.Descricao = tbDescricao.Text;
            produto.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
            produto.Disponibilidade = rblDisponibilidade.SelectedValue.Equals("S");
            produto.Preco = decimal.Parse(tbPreco.Text);
            produto.QuantidadeEstoque = int.Parse(tbQuantidade.Text);

            NProduto.Salvar(produto);
            if (produto.IdProduto > 0)
                IdProduto = produto.IdProduto;
            
            pImagens.Visible = true;
        }

        protected void bEnviarImagem_Click(object sender, EventArgs e)
        {
            
            if ((fuImagem.PostedFile != null) && (fuImagem.PostedFile.ContentLength > 0))
            {

                //determine file name
                string sFileName = System.IO.Path.GetFileName(fuImagem.PostedFile.FileName);
                string sFileDir = Server.MapPath(@"~/Imagem/produtos/");
                try
                {

                    
                    Imagem i = new Imagem()
                    {
                        IdProduto = IdProduto,
                        Nome = sFileName
                    };
                    
                    
                    //if (fuImagem.PostedFile.ContentLength <= lMaxFileSize)
                    {
                        //Save File on disk
                        
                        fuImagem.PostedFile.SaveAs(sFileDir + sFileName);
                        //lblMessage.Visible = true;
                        //lblMessage.Text = "File: " + sFileDir + sFileName + " Uploaded Successfully";
                    }
                    //else //reject file
                    //{
                        //lblMessage.Visible = true;
                        //lblMessage.Text = "File Size if Over the Limit of " + lMaxFileSize;
                    //}

                    NImagem.Salvar(i);
                    Produto produto = NProduto.RecuperarProduto((int)IdProduto);
                    PreencherForm(produto);
                }
                catch (Exception)//in case of an error
                {
                    //lblMessage.Visible = true;
                    //blMessage.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(sFileDir + sFileName);
                }
            }

        }

        private void DeleteFile(string strFileName)
        {//Delete file from the server
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        protected void gvImagens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            Image i = (Image)e.Row.FindControl("ibImagem");
            HtmlAnchor aImagem = (HtmlAnchor)e.Row.FindControl("aImagem");
            string sFileName = i.AlternateText;
            string sFileDir = "../Imagem/produtos/";
            i.ImageUrl = sFileDir + sFileName;
            aImagem.HRef = sFileDir + sFileName;

            LinkButton lDelete = e.Row.FindControl("lDelete") as LinkButton;
            lDelete.OnClientClick = "return confirm('Tem certeza que deseja excluir o Produto?')";
        }

        protected void gvImagens_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LinkButton lDelete = (LinkButton)gvImagens.Rows[e.RowIndex].FindControl("lDelete");
            Imagem i = NImagem.RecuperarImagem(int.Parse(lDelete.CommandArgument));
            NImagem.Apagar(i);
            CarregarImagens(NProduto.RecuperarProduto(IdProduto));
        }

        
        
       
    }
}