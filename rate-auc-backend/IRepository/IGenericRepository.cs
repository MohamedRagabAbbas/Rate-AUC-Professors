using RateAucProfessors.DTO.Response;
using System.Linq.Expressions;

namespace RateAucProfessors.IRepository
{
    public interface IGenericRepository<T> where T : class
    {

        // get methods
        Task<ResponseMessage<IEnumerable<T>>> GetAllAsync();
        Task<ResponseMessage<T>> GetByIdAsync(int id);
        Task<ResponseMessage<T>> GetByIdAsync(string id);
        Task<ResponseMessage<IEnumerable<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<ResponseMessage<T>> GetFirstAsync(Expression<Func<T, bool>> predicate);
        Task<ResponseMessage<T2>> GetAttributeAsync<T2>(Expression<Func<T, bool>> predicate1, Expression<Func<T, T2>> predicate2);
        Task<ResponseMessage<T>> GetFirstAsyncWithInclude(Expression<Func<T, bool>> predicate, string include);
        Task<ResponseMessage<IEnumerable<T>>> GetWhereAsyncWithInclude(Expression<Func<T, bool>> predicate, string include);
        // add methods
        Task<ResponseMessage<T>> Add(T model);
        Task AddRange(List<T> models);

        Task<ResponseMessage<IEnumerable<T>>> DeleteAllAsync();
        // update methods
        ResponseMessage<T> Update(T model);
        void UpdateRanage(List<T> models);

        // delete method
        Task<ResponseMessage<T>> Delete(int id);
        Task<ResponseMessage<IEnumerable<T>>> DeleteRange(List<int> ids);



    }
}
