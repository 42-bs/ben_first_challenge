namespace Api1
{
    using System.Text;
    using Api1.Models;
    using DotNetEnv;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Represents the entry point of the API application.
    /// </summary>
    public class Program
    {
#nullable disable
        /// <summary>
        /// The main entry point of the API application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            builder.Services.AddAuthorization();

            // Add configuration from appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();

            // Load the environment variables necessary to connect on Database.
            Env.Load();

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

            app.MapControllers();
            app.UseAuthentication();
            IConfiguration configuration = app.Configuration;
            IWebHostEnvironment environment = app.Environment;
            app.UseAuthorization();
            app.Run();
        }
    }
}
