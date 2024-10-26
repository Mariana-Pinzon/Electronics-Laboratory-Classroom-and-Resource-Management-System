using Electronics_Laboratory_Classroom_and_Resource_Management_System.Context;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Repositories;
using Electronics_Laboratory_Classroom_and_Resource_Management_System.Services;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var conString = builder.Configuration.GetConnectionString("Connection");
        builder.Services.AddDbContext<ElectronicsLaboratoryClassroomandResourceDBContext>(options => options.UseSqlServer(conString));

        #region Repositories
        builder.Services.AddScoped<IEquipment_Repository, Equipment_Repository>();
        builder.Services.AddScoped<IInventory_Repository, Inventory_Repository>();
        builder.Services.AddScoped<ILaboratory_Repository, Laboratory_Repository>();
        builder.Services.AddScoped<IPermission_Repository, Permission_Repository>();
        builder.Services.AddScoped<IReservation_Equipment_Repository, Reservation_Equipment_Repository>();
        builder.Services.AddScoped<IReservation_Repository, Reservation_Repository>();
        builder.Services.AddScoped<IStatus_Equipment_Repository, Status_Equipment_Repository>();
        builder.Services.AddScoped<IStatus_Reservation_Repository, Status_Reservation_Repository>();
        builder.Services.AddScoped<IUser_Permission_Repository, User_Permission_Repository>();
        builder.Services.AddScoped<IUser_Repository, User_Repository>();
        builder.Services.AddScoped<IUser_Type_Repository, User_Type_Repository>();
        builder.Services.AddScoped<IMatch_Repository, Match_Repository>();
        builder.Services.AddScoped<ILevel_Repository, Level_Repository>();
        builder.Services.AddScoped<IMatchLevel_Repository, MatchLevel_Repository>();
        #endregion

        #region Services
        builder.Services.AddScoped<IEquipmentService, EquipmentService>();
        builder.Services.AddScoped<IInventoryService, InventoryService>();
        builder.Services.AddScoped<ILaboratoryService, LaboratoryService>();
        builder.Services.AddScoped<IPermissionService, PermissionService>();
        builder.Services.AddScoped<IReservation_EquipmentService, Reservation_EquipmentService>();
        builder.Services.AddScoped<IReservationService, ReservationService>();
        builder.Services.AddScoped<IStatus_EquipmentService, Status_EquipmentService>();
        builder.Services.AddScoped<IStatus_ReservationService, Status_ReservationService>();
        builder.Services.AddScoped<IUser_PermissionService, User_PermissionService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUser_TypeService, User_TypeService>();
        builder.Services.AddScoped<IMatchService, MatchService>();
        builder.Services.AddScoped<ILevelService, LevelService>();
        builder.Services.AddScoped<IMatchLevelService, MatchLevelService>();
        #endregion

        // Add controllers
        builder.Services.AddControllers();

        // Swagger para la documentación de la API
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Cors Policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
        var app = builder.Build();

        // Use Cors
        app.UseCors("AllowAll");

        // Configure the HTTP request pipeline.


        app.UseSwagger();
            app.UseSwaggerUI();
        

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}


