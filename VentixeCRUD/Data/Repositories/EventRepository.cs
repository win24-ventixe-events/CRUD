using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VentixeCRUD.Data.DataContext;
using VentixeCRUD.Data.Entities;

namespace VentixeCRUD.Data.Repositories;

public class EventRepository(DbAppContext context)
{
    private readonly DbSet<EventEntity> _dbSet = context.Set<EventEntity>();

    public async Task AddAsync(EventEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
    }
    
    public virtual async Task<List<EventEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public virtual async Task<EventEntity?> GetAsync(Expression<Func<EventEntity, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public virtual async Task DeleteAsync(EventEntity entity)
    {
        
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        _dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(EventEntity entity)
    {
        if (entity == null)
            throw new KeyNotFoundException("Entity not found.");
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
    }
}