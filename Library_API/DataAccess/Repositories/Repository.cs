using Library_API.DataAccess;
using Library_API.Entities;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_API.Repositories
{
    public  class Repository<T> : IRepository<T> 
        where T:EntityBase ,new()
    {
        private LibraryDbContext _context; 
        public Repository(LibraryDbContext context)
        {
            _context = context;
        }
        public List<T> Get()
        {
           return _context.Set<T>().ToList();
        }
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }
        public int Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
            return _context.SaveChanges();
        }
    }
}