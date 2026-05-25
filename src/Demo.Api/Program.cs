using Demo.Api.Exceptions.Endpoints;
using Demo.Api.Startup;
using Demo.Business.Interfaces;
using Demo.Business.Services;
using Demo.Infrastructure.SqlStorage.Data;
using Demo.Infrastructure.SqlStorage.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddInMemoryDbContext();

builder.Services
  .AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGet("/", () => "Navigate to: https://localhost:5180/graphql");

app.MapGraphQL();

using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    ApplicationDbContext.CreateSeedData(db);
}

app.Run();