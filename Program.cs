using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; 
using StudySphere.API.Data;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Povezivanje s bazom podataka
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

// Dodavanje FluentValidation servisa
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Dodavanje AutoMapper servisa
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(); 
app.UseSwaggerUI(); 


// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 
app.Run();