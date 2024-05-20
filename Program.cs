// Program.cs
using gofer.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Comment>();
modelBuilder.EntityType<Order>();
modelBuilder.EntitySet<Customer>("Customers");
modelBuilder.EntitySet<Feature>("Features");
modelBuilder.EntitySet<Test>("Test");

builder.Services.AddControllers().AddOData(opt => opt.Count().Filter().OrderBy().Expand().SetMaxTop(null)
              .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseRouting();

app.UseODataRouteDebug();
app.UseODataQueryRequest();
app.UseODataBatching();

Console.WriteLine("odata after userouting");

app.UseEndpoints( endpoints => endpoints.MapControllers() );

app.Run();

// using the default model from the modelbuilder
static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Customer>("Customers");
    builder.EntitySet<Feature>("Features");
    return builder.GetEdmModel();
}