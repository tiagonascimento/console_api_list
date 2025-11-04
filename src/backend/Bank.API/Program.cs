using Bank.Aplication;
using Bank.Infra.repository;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:80");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injecao de dependencia / estenção de classe
builder.Services.AddAplication();
builder.Services.AddInfra(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarefas API v1");
    c.RoutePrefix = "swagger";
});
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
