using System.Reflection;
using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistence;
using WebApplication1.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Add services
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IWorkBookDbContext).Assembly));
});

void ConfigurationMapperAction(IMapperConfigurationExpression cfg)
{
    //create local mappers
}

//var mapperConfig = new MapperConfiguration(AutoMapperConfig.RegisterMappers(ConfigurationMapperAction));

builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:7272;http://localhost:5272";
    options.Audience = "WebApi";
    options.RequireHttpsMetadata = false;
});

var app = builder.Build();

//create http request pipeline

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endp =>
{
    endp.MapControllers();
});

app.Run();