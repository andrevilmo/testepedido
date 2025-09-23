using Api.Db.Models.Entities;
using Api.Service.Dto;

namespace service.Interfaces;

public interface IProdutoRepository
{
    void Save(Produto toSave);
    Produto Load(int id);
    Produto GetAll();
    void Delete(int id);}