using System.Reflection;
using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using AutoMapper;
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
builder.Services.AddControllers();

var app = builder.Build();

//create http request pipeline

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseEndpoints(endp =>
{
    endp.MapControllers();
});

app.Run();