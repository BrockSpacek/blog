using System.Text;
using blog.Context;
using blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<BlogServices>();

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
    policy => {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});


var secretKey = builder.Configuration["JWT:key"];
var signingCredentials = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

// We are adding Authentication to your build to check the JWToken from our services

builder.Services.AddAuthentication(options => 
{
    // Sets the authentication behavior of our JWT Bearer
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // Sets the default behavior for when our authentication fails
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer( options =>
{
    // Configuring JWT Bearer Options(Checking the Params)
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Checks if the tokens issuer is valid
        ValidateAudience = true, // Checks if the Token's adience is valid
        ValidateLifetime = true, // Ensures that our Token has not expired
        ValidateIssuerSigningKey = true, // Checking the Tokens Signiture is valid

        ValidIssuer = "https://spacekbblog-dzhvdueagzdha7cx.westus-01.azurewebsites.net/",
        ValidAudience = "https://spacekbblog-dzhvdueagzdha7cx.westus-01.azurewebsites.net/",
        IssuerSigningKey = signingCredentials
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
