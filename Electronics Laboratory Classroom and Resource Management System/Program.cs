using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repository;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ElectronicsLaboratoryClassroomandResourceDBContext>(options =>
    options.UseSqlServer(conString));

// Registrar los servicios en el contenedor de inyección de dependencias
builder.Services.AddScoped<IUser_TypeService, User_TypeService>(); // Servicio para User_Type
builder.Services.AddScoped<IUser_Type_Repository, User_Type_Repository>(); // Repositorio para User_Type

builder.Services.AddScoped<IUserService, UserService>(); // Servicio para User
builder.Services.AddScoped<IUser_Repository, User_Repository>(); // Repositorio para User

// Add controllers
builder.Services.AddControllers();

// Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
