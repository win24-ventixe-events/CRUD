using Microsoft.EntityFrameworkCore;
using VentixeCRUD.Data.DataContext;
using VentixeCRUD.Data.Repositories;
using VentixeCRUD.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
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


app.UseCors("AllowReact");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
