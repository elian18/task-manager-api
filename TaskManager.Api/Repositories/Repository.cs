using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManager.Api.Repositories.Interfaces;
using TaskManager.Api.Data;

namespace TaskManager.Api.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
     where TEntity : class, IEntity
    {
        public ApplicationDbContext context { get; set; }
        protected IServiceProvider serviceProvider;
        protected IHttpContextAccessor httpContextAccessor;
        public Repository(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            this.serviceProvider = serviceProvider;
            this.httpContextAccessor = httpContextAccessor;
            this.context = (ApplicationDbContext)this.serviceProvider.GetService(typeof(ApplicationDbContext));
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            if (entity is ICreatedAt e) e.CreatedAt = DateTime.Now;
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity is IUpdatedAt e) e.UpdatedAt = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }


        public async Task DeleteWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await context.Set<TEntity>()
                .Where(predicate)
                .ExecuteDeleteAsync(); // borra en SQL sin cargar entidades
        }



        public async Task<IDisposable> BeginTransactionAsync()
        {
            return await context.Database.BeginTransactionAsync();
        }

        // Método para confirmar una transacción
        public async Task CommitTransactionAsync()
        {
            await context.Database.CommitTransactionAsync();
        }

        // Método para revertir una transacción
        public async Task RollbackTransactionAsync()
        {
            await context.Database.RollbackTransactionAsync();
        }


    }
}