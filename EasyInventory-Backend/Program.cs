using EasyInventory_Backend.Shared.Domain.Repositories;
using EasyInventory_Backend.Shared.Persistence.Contexts;
using EasyInventory_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Datatabase connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
    });
//Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);
//Shared Bounded Context Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Inventory Bounded Context Injection Configuration



var app = builder.Build();

//Validate Database Objects are created
using (var scope = app.Services.CreateScope())
    using (var context = scope.ServiceProvider.GetService<AppDbContext>())
    {
        context?.Database.EnsureCreated();
    }
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