using Api.Db.Models.Entities;
using Api.Service.Dto;
using service.Interfaces;

namespace service.Impl;
public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;
    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }
    public Produto Load(int id)
    {
        return _repository.Load(id);
    }

    public List<Produto> GetAll()
    {
        return _repository.GetAll();
    }

    public void Save(Produto toSave)
    {
        _repository.Save(toSave);
        // Lógica para salvar o produto (simulada)
        Console.WriteLine($"Produto {toSave.Nome} salvo com sucesso!");
    }

    public void Delete(Produto toDelete)
    {
        _repository.Delete(toDelete);
        // Lógica para deletar o produto (simulada)
        Console.WriteLine($"Produto com ID {toDelete.Id} deletado com sucesso!");
    }
 

}