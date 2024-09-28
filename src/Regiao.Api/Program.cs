using Prometheus;
using Regiao.AntiCorruption.BrasilApiService;
using Regiao.Api.Endpoints;
using Regiao.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.AddDomainService();
builder.Services.AddBrasilApiClientExtensions(builder.Configuration);
builder.AddFluentValidationEndpointFilter();
builder.Services.AddHealthChecks().ForwardToPrometheus();
builder.Services.ConfigureOpenTelemetry();
builder.Services.ConfigureRabbit();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpMetrics();
app.UseHttpsRedirection();
app.RegisterContatosEndpoints();
app.MapMetrics();

app.Run();