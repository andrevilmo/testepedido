using Api.Db.Models.Entities;
using Api.Service.Dto;
using service.Interfaces;

using service.Interfaces;

namespace service.Impl;
public class PromocaoService : IPromocaoService
{
    private readonly IPromocaoRepository _repository;
    public PromocaoService(IPromocaoRepository repository)
    {
        _repository = repository;
    }
    public Promocao Load(int id)
    {
        return new Promocao
        {
            //Id = id,
        };
    }

    public List<Promocao> GetAll()
    {
        return _repository.GetAll();
    }

    public void Save(Promocao toSave)
    {
        _repository.Save(toSave);
        // Lógica para salvar o promocao (simulada)
        Console.WriteLine($"Promocao {toSave.Regra} salvo com sucesso!");
    }

    public void Delete(Promocao toDelete)
    {
        _repository.Delete(toDelete);
        // Lógica para deletar o promocao (simulada)
        Console.WriteLine($"Promocao com ID {toDelete.Id} deletado com sucesso!");
    }
 

}