using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Application.Mapping;
using UdemyJWTApp.Back.Core.Application.ValidationRules.CategoryRules;
using UdemyJWTApp.Back.Core.Application.ValidationRules.ProductRules;
using UdemyJWTApp.Back.Infrastructure.Tools;
using UdemyJWTApp.Back.Persistance.Context;
using UdemyJWTApp.Back.Persistance.Repositories;
using UdemyJWTApp.Back.Persistance.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UdemyJWTDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"))
);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());//Neden Assembly probu ge�ildi�ini  bilmeden kullan�yorum !!!
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<IValidator<ProductCreateDto>, CreateProductRule>();
builder.Services.AddScoped<IValidator<ProductUpdateDto>, UpdateProductRule>();
builder.Services.AddScoped<IValidator<CategoryCreateDto>, CreateCategoryRule>();
builder.Services.AddScoped<IValidator<CategoryUpdateDto>, UpdateCategoryRule>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; // https ile configure etme
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = JwtTokenSettings.Audience, //�reten
        ValidIssuer = JwtTokenSettings.Issuer, //kullanan
        ClockSkew = TimeSpan.Zero, // sunucu ile client aras�ndaki delay
        ValidateLifetime = true,//Tokenin s�resini do�rula 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key)),//minimum 16 karakter i�eren bir key veriyoruz
        ValidateIssuerSigningKey = true
    };//continue
}) ;
builder.Services.AddCors(opt => {
    opt.AddPolicy("JwtTokenPolicy", opt =>
    {
        opt.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

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
app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
