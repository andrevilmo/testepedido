using System;

namespace Api.Db.Models.Entities
{
    public enum PedidoStatus
    {
        Rascunho,
        Confirmado,
        Cancelado,
        Faturado
    }

    public class Pedido
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public PedidoStatus Status { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal Desconto { get; set; }
        public decimal TotalLiquido { get; set; }
        public DateTime CriadoEm { get; set; }
        public ICollection<ItemPedido>? ItemsPedido { get; set; }
        public ICollection<Promocao>? PromocoesPedido { get; set; }
    }
}