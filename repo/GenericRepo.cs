
using Microsoft.EntityFrameworkCore;

public class GenericRepo<TEntity>(ApplicationDbContext Context) : IGeneric<TEntity> where TEntity : class


{
    public async Task<int> CreateAsync(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        return await Context.SaveChangesAsync();

    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            throw new ItemNotFoundException($"item with  {id} is not found");
        }
        Context.Set<TEntity>().Remove(entity);
        return await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await Context.Set<TEntity>().AsNoTracking().ToListAsync();
        // AsNoTracking() تستخدم للتحديث البيانات في قاعدة البيانات بدون تتبع الالمان للتغييرات المصدرية
        return entities;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            throw new ItemNotFoundException($"item with  {id} is not found");
        }
        return entity;
    }

    public async Task<int> UpdateAsync(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        return await Context.SaveChangesAsync();
    }
}