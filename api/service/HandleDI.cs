namespace service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using service.Interfaces;


public class HandleDI
{
    public static async Task ApplyDI(IServiceCollection services)
    {
                services.AddSingleton<IGravaPedidoService, GravaPedidoService>();
                //services.AddTransient<OddApplication>(); // Register the main application class
        // Resolve and run your main application logic
        //await host.Services.GetRequiredService<OddApplication>().Run();
    }
}

public class PedidoApplication
{
    private readonly IGravaPedidoService _ServiceGravaPedido;

    public PedidoApplication(IGravaPedidoService myService)
    {
        _ServiceGravaPedido = myService;
    }

    public Task PedidoSave(object o)
    {
        _ServiceGravaPedido.Save(o);
        return Task.CompletedTask;
    }
    public async Task<object> Load()
    {
        return _ServiceGravaPedido.Load();
    }
}