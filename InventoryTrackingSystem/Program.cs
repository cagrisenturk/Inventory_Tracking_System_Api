using InventoryTrackingSystem.Business.Concrete;
using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<User>("OUsers");
    builder.EntitySet<Inventory>("OInventories");
    builder.EntitySet<InventoryUseTime>("OInventoryUseTimes").EntityType.HasKey(ent=>ent.InventoryId);
    return builder.GetEdmModel();
}
// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().
    AddOData(opt => opt.AddRouteComponents("v1", GetEdmModel()).Filter().Select().Expand().SetMaxTop(10000).Count().OrderBy());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InventoryTrackingSystemContext>(op => op.UseNpgsql(connectionstring));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddScoped<InventoryManager>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<InventoryUseTimeManager>();




var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
