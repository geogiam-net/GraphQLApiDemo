using Demo.Api.Exceptions;
using Demo.Api.Exceptions.Endpoints;
using Demo.Api.Startup;
using Demo.Business.Interfaces;
using Demo.Business.Services;
using Demo.Infrastructure.SqlStorage.Data;
using Demo.Infrastructure.SqlStorage.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddInMemoryDbContext();

builder.Services
  .AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();

var app = builder.Build();

// not needed for this demo, but in production you should use https and authorization
// app.UseHttpsRedirection();

// UseStatusCodePages enables middleware that provides default responses for HTTP status codes
// (like 404, 400, 500) when your API does not return a body
app.UseStatusCodePages();
app.UseExceptionHandler();

// not needed for this demo, but in production you should use https and authorization
// app.UseAuthorization(); 

app.MapGet("/", () => "Navigate to: https://localhost:5180/graphql");

app.MapGraphQL();

using (var scope = app.Services.CreateScope()) {
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    ApplicationDbContext.CreateSeedData(db);
}

app.Run();