using Application;
using Application.Common.Mappings;
using AutoMapper;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
//Add services

void ConfigurationMapperAction(IMapperConfigurationExpression cfg)
{
    //create local mappers
}

var mapperConfig = new MapperConfiguration(AutoMapperConfig.RegisterMappers(ConfigurationMapperAction));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(c => mapper);

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
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseEndpoints(endp =>
{
    endp.MapControllers();
});

app.Run();