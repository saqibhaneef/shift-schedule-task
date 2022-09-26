using Microsoft.EntityFrameworkCore;
using scheduling.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    try
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        //await context.Database.MigrateAsync();
        context.Database.EnsureCreated();
        await AppDbContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during migration");
    }

}

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
