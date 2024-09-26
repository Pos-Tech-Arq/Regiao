using Regiao.AntiCorruption.BrasilApiService;
using Regiao.Api.Endpoints;
using Regiao.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddDomainService();
builder.Services.ConfigureRepositories();
builder.Services.AddBrasilApiClientExtensions(builder.Configuration);
builder.AddFluentValidationEndpointFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.RegisterContatosEndpoints();

app.Run();