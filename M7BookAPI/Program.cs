using BLL;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
#if !DEBUG
    options.Filters.Add<ApiExceptionFilterAttribute>();
#endif
});
builder.Services.AddBLL();

//Service for JWT Authentication
builder.Services
   .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options => {
       options.TokenValidationParameters = new TokenValidationParameters()
       {
           ValidateIssuer = false,
           ValidateAudience = false,
           ValidAudience = builder.Configuration["JwtIssuer"],
           ValidIssuer = builder.Configuration["JwtIssuer"],
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"])),
           //Retourne la différence de temps maximale autorisée entre le client et les paramètres de l'horloge du serveur.
           ClockSkew = TimeSpan.Zero // remove delay of token when expire
       };
   });






//Maybe change in the future because it's not the best way to do it
//cref: https://docs.fluentvalidation.net/en/latest/aspnet.html#using-the-asp-net-validation-pipeline
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Application for JWT Authentication
app.UseAuthentication();

//Use authorization for RBAC (Role Based Access Control)
app.UseAuthorization();

app.MapControllers();

app.Run();
