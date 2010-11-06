using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using reibiscuit.Bussiness.Model;

namespace reibiscuit.Bussiness
{
    public class NCategoria
    {
        public static IList<Categoria> RecuperarCategorias(int? idCategoria = null)
        {
            var lista = idCategoria == null ? NServico.Db.Categorias.AsQueryable() : NServico.Db.Categorias.Where(c => c.IdCategoria.Equals(idCategoria));
            return lista.OrderBy(c => c.Descricao).ToList();
            
        }

    }
}
