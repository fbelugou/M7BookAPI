using BLL;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
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
   .AddJwtBearer(options =>
   {
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



//Documentation Swagger


builder.Services.AddSwaggerGen((options) =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, true);

    options.AddSecurityDefinition("jwt", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.OAuth2,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Flows = new OpenApiOAuthFlows()
        {
            Password = new OpenApiOAuthFlow()
            {
                TokenUrl = new Uri("/api/account/loginSwagger", UriKind.Relative)
            }
        },
    });


    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "jwt" }
            },
            new string[] {}
        }
    });

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

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});

app.MapControllers();

app.Run();
