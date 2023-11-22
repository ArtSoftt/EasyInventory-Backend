using EasyInventory_Backend.IAM.Application.Internal.CommandServices;
using EasyInventory_Backend.IAM.Application.Internal.OutboundServices;
using EasyInventory_Backend.IAM.Application.Internal.QueryServices;
using EasyInventory_Backend.IAM.Domain.Repositories;
using EasyInventory_Backend.IAM.Domain.Services;
using EasyInventory_Backend.IAM.Infrastructure.Hashing.Services;
using EasyInventory_Backend.IAM.Infrastructure.Persistence.Repositories;
using EasyInventory_Backend.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using EasyInventory_Backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using EasyInventory_Backend.IAM.Infrastructure.Tokens.JWT.Services;
using EasyInventory_Backend.Inventory.Application.Internal.CommandServices;
using EasyInventory_Backend.Inventory.Application.Internal.QueryServices;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Inventory.Infrastructure.Persistence.Repositories;
using EasyInventory_Backend.Profiles.Application.Internal.CommandServices;
using EasyInventory_Backend.Profiles.Application.Internal.QueryServices;
using EasyInventory_Backend.Profiles.Domain.Repositories;
using EasyInventory_Backend.Profiles.Domain.Services;
using EasyInventory_Backend.Profiles.Infrastructure.Persistence.Repositories;
using EasyInventory_Backend.Shared.Domain.Repositories;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ArtSoft.Management.API",
                Version = "v1",
                Description = "Easy Inventory Management Platform API",
                TermsOfService = new Uri("https://artsoft-management.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ArtSoft Studios",
                    Email = "contact@artsoft.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();

        // Add Bearer Token Authentication Security Definition
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        
        // Add Bearer Token Authentication Requirement
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
        
    });


//Add Database connection
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
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();

builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>();
builder.Services.AddScoped<ICustomerCommandService, CustomerCommandService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IProviderQueryService, ProviderQueryService>();
builder.Services.AddScoped<IProviderCommandService, ProviderCommandService>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleCommandService, SaleCommandService>();
builder.Services.AddScoped<ISaleQueryService, SaleQueryService>();

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

//IAM Bounded Context Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsercommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
//TokenSettings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("EncodingSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy =>
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


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

//Add CORS Middleware to ASP.NET Core Pipeline
app.UseCors("AllowAllPolicy");
// Add RequestAuthorization Middleware to ASP.NET Core Pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();