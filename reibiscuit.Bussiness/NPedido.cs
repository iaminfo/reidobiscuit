using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using reibiscuit.Bussiness.Model;

namespace reibiscuit.Bussiness
{
    public class NPedido
    {
        
        
        public Pedido RecuperarPedido(int IdPedido)
        {
            Pedido ped = NServico.Db.Pedidos.SingleOrDefault(p => p.IdPedido == IdPedido);
            return ped;
        }

        public IList<Pedido> RecuperarListaPedidosStatus(ListaStatus status)
        {
            var lista = NServico.Db.Pedidos.Where(p => p.status == (int)status);
            return lista.ToList<Pedido>();


        }
    }
}
