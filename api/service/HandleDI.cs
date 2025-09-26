namespace service;

using Api.Service.Dto;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using service.Impl;
using service.Interfaces;


public class HandleDI
{
    public static async Task ApplyDI(IServiceCollection services)
    {
        _ = services.AddScoped<IGravaPedidoService, GravaPedidoService>();
        _ = services.AddScoped<IProdutoRepository, ProdutoRepository>();
        _ = services.AddScoped<IProdutoService, ProdutoService>();

    }
}

public class PedidoApplication
{
    private readonly IGravaPedidoService _ServiceGravaPedido;

    public PedidoApplication(IGravaPedidoService myService)
    {
        _ServiceGravaPedido = myService;
    }

    public Task PedidoSave(GravaPedido o)
    {
        _ServiceGravaPedido.Save(o);
        return Task.CompletedTask;
    }
    public async Task<object> Load()
    {
        return _ServiceGravaPedido.Load();
    }
}