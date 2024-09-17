using Microsoft.EntityFrameworkCore;
using RestauranteService.Data;
using RestauranteService.ItemServiceHttpClient;
using RestauranteService.RabbitMqClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Construcao da conexao com o banco de dados
var conncetionString = builder.Configuration.GetConnectionString("RestauranteConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(
    conncetionString, ServerVersion.AutoDetect(conncetionString)));

builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();

//Adicao do AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add RabbitMq
builder.Services.AddSingleton<IRabbitMqClient, RabbitMqClient>();

//Adiciona client http
builder.Services.AddHttpClient<IItemServiceHttpClient, ItemServiceHttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
