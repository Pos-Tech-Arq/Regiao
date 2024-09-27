using Regiao.AntiCorruption.BrasilApiService;
using Regiao.Api.Endpoints;
using Regiao.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.AddDomainService();
builder.Services.AddBrasilApiClientExtensions(builder.Configuration);
//builder.Services.AddValidatorsFromAssemblyContaining<CriarContatoRequestValidator>();
builder.AddFluentValidationEndpointFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.RegisterContatosEndpoints();

app.Run();