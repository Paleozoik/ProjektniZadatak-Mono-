using Microsoft.EntityFrameworkCore;
using Service.Context;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public abstract class DataManipulationsBase<T> : IDataManipulationsBase<T>, IDataManipulationsAsync<T> where T : class
    {
        private readonly VehicleDbContext dbContext;
        public DataManipulationsBase(VehicleDbContext DbContext)
        {
            this.dbContext = DbContext;
        }
        public void Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }
        public IQueryable<T> FindAll()
        {
            return dbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public async Task CreateAsync(T entity) => await dbContext.AddAsync(entity);
        public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}
