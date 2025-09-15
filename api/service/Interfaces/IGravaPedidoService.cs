using Api.Service.Dto;

namespace service.Interfaces;
    public interface IGravaPedidoService
    {
        void Save(GravaPedido toSave);
        object Load();
    }