using Api.Db.Models.Entities;
using Api.Service.Dto;

namespace service.Interfaces;

public interface IPromocaoRepository
{
    void Save(Promocao toSave);
    Promocao Load(int id);
    List<Promocao> GetAll();
    void Delete(Promocao toSave);
}