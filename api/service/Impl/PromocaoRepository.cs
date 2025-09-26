using Api.Db.Models.Entities;
using Api.Service.Dto;
using db;
using service.Interfaces;

namespace service.Impl;
public class PromocaoRepository : IPromocaoRepository
{
    private readonly PedidoDBContext _context;
    public PromocaoRepository(PedidoDBContext context)
    {
        _context = context;
    }
    public Promocao Load(int id)
    {
        return (from p in _context.Promocoes
               where p.Id == id
               select p).FirstOrDefault()!;
    }

    public List<Promocao> GetAll()
    {
        return _context.Promocoes.ToList();
    }
    public void Save(Promocao toSave)
    {
        if (toSave.Id < 1)
            _context.Promocoes.Add(toSave);
        else
        {
            Promocao original = _context.Promocoes.Where(i => i.Id.Equals(toSave.Id)).First();
            original.Id = toSave.Id;
            original.Regra = toSave.Regra;
            _context.Promocoes.Attach(original);
            _context.Entry(original).State = Microsoft.EntityFrameworkCore.EntityState.Modified;    
        }
        _context.SaveChanges();
    }

    public void Delete(Promocao toDelete)
    {
        _context.Promocoes.Remove(toDelete);
        _context.SaveChanges();
    }
 

}