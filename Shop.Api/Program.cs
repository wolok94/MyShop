using Microsoft.EntityFrameworkCore;
using Shop.Application.Mapper;
using Shop.Persistence.EF;

var builder = WebApplication.CreateBuilder(args);
builder.Services.InstallShopApplication();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddControllers();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
