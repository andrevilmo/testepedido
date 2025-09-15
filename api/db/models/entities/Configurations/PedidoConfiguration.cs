using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Db.Models.Entities;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Numero).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.TotalBruto).HasColumnType("decimal(18,2)");
        builder.Property(p => p.Desconto).HasColumnType("decimal(18,2)");
        builder.Property(p => p.TotalLiquido).HasColumnType("decimal(18,2)");
        builder.Property(p => p.CriadoEm).IsRequired();
        builder.HasMany(p => p.ItemsPedido)
                .WithOne()
                .HasForeignKey(ip => ip.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.PromocoesPedido)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
    }
}