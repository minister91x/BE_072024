using BE_072024.NetCoreAPI;
using DataAccess.NetCore.IServices;
using DataAccess.NetCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAccountServices, AccountServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");

//});

app.UseAuthorization();

app.UseMyCustomMiddleware();

app.MapControllers();


app.Run();
