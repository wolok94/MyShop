using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Mapper;
using Shop.Persistence.EF;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
builder.Services.InstallShopApplication();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddControllers();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();


app.MapControllers();
app.Run();
