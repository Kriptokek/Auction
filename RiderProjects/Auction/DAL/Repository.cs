using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DALContext db;
        private DbSet<T> _dbSet;

        public Repository(DALContext db)
        {
            this.db = db;
            _dbSet = db.Set<T>();
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}