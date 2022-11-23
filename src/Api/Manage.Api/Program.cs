using Manage.Core.Configs;
using Manage.IOC.IOC;
using MediatR;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var connectionStrings = new ConnectionStrings();
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Configuration.Bind("ConnectionStrings", connectionStrings);

builder.Services.AddControllers(o =>
{
    o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

var assembly = AppDomain.CurrentDomain.Load("Manage.Application");
builder.Services.AddMediatR(assembly);
builder.Services.AddDbInjector();
builder.Services.AddMediatorInjector();
builder.Services.AddDbContextInjector(connectionStrings);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
