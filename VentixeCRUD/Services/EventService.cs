using System.Diagnostics;
using VentixeCRUD.Data.Entities;
using VentixeCRUD.Data.Repositories;
namespace VentixeCRUD.Services;

public class EventService(EventRepository repository)
{
    public async Task CreateEventAsync(EventEntity eventEntity)
    {
        try
        {
            await repository.AddAsync(eventEntity);
            
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
           
            throw;
        }
    }

    public async Task<List<EventEntity>> GetAllAsync()
    {
        try
        {
            return await repository.GetAllAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
        
    }

    public async Task<EventEntity> GetByIdAsync(int id)
    {
        try
        {
            var eventEntity = await repository.GetAsync(x => x.Id == id);
            if (eventEntity == null)
            {
                throw new Exception("Project not found");
            }
            return eventEntity;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }
    
  

    public async Task DeleteAsync(int id)
    {
      
        
        try
        {
            var entityToDelete = await GetByIdAsync(id);
            if (entityToDelete == null)
            {
                throw new Exception("Project not found");
            }

            
            await repository.DeleteAsync(entityToDelete);
            
           
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
          
            throw;
        }
        
    }

    public async Task UpdateAsync(EventEntity eventEntity)
    {
       
        try
        {
            await repository.UpdateAsync(eventEntity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            throw;
        }
        
    }
}