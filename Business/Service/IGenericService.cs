using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IGenericService<T>
    {
        T Add(T entity);
        void Delete(int id,bool trackChanges);
        void Update(int id, T entity, bool trackChanges);
        IEnumerable<T> GetList(bool trackChanges);
        T GetById(int id,bool trackChanges);

    }
}
