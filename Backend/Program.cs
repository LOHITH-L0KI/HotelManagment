
using Backend.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Listen to port 6666
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(6666);
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<PersistanceContext>(optionsBuilder =>
{
    var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

    optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], 
        /* Sets 'Backend' project to contain migrations */b => b.MigrationsAssembly("Backend"));
});

//Add authentication schema JSON Web Token (JWS)
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthTokenGenetator.secretKey.ToString())),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };

    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
