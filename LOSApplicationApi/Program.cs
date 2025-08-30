using LOSApplicationApi.Data;
using LOSApplicationApi.Mapper;
using LOSApplicationApi.Repository;
using LOSApplicationApi.Service;
using Master.Application.Repository;
using Master.Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddAutoMapper(typeof(MapperData));

builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IRoles, RolesServices>();
builder.Services.AddScoped<IUserRoles, UserRolesService>();
builder.Services.AddScoped<ICountry, CountryServices>();
builder.Services.AddScoped<IStates, StateServices>();
builder.Services.AddScoped<ICity, CityServices>();
builder.Services.AddScoped<IPincode, PincodeServices>();
builder.Services.AddScoped<IRejectionReason, RejectionReasonService>();
builder.Services.AddScoped<IEmploymentType, EmploymentTypeServices>();
builder.Services.AddScoped<IBank, BankServices>();
builder.Services.AddScoped<IOccupation, OccupationServices>();
builder.Services.AddScoped<IDocumentType, DocumentTypeService>();
builder.Services.AddScoped<IDepartment, DepartmentService>();
builder.Services.AddScoped<IBranch, BranchServices>();
builder.Services.AddScoped<IModule, ModuleService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
