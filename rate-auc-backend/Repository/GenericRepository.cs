﻿using Microsoft.EntityFrameworkCore;
using RateAucProfessors.DB;
using RateAucProfessors.DTO.Response;
using RateAucProfessors.IRepository;
using System.Linq.Expressions;

namespace RateAucProfessors.Repository
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<ResponseMessage<IEnumerable<T>>> GetAllAsync()
        {
            var all = await _dbSet.ToListAsync();
            if (all is not null)
                return new ResponseMessage<IEnumerable<T>>()
                {
                    Message = "The information is successfully found...",
                    Status = true,
                    Data = all
                };
            return new ResponseMessage<IEnumerable<T>>()
            {
                Message = "The information is not found..."
            };
        }

        public async Task<ResponseMessage<T>> GetByIdAsync(int id)
        {
            var obj = await _dbSet.FindAsync(id);
            if (obj is not null)
                return new ResponseMessage<T>()
                {
                    Message = "The object is successfully found...",
                    Status = true,
                    Data = obj
                };
            return new ResponseMessage<T>() { Message = "The object is not found..." };

        }
        public async Task<ResponseMessage<T>> GetByIdAsync(string id)
        {
            var obj = await _dbSet.FindAsync(id);
            if (obj is not null)
                return new ResponseMessage<T>()
                {
                    Message = "The object is successfully found...",
                    Status = true,
                    Data = obj
                };
            return new ResponseMessage<T>() { Message = "The object is not found..." };

        }

        public async Task<ResponseMessage<T>> GetFirstAsync(Expression<Func<T, bool>> predicate)
        {
            var obj = await _dbSet.Where<T>(predicate).FirstAsync();
            if (obj is not null)
                return new ResponseMessage<T>()
                {
                    Message = "The object is successfully found...",
                    Status = true,
                    Data = obj
                };
            return new ResponseMessage<T>() { Message = "The object is not found..." };
        }
        //GetFirstAsyncWithInclude
        public async Task<ResponseMessage<T>> GetFirstAsyncWithInclude(Expression<Func<T, bool>> predicate, string include)
        {
            var obj = await _dbSet.Include(include).Where<T>(predicate).FirstAsync();
            if (obj is not null)
                return new ResponseMessage<T>()
                {
                    Message = "The object is successfully found...",
                    Status = true,
                    Data = obj
                };
            return new ResponseMessage<T>() { Message = "The object is not found..." };
        }

        public async Task<ResponseMessage<IEnumerable<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            var objs = await _dbSet.Where<T>(predicate).ToListAsync();
            if (objs is not null)
                return new ResponseMessage<IEnumerable<T>>()
                {
                    Message = "The object is successfully found...",
                    Status = true,
                    Data = objs
                };
            return new ResponseMessage<IEnumerable<T>>() { Message = "The object is not found..." };
        }
        //GetWhereAsyncWithInclude
        public async Task<ResponseMessage<IEnumerable<T>>> GetWhereAsyncWithInclude(Expression<Func<T, bool>> predicate, string include)
        {
            var objs = await _dbSet.Include(include).Where<T>(predicate).ToListAsync();
            if (objs is not null)
                return new ResponseMessage<IEnumerable<T>>()
                {
                    Message = "The object is successfully found...",
                    Status = true,
                    Data = objs
                };
            return new ResponseMessage<IEnumerable<T>>() { Message = "The object is not found..." };
        }

        public async Task<ResponseMessage<T2>> GetAttributeAsync<T2>(Expression<Func<T, bool>> predicate1, Expression<Func<T, T2>> predicate2)
        {
            var obj = await _dbSet.Where(predicate1).Select(predicate2).FirstOrDefaultAsync();
            if (obj != null)
            {
                return new ResponseMessage<T2>()
                {
                    Message = "The object is successfully found...",
                    Status = true,
                    Data = obj
                };
            }
            return new ResponseMessage<T2>() { Message = "The object is not found..." };
        }
        public async Task<ResponseMessage<T>> Add(T model)
        {
            var obj = await _dbSet.AddAsync(model);
            if (obj is not null)
                return new ResponseMessage<T>()
                {
                    Message = "This object is added successfully...",
                    Status = true,
                    Data = obj.Entity
                };
            return new ResponseMessage<T>() { Message = "This object is not added..." };
        }

        public async Task AddRange(List<T> models)
        {
            await _dbSet.AddRangeAsync(models);
        }

        public ResponseMessage<T> Update(T model)
        {
            var obj = _dbSet.Update(model);
            if (obj is not null)
                return new ResponseMessage<T>()
                {
                    Message = "This object is updated successfully...",
                    Status = true,
                    Data = obj as T
                };
            return new ResponseMessage<T>() { Message = "Cannot update this object..." };
        }
        public void UpdateRanage(List<T> models)
        {
            _dbSet.UpdateRange(models);
        }


        public async Task<ResponseMessage<T>> Delete(int id)
        {
            var model = await _dbSet.FindAsync(id);
            if (model is not null)
            {
                var obj = _dbSet.Remove(model);
                if (obj is not null)
                    return new ResponseMessage<T>()
                    {
                        Message = "This object is deleted Successfully...",
                        Status = true,
                        Data = obj as T
                    };
                return new ResponseMessage<T>() { Message = "Cannot delete this object" };
            }
            return new ResponseMessage<T>() { Message = "Cannot find this object" };
        }
        public async Task<ResponseMessage<T>> Delete(string id)
        {
            var model = await _dbSet.FindAsync(id);
            if (model is not null)
            {
                var obj = _dbSet.Remove(model);
                if (obj is not null)
                    return new ResponseMessage<T>()
                    {
                        Message = "This object is deleted Successfully...",
                        Status = true,
                        Data = obj as T
                    };
                return new ResponseMessage<T>() { Message = "Cannot delete this object" };
            }
            return new ResponseMessage<T>() { Message = "Cannot find this object" };
        }

        public async Task<ResponseMessage<IEnumerable<T>>> DeleteRange(List<int> ids)
        {
            ResponseMessage<IEnumerable<T>> responseMessage = new ResponseMessage<IEnumerable<T>>();
            foreach (var id in ids)
            {
                var response = await Delete(id);
                if (response.Status)
                {
                    responseMessage.Data.Append(response.Data);
                    responseMessage.Message += $"The object with id = {id} is deleted successfull...\n";
                }
                else
                    responseMessage.Message += $"The object with id = {id} cannot be deleted...\n";
            }
            if (responseMessage.Data is not null)
                responseMessage.Status = true;
            return responseMessage;
        }
        public async Task<ResponseMessage<IEnumerable<T>>> DeleteAllAsync()
    {
        var all = await _dbSet.ToListAsync();
        if (all.Any())
        {
            _dbSet.RemoveRange(all);
            return new ResponseMessage<IEnumerable<T>>()
            {
                Message = "All objects are deleted successfully...",
                Status = true,
                Data = all
            };
        }
        return new ResponseMessage<IEnumerable<T>>()
        {
            Message = "No objects found to delete..."
        };
    }
       

    }
    
}
