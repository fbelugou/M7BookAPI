using BLL;
using FluentValidation.AspNetCore;
using M7BookAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
#if !DEBUG
    options.Filters.Add<ApiExceptionFilterAttribute>();
#endif
});
builder.Services.AddBLL();

//Maybe change in the future because it's not the best way to do it
//cref: https://docs.fluentvalidation.net/en/latest/aspnet.html#using-the-asp-net-validation-pipeline
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
