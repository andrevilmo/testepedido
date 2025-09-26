using Api.Db.Models.Entities;
using Api.Service.Dto;

namespace service.Interfaces;

public interface IPromocaoService
{
    void Save(Promocao toSave);
    Promocao Load(int id);
    List<Promocao> GetAll();
    void Delete(Promocao toSave);
}