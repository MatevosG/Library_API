using Library_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.Repositories
{
    public interface IRepository<T>
        where T : EntityBase,new()
    {
        List<T> Get();
        T Get(int id);
        T Insert(T obj);
        T Update(T obj);
        int Delete(T obj);
    }
}
