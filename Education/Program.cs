using Microsoft.EntityFrameworkCore;
using Education.Data;

namespace Education;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
       

        // CORS sozlamalari - BU YERDA TO‘G‘RI
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();

            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // CORS NI BU YERDA YOQISH KERAK
        app.UseCors(); // ⚠️ Bu app.MapControllers() dan oldin bo'lishi kerak

        app.MapControllers();

        app.Run();

    }
}
