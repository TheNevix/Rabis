using Microsoft.EntityFrameworkCore;
using Rabis.Api.Core;
using Rabis.Api.MappingConfigs;
using Rabis.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<UserService>();

builder.Services.AddDbContext<RabisDbContext>(options =>
        options.UseInMemoryDatabase("RabisDb"));

//Add TheNevix AutoMapper
builder.Services.AddSingleton(sp =>
{
    return MappingConfigs.ConfigureMappings();
});

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
