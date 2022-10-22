using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Application.Mapping;
using UdemyJWTApp.Back.Persistance.Context;
using UdemyJWTApp.Back.Persistance.Repositories;
using UdemyJWTApp.Back.Persistance.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UdemyJWTDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"))
);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());//Neden Assembly probu geçildiðini  bilmeden kullanýyorum !!!
builder.Services.AddScoped<IUow, Uow>();

var profiles = new Profile[]
{
    new ProductProfile(),
    new CategoryProfile()
};

//Mapper DI

var config = new MapperConfiguration(x => x.AddProfiles(profiles));

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
