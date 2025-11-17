using AssignmentGroupManagemetService.App.Extensions;
using AssignmentGroupManagemetService.App.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(options =>
    options.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddRabbitMQ(builder.Configuration);

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
