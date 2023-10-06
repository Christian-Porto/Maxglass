using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Maxglass.Ecommerce.Aplicacao.Marcas.Servicos;
using Maxglass.Ecommerce.Aplicacao.Produtos.Profiles;
using Maxglass.Ecommerce.Dominio.Marcas.Servicos;
using Maxglass.Ecommerce.Infra.Marcas;
using Maxglass.Ecommerce.Infra.Marcas.Mapeamentos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NHibernate;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ProdutoProfile));

builder.Services.AddScoped<ISessionFactory>(factory =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x =>{x.FluentMappings.AddFromAssemblyOf<MarcasMap>();})
    .BuildSessionFactory();
});


builder.Services.AddScoped<ISession>(factory =>
{
    return factory.GetService<ISessionFactory>()!.OpenSession();
});


builder.Services.Scan(scan =>
    scan.FromAssemblyOf<MarcasAppServico>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime()

    .FromAssemblyOf<MarcasServico>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime()

    .FromAssemblyOf<MarcasRepositorio>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime());


var chave = Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
   
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(chave),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Maxglass",
        Description = "Ecommerce",
        TermsOfService = new Uri("https://www.maxglass.com.br")
                    
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Entre com o Token JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
        new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme
            }
        }, new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Maxglass");
                c.RoutePrefix = string.Empty;
            });
    app.UseCors(c=>{
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    });
}

app.UseCors((c)=>{
    c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
