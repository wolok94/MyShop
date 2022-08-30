using Microsoft.EntityFrameworkCore;
using Shop.Application.Mapper;
using Shop.Persistence.EF;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.InstallShopApplication();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddControllers();

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
