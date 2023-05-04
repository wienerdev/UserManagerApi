﻿using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(long id);

        Task<List<T>> GetAll();

        Task<T> GetById(long id);
    }
}
