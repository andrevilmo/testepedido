using back.Controllers; 
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Server.Kestrel.Core; 
using System.Text;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
//using saveodd;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using db;
using SignalRChat.Hubs;
using Microsoft.Extensions.FileProviders;

namespace back;

public class Startup
{
    public static string? isdev;

    static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

    public static IConfigurationRoot Configuration = builder.Build();

    public void ConfigureServices(IServiceCollection services)
    {
        this.ConfigureDependencyInjection(services).Wait();

        services.AddCors(options =>
        {
            
            options.AddPolicy("AllowAll",
                builder => {
                    builder
                         .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed(hostName => true);
                    });
        });

        services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 100_000_000;
        });
        services.AddDbContext<PedidoDBContext>(options =>
            options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")??"Server=127.0.0.1;Database=teste;User Id=sa;Password=SqlServer2019!;")); //.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
        services.Configure<KestrelServerOptions>(options =>
        {
            options.Limits.MaxRequestBodySize = 100_000_000;
            options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(60);
        });

        services.Configure<HttpSysOptions>(options =>
        {
            options.MaxRequestBodySize = 100_000_000;
        });

        string tokenSecret = Environment.GetEnvironmentVariable("TOKEN_SECRET") ?? "";

        if(String.IsNullOrEmpty(tokenSecret)){

            throw new Exception("Variavel TOKEN_SECRET nao configurada");
        }

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });
        services
            .AddControllers()
            .AddJsonOptions(options => {

                options.JsonSerializerOptions
                    .Converters.Add(new JsonStringEnumConverter());
            }); 
        services.AddEndpointsApiExplorer(); 
        services.AddSwaggerGen(option => 
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste", Version = "v1" });

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"                
            });

            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        services.AddSignalR();
        services.AddRazorPages();
  
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseRequestLocalization("pt-BR");
        app.UseCors("AllowAll");
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();     
        app.UseSwagger();
        app.UseDefaultFiles();
        //app.UseHttpsRedirection(); // This line enables HTTPS redirection.
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(AppContext.BaseDirectory, "wwwroot")),
            RequestPath = "/StaticFiles"
        });
        app.UseSwaggerUI(o =>
        {
            o.DisplayRequestDuration();
            o.DocExpansion(DocExpansion.None);
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapHub<ChatHub>("/chatHub"); // Linha adicionada
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints
                .MapControllers()
                .RequireAuthorization();
            /*
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET app API");
            });*/
        });
    }

    public async Task ConfigureDependencyInjection(IServiceCollection services)
    {
        await HandleDI.ApplyDI(services);
    }
}


