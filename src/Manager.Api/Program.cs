using AutoMapper;
using Manager.Api.ViewModels;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Manager.Infra.Repositories;
using Manager.Service.DTO;
using Manager.Service.Interfaces;
using Manager.Service.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var autoMapperConfig = new MapperConfiguration(config =>
{
    config.CreateMap<User, UserDTO>().ReverseMap();
    config.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
    config.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());
builder.Services.AddDbContext<ManagerContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();