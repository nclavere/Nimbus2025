using Microsoft.EntityFrameworkCore;
using Nimbus2025model.Context;
using Nimbus2025model.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Nimbus2025Context>(opt =>
    opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Nimbus2025;ConnectRetryCount=0"));

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

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<Nimbus2025Context>();
    await ctx.Database.MigrateAsync();
    await SeedService.Seed(ctx);
}

app.Run();
