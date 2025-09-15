namespace Api.Db.Models.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Qtd { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal DescontoItem { get; set; }
        public decimal TotalItem { get; set; }
        public Produto? ProdutoItem { get; set; }
    }
}