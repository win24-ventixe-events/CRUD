using Microsoft.EntityFrameworkCore;
using VentixeCRUD.Data.Entities;

namespace VentixeCRUD.Data.DataContext;

public class DbAppContext(DbContextOptions<DbAppContext> options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
    
}