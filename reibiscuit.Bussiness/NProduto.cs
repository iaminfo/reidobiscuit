using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using reibiscuit.Bussiness.Model;

namespace reibiscuit.Bussiness
{
    public class NProduto
    {
        public static IList<Produto> RecuperarProdutos( string descricao = "", int? idCategoria = null)
        {
            var lista = NServico.Db.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
                lista = lista.Where(p=>p.Descricao.ToLower().Contains(descricao.ToLower()));
            

            if (idCategoria != null)
                lista = lista.Where(p => p.IdCategoria == idCategoria);

            return lista.OrderBy(p=>p.Categoria.Descricao).ToList(); 

        }

        public static Produto RecuperarProduto(int idProduto)
        {
            Produto produto = NServico.Db.Produtos.SingleOrDefault(p => p.IdProduto == idProduto);
            return produto;
        }


        public static void Salvar(Produto produto)
        {
            if (produto.IdProduto < 1)
            {
                NServico.Db.Produtos.InsertOnSubmit(produto);
            }
            NServico.Db.SubmitChanges();
        }

        public static void Apagar(Produto produto)
        {
            foreach (var imagem in NImagem.RecuperarImagens(produto.IdProduto))
            {
                NImagem.Apagar(imagem, false);
            }
            if (produto.IdProduto >0)
            {
                NServico.Db.Produtos.DeleteOnSubmit(produto);
            }
            NServico.Db.SubmitChanges();
        }
    }
}
