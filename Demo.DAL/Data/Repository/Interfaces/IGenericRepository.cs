using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.DAL.Data.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // Get All
        public IEnumerable<TEntity> GetAll(bool withtracking = false); // we choose to use IEnumerable over ICollection and IQueryable because we need to get all the data not filtiratrion nedded
                                                                          // Get Department by Id 
        public TEntity GetById(int id);
        // Update
        public int Update(TEntity Entity); // return type is int because it will return the number of affected rows
        // Delete
        public int Delete(TEntity Entity);
        // Insert
        public int Add(TEntity Entity);

    }
}
