using API;
using API.Middlewares;
using Application;
using Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add the dependency injections
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddHttpClient("SqlServerClient")
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };
    });

var app = builder.Build();

//Middlewares
app.UseTenantMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
