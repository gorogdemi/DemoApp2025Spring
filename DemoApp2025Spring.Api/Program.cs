using DemoApp2025Spring.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITestService, TestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

// TODO: Browser explanation
// TODO: DI: Singleton, Scoped, Transient
// TODO: Exercise: counter endpoint

// TODO: Cleanup (commit)
// TODO: Person: Id, Name, Email, BirthDate
// TODO: IPersonService + Implementation with List
// TODO: PersonController: CRUD endpoints (commit)
// TODO: Input validation: Required, MaxLength, Email, Range

// TODO: Add log messages
// TODO: Serilog: Serilog.AspNetCore 9.0.0 (commit)