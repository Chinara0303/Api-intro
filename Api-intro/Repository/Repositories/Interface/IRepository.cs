using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int? id);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
