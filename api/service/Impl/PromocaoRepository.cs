using Api.Db.Models.Entities;
using Api.Service.Dto;
using service.Interfaces;

namespace service.Impl;
public class PromocaoRepository : IPromocaoRepository
{
    public Promocao Load(int id)
    {
        return new Promocao
        {
            Id = id, 
        };
    }

    public Promocao GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save(Promocao toSave)
    {
        // Lógica para salvar o Promocao (simulada)
        Console.WriteLine($"Promocao {toSave.Regra} salvo com sucesso!");
    }

    public void Delete(int id)
    {
        // Lógica para deletar o Promocao (simulada)
        Console.WriteLine($"Promocao com ID {id} deletado com sucesso!");
    } 
}