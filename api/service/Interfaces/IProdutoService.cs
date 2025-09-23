using Api.Db.Models.Entities;
using Api.Service.Dto;

namespace service.Interfaces;

public interface IProdutoService
{
    void Save(Produto toSave);
    Produto Load(int id);
    List<Produto> GetAll();
    void Delete(Produto toSave);
}