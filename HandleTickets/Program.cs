using Application;
using Infrastructure;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace HandleTickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DatabaseContext>(
         dbContextOptionBuilder =>
         {
             var connectionString = builder.Configuration.GetConnectionString("Database");
             dbContextOptionBuilder.UseSqlServer(connectionString).LogTo(s => System.Diagnostics.Debug.WriteLine(s))
             .EnableDetailedErrors(true).EnableSensitiveDataLogging(true);
         });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Add services to the container.

            builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblies(typeof(AppMediator).Assembly));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", builder => { builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); });
            });
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DatabaseContext>();
                context.Database.Migrate();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
