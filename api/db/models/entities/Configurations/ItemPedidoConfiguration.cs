using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Db.Models.Entities;

public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(i => i.ProdutoId).IsRequired();
        builder.Property(i => i.Qtd).IsRequired();
        builder.Property(i => i.PrecoUnitario).HasColumnType("decimal(18,2)");
        builder.Property(i => i.DescontoItem).HasColumnType("decimal(18,2)");
        builder.Property(i => i.TotalItem).HasColumnType("decimal(18,2)");
        builder.HasOne(ip => ip.ProdutoItem)
                .WithMany()
                .HasForeignKey(ip => ip.ProdutoId);
    }
}