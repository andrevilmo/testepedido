namespace service.Interfaces;
    public interface IGravaPedidoService
    {
        void Save(Object toSave);
        object Load();
    }