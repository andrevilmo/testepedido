using Api.Db.Models.Entities;
using Api.Service.Dto;
using service.Interfaces;

namespace service.Impl;
public class ProdutoService : IProdutoService
{

  IProdutoRepository _repository;
  public ProdutoService(IProdutoRepository repository)
  {
    _repository = repository;
  }
  public Produto Load(int id)
  {
    return _repository.Load(id);
  }

    public Produto GetAll()
    {
        return _repository.GetAll();
    }

    public void Save(Produto toSave)
    {
      _repository.Save(toSave);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    } 
}