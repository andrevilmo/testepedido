using Api.Db.Models.Entities;
using Api.Service.Dto;
using service.Interfaces;

using service.Interfaces;

namespace service.Impl;
public class PromocaoService : IPromocaoService
{

  IPromocaoRepository _repository;
  public PromocaoService(IPromocaoRepository repository)
  {
    _repository = repository;
  }
  public Promocao Load(int id)
  {
    return _repository.Load(id);
  }

    public Promocao GetAll()
    {
        return _repository.GetAll();
    }

    public void Save(Promocao toSave)
    {
      _repository.Save(toSave);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    } 
}