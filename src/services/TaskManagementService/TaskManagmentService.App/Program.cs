using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Extensions;
using TaskManagmentService.App.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ServiceContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddFluentValidation();

        builder.Services.AddMediatr();

        builder.Services.AddRabbitMq(builder.Configuration);

        builder.Services
            .AddControllers()
            .AddNewtonsoftJson();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ServiceContext>();
            context.Database.Migrate();
        }

        app.MapControllers();

        app.Run();
    }
}