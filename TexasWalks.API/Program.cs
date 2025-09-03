
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TexasWalks.API.Data;
using TexasWalks.API.Mappings;
using TexasWalks.API.Repository;

namespace TexasWalks.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DB context injection using dependency Injection
            builder.Services.AddDbContext<TexasWalksDbContext>(Options =>
            Options.UseSqlServer(builder.Configuration.GetConnectionString("TexasWalksConnectionString")));

            //In memory region repository implementation
            //builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

            builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
            builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();


            //Auto mapper configuration
            // Replace this line:
            // builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            // With this line:
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());
            //builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
        }
    }
}
