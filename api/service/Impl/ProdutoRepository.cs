using Api.Db.Models.Entities;
using Api.Service.Dto;
using service.Interfaces;

namespace service.Impl;
public class ProdutoRepository : IProdutoRepository
{
    public Produto Load(int id)
    {
        return new Produto
        {
            Id = id, 
        };
    }

    public Produto GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save(Produto toSave)
    {
        // Lógica para salvar o produto (simulada)
        Console.WriteLine($"Produto {toSave.Nome} salvo com sucesso!");
    }

    public void Delete(int id)
    {
        // Lógica para deletar o produto (simulada)
        Console.WriteLine($"Produto com ID {id} deletado com sucesso!");
    } 
}