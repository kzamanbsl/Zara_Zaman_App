using app.EntityModel;
using app.Infrastructure.Auth;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        private readonly IWorkContext _iWorkContext;
        protected readonly InventoryDbContext Db;
        public EntityRepository(IWorkContext iWorkContext, InventoryDbContext context)
        {
            this.Db = context;
            _iWorkContext = iWorkContext;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                entity = await GetAddAsyncProperties(entity);
                await Db.Set<T>().AddAsync(entity);
                await Db.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception ex)
            {
                entity = null;
                return entity;
            }
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default)
        {
            List<T> entityList = new List<T>();
            foreach (var entity in entities)
            {
                var obj = await GetAddAsyncProperties(entity);
                entityList.Add(obj);
            }

            try
            {

                await Db.Set<T>().AddRangeAsync(entityList);
                await Db.SaveChangesAsync(cancellationToken);

                return entityList;
            }
            catch (Exception ex)
            {
                entityList = null;
                return entityList;
            }
        }

        public IQueryable<T> AllIQueryableAsync(CancellationToken cancellationToken = default)
        {
            return Db.Set<T>().AsQueryable();
        }
        public async Task<T> FirstAsync(CancellationToken cancellationToken = default)
        {
            return await Db.Set<T>().FirstAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return await Db.Set<T>().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Db.Set<T>().ToListAsync(cancellationToken);
        }

        public Task<IReadOnlyList<T>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<T>> GetAllPagedAsync(int recSkip, int recTake, CancellationToken cancellationToken = default)
        {
            return await Db.Set<T>().Where(s => s.IsActive == true).Skip(recSkip).Take(recTake).ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await Db.Set<T>().FindAsync(id);
        }

        public Task<IReadOnlyList<T>> GetDeletedPagedAsync(int recSkip, int recTake, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PermanentDeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            Db.Set<T>().Remove(entity);
            await Db.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public async Task<bool> PermanentDeleteByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            Db.Set<T>().Remove(Db.Set<T>().Find(id));
            await Db.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity = await GetUpdateAsyncProperties(entity);
            Db.Entry(entity).State = EntityState.Modified;
            await Db.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await Db.Set<T>().Where(s => s.IsActive == true).CountAsync();
        }

        public async Task<int> CountAsync()
        {
            return await Db.Set<T>().Where(s => s.IsActive == true).CountAsync();
        }

        private async Task<T> GetUpdateAsyncProperties(T entity)
        {
            var bnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
            DateTime baTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, bnTimeZone);
            entity.UpdatedOn = baTime;
            entity.UpdatedBy = _iWorkContext.GetCurrentUserAsync().Result.FullName;
            return entity;
        }

        private async Task<T> GetAddAsyncProperties(T entity)
        {
            var bnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
            DateTime baTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, bnTimeZone);
            entity.CreatedOn = baTime;
            entity.CreatedBy = _iWorkContext.GetCurrentUserAsync().Result.FullName;
            entity.IsActive = true;
            return entity;
        }

    }
}
