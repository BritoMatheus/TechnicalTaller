using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Repository.Repositories;
using Taller.Attributes;
using Taller.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.AddAuthentication(CustomHeaderAuthenticationOptions.DefaultScheme)
    .AddScheme<CustomHeaderAuthenticationOptions, CustomHeaderAuthenticationHandler>(
        CustomHeaderAuthenticationOptions.DefaultScheme,
        options =>
        {
            options.HeaderName = "Authorization";
        });
builder.Services.AddCors(o => o.AddPolicy("Cors", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseErrorHandler();

app.UseCors("Cors");

app.MapControllers();

app.Run();
