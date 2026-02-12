using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(int id) ;
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);

        Task<T> GetByFilterAsync(Expression <Func<T,bool>>filter);
        
    }
}
