using Api.Db.Models.Entities;
using Api.Service.Dto;

namespace service.Interfaces;

public interface IPromocaoService
{
    void Save(Promocao toSave);
    Promocao Load(int id);
    Promocao GetAll();
    void Delete(int id);}