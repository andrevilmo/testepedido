using Api.Db.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace db;

public class PedidoDBContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; } 
    public DbSet<Produto> Produtos { get; set; } 

    public DbSet<Promocao> Promocoes { get; set; } 

    public string? ConnectionString { get; }

    public PedidoDBContext()
    {
        
    }

    public PedidoDBContext(string connectionString)
    {
        ConnectionString = connectionString;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PedidoConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new PromocaoConfiguration());
        modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString??"Server=127.0.0.1;Database=teste;User Id=sa;Password=SqlServer2019!;TrustServerCertificate=yes");
}