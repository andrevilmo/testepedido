using System.Collections.Generic;
using Api.Db.Models.Entities;

namespace Api.Service.Dto
{
    public class GravaPedido
    {
        public Pedido Pedido { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
        public List<Promocao> Promocoes { get; set; }
    }
}