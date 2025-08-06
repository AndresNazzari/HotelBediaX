
using System.Reflection;
using BediaX.API.Extensions;
using BediaX.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. MVC
builder.Services.AddControllers()
    ;

// 2. Infra (DbContext, repos, etc.)
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApi();

// 3. Swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BediaX API",
        Version = "v1"
    });
    
    var xmlPath = Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
        "BediaX.API.xml");
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

    c.EnableAnnotations();
});

var app = builder.Build();

// Swagger UI limitado a Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();