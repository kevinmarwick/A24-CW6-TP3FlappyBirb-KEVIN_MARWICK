using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Flappy_Birb.Data;
using Flappy_Birb.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FlappyBirbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlappyBirbContext") ?? throw new InvalidOperationException("Connection string 'FlappyBirbContext' not found."));
    options.UseLazyLoadingProxies();
});
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<FlappyBirbContext>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
