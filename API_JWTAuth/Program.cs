using BAL.Data_Manager;
using BAL.Interface;
using DAL.ApiDbContext;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, //server that created the token
            ValidateAudience = true, //receiver of the token is a valid recipient
            ValidateLifetime = true, //makes sure that token is valid
            ValidateIssuerSigningKey = true, // ensures signing key is valid and is trusted by the server
            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001", 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))  //here we are providing values for issuer,audience and secret key so that it generates signature for jwt
        };
    }); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure the HTTP request pipeline.

builder.Services.AddDbContext<DepartmentDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DepartmentDB")));
builder.Services.AddScoped<IDataRepository<Department>, DepartmentDataManager>(); 



var app = builder.Build();
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
