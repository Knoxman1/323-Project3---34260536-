
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _superStoreContext;

        public GenericRepository(SuperStoreContext superStoreContext)
        {
            _superStoreContext = superStoreContext ?? throw new ArgumentNullException(nameof(superStoreContext));
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} must not be null");
            }

            try
            {
                _superStoreContext.Set<T>().Add(entity);
                _superStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving {nameof(entity)}: {ex.Message}");
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _superStoreContext.Set<T>().Remove(entity);
                _superStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing {nameof(entity)}: {ex.Message}");
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                _superStoreContext.Set<T>().AddRange(entities);
                _superStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding a range of entities: {ex.Message}");
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                _superStoreContext.Set<T>().RemoveRange(entities);
                _superStoreContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing a range of entities: {ex.Message}");
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _superStoreContext.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all entities: {ex.Message}");
            }
        }

        public T GetById(int id)
        {
            try
            {
                return _superStoreContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching {nameof(id)}: {ex.Message}");
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _superStoreContext.Set<T>().Where(expression);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding entities: {ex.Message}");
            }
        }
    }
}
