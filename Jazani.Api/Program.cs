using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jazani.Application.Cores.Contexts;
using Jazani.Infrastructure.Cores.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Application
builder.Services.AddApplicationService();

// Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfrastructureAutofactModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });



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