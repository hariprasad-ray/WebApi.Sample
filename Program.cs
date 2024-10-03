using Microsoft.EntityFrameworkCore;
using WebApi.Sample.Models;

namespace WebApi.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<UserManagementContext>
                (
                  options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
                  );

            builder.Services.AddCors(policyBuilder =>
                        policyBuilder.AddDefaultPolicy(policy =>
                        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
