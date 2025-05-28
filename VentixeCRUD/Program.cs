using Microsoft.EntityFrameworkCore;
using VentixeCRUD.Data.DataContext;
using VentixeCRUD.Data.Repositories;
using VentixeCRUD.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Get connection string from appsettings.json
builder.Services.AddDbContext<DbAppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<EventService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
