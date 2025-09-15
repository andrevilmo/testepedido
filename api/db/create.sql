create database teste;
use teste;
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Pedidos] (
    [Id] int NOT NULL IDENTITY,
    [Numero] nvarchar(50) NOT NULL,
    [ClienteId] int NOT NULL,
    [Status] int NOT NULL,
    [TotalBruto] decimal(18,2) NOT NULL,
    [Desconto] decimal(18,2) NOT NULL,
    [TotalLiquido] decimal(18,2) NOT NULL,
    [CriadoEm] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Sku] nvarchar(50) NOT NULL,
    [Nome] nvarchar(100) NOT NULL,
    [PrecoBase] decimal(18,2) NOT NULL,
    [Ativo] bit NOT NULL,
    [EstoqueAtual] int NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

CREATE TABLE [Promocoes] (
    [Id] int NOT NULL IDENTITY,
    [Regra] nvarchar(max) NOT NULL,
    [PedidoId] int NULL,
    CONSTRAINT [PK_Promocoes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Promocoes_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedidos] ([Id]) ON DELETE 
SET NULL
);

CREATE TABLE [ItemPedido] (
    [Id] int NOT NULL IDENTITY,
    [ProdutoId] int NOT NULL,
    [Qtd] int NOT NULL,
    [PrecoUnitario] decimal(18,2) NOT NULL,
    [DescontoItem] decimal(18,2) NOT NULL,
    [TotalItem] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ItemPedido] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ItemPedido_Pedidos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ItemPedido_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_ItemPedido_ProdutoId] ON [ItemPedido] ([ProdutoId]);

CREATE INDEX [IX_Promocoes_PedidoId] ON [Promocoes] ([PedidoId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250915221801_Initial', N'9.0.9');

COMMIT;
GO