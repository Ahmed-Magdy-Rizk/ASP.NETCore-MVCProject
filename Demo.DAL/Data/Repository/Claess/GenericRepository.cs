using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repository.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repository.Claess
{
    public class GenericRepository<TEntity>(AppDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        
        public void Add(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Add(Entity);
            //return _dbContext.SaveChanges();
        }

        public void Delete(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Remove(Entity); // change entity status to deleted (just locally)
            //return _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll(bool withtracking = false)
        {
            if (withtracking)
            {
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted == false);
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted == false).AsNoTracking();
            }
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id); // search first in the local data if we don't find it we search in database
        }

        public void Update(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Update(Entity); // change entity status to modified (just locally)
            //return _dbContext.SaveChanges();
        }
    }
}
