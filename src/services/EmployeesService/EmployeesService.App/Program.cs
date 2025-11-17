using EmployeesService.App.Exceptions;
using EmployeesService.App.Extensions;
using EmployeesService.App.Infrastructure;
using Microsoft.EntityFrameworkCore;

// TODO: Handle validation exceptions

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

builder.Services.AddFluentValidation();

builder.Services.AddMediatr();

builder.Services.AddRabbitMq(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson();

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
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.Migrate();
}

app.MapControllers();

app.UseExceptionHandler();

app.Run();
