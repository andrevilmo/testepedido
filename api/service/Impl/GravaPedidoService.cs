using db;
using Microsoft.EntityFrameworkCore; 
using service.Interfaces;

namespace service;
public class GravaPedidoService : IGravaPedidoService
{

    public object Load()
    {
      return string.Empty;
    }

    public void Save(object toSave)
    {
        throw new NotImplementedException();
    }
}