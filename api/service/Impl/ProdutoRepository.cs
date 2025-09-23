using Api.Db.Models.Entities;
using Api.Service.Dto;
using db;
using service.Interfaces;

namespace service.Impl;
public class ProdutoRepository : service.Interfaces.IProdutoRepository
{
    private readonly PedidoDBContext _context;
    public ProdutoRepository(PedidoDBContext context)
    {
        _context = context;
    }
    public Produto Load(int id)
    {
        return (from p in _context.Produtos
               where p.Id == id
               select p).FirstOrDefault()!;
    }

    public List<Produto> GetAll()
    {
        return _context.Produtos.ToList();
    }
    public void Save(Produto toSave)
    {
        if (toSave.Id > 0)
            _context.Produtos.Add(toSave);
        else
        {
            Produto original = _context.Produtos.Where(i => i.Id.Equals(toSave.Id)).First();
            original.Ativo = toSave.Ativo;
            original.EstoqueAtual = toSave.EstoqueAtual;
            original.Nome = toSave.Nome;
            original.PrecoBase = toSave.PrecoBase;
            original.Sku = toSave.Sku;
        }
        _context.SaveChanges();
    }

    public void Delete(Produto toDelete)
    {
        _context.Produtos.Remove(toDelete);
        _context.SaveChanges();
    }
 

}