using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.API.Services;
using WebAPI.Domain;
using WebAPI.Domain.Map;
using WebAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityCore<AppUser>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<MyDatabase>();    //* package: Microsoft.AspNetCore.Identity.EntityFrameworkCore
builder.Services.AddAuthentication();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperProfile));  //* package: AutoMapper.Extensions.Microsoft.DependencyInjection
builder.Services.AddDbContext<MyDatabase>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<TokenServices>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
var services = app.Services.CreateScope().ServiceProvider;
var db = services.GetRequiredService<MyDatabase>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
await UserSeed.Seed(db, userManager, roleManager);

app.Run();
