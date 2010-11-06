using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using reibiscuit.Bussiness.Model;

namespace reibiscuit.Bussiness
{
    public class NImagem
    {
        public static void Salvar(Imagem imagem)
        {            
            if (imagem.IdImagem < 1 )
            {
                NServico.Db.Imagems.InsertOnSubmit(imagem);
            }
            NServico.Db.SubmitChanges();
        }

        public static IList<Imagem> RecuperarImagens(int idProduto)
        {
            var lista = NServico.Db.Imagems.Where(i => i.IdProduto == idProduto);
                        
            return lista.OrderBy(i => i.Nome).ToList(); 
        }

        public static void Apagar(Imagem imagem, bool submit = true)
        {
            if (imagem.IdImagem > 0)
            {
                NServico.Db.Imagems.DeleteOnSubmit(imagem);
            }
            if (submit) NServico.Db.SubmitChanges();
        }

        public static Imagem RecuperarImagem(int idImagem)
        {
            Imagem img = NServico.Db.Imagems.SingleOrDefault(i => i.IdImagem == idImagem);
            return img;
        }
    }
}
