﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.DAL.Data.Repository.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        //// Get All
        //IQueryable<Department> GetAll(bool withtracking = false); // we choose to use IEnumerable over ICollection and IQueryable because we need to get all the data not filtiratrion nedded
        //// Get Department by Id 
        //Department GetById(int id);
        //// Update
        //int Update(Department Entity); // return type is int because it will return the number of affected rows
        //// Delete
        //int Delete(Department Entity);
        //// Insert
        //int Add(Department Entity);




    }
}
