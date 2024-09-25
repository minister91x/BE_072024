using BE_072024.NetCoreAPI;
using DataAccess.NetCore.DBContext;
using DataAccess.NetCore.IServices;
using DataAccess.NetCore.Services;
using DataAccess.NetCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<BE_072024dDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnStr_BE072024")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAccountServices, AccountServices>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomGenericRepository, RoomGenericRepository>();
builder.Services.AddScoped<IHotelGenericRepository, HotelGenericRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
