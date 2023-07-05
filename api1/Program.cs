namespace Api1
{
    using Api1.Models;
    using DotNetEnv;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the entry point of the API application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point of the API application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load the environment variables necessary to connect on Database.
            Env.Load();

            // Add services to the container.
            builder.Services.AddControllers();

            // Stablish connection with the database context.
            builder.Services.AddDbContext<EnergyDataDbContext>(opt => opt.UseSqlServer(@"Server=" +
                    Env.GetString("DB_SERVER") +
                    ";Database=Ben; User Id=" +
                    Env.GetString("DB_USER") +
                    "; Password=" +
                    Env.GetString("DB_PASS") +
                    ";TrustServerCertificate=true"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // app.UseHttpsRedirection();

            // app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
