using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data;
using Demo.DAL.Data.Repository.Interfaces;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Demo.DAL.Data.Repository.Claess
{
    public class DepartmentRepository(AppDbContext _dbContext) : GenericRepository<Department>(_dbContext), IDepartmentRepository
    {
        //    // we create a null ref from the type AppDbContext
        //    private readonly AppDbContext _dbContext; // we make it private and readonly to enusre that now data will change

        //    // ask CLR to create an object from AppDbContext class (DI)
        //    public DepartmentRepository(AppDbContext dbContext)
        //    {
        //        _dbContext = dbContext; // set the null ref from the type AppDbContext to point at the AppDbContext object
        //    }

        //    public int Add(Department Entity)
        //    {
        //        _dbContext.Departments.Add(Entity);
        //        return _dbContext.SaveChanges();
        //    }

        //    public int Delete(Department Entity)
        //    {
        //        _dbContext.Departments.Remove(Entity); // change entity status to deleted (just locally)
        //        return _dbContext.SaveChanges();
        //    }

        //    public IEnumerable<Department> GetAll(bool withtracking = false)
        //    {
        //        if (withtracking)
        //        {
        //            return _dbContext.Departments.ToList();
        //        }
        //        else
        //        {
        //            return _dbContext.Departments.AsNoTracking().ToList();
        //        }
        //    }

        //    public Department GetById(int id)
        //    {
        //        return _dbContext.Departments.Find(id); // search first in the local data if we don't find it we search in database
        //    }

        //    public int Update(Department Entity)
        //    {
        //        _dbContext.Departments.Update(Entity); // change entity status to modified (just locally)
        //        return _dbContext.SaveChanges();
        //    }
       
    }
}

