using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TugasBesar.Core.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {

        public Task AddAsync(T item);


        public Task<IReadOnlyList<T>> GetAllAsync();
        public IQueryable<T> Query();
        

        public Task<T> GetByIdAsync(int id);

        public Task DeleteAsync(int id);



        public Task UpdateAsync(T item);
     
    }
}
