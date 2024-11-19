using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Quiz_2;
using Quiz_2.Repository_Pattern;
using Quiz_2.Repository_Pattern.CreditCardRepository;
using Quiz_2.Repository_Pattern.GenreRepository;
using Quiz_2.Repository_Pattern.IdentityCardRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configurationString = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configurationString));
builder.Services.AddScoped<IRepositoryBook, RepositoryBook>();
builder.Services.AddScoped<IRepositoryAuthor, RepositoryAuthor>();
builder.Services.AddScoped<IRepositoryGenre , RepositoryGenre>();
builder.Services.AddScoped<IRepositoryIdentityCard , RepositoryIdentityCard>();
builder.Services.AddScoped<IRepositoryCreditCard , RepositoryCreditCard>();
// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTs", Version = "v1" });

    // Add security definition for JWT Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token in format **'Bearer {your JWT token}'**",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
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
