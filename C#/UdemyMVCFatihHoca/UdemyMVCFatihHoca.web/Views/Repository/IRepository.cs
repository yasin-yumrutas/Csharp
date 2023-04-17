﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyMVCFatihHoca.web.Views.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
         
        Task<TEntity> GetById(int id);
        
        Task Create(TEntity entity);
        
        void Update(TEntity entity);
        
        void Delete(TEntity entity);
        void Delete(int productId);
    }
}
