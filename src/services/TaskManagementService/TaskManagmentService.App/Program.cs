using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Exceptions;
using TaskManagmentService.App.Extensions;
using TaskManagmentService.App.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

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

app.UseExceptionHandler();

app.Run();
