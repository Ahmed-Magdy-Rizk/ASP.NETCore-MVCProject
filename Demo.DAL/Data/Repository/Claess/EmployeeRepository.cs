﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repository.Interfaces;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.DAL.Data.Repository.Claess
{
    public class EmployeeRepository(AppDbContext _dbContext) : GenericRepository<Employee>(_dbContext), IEmployeeRepository
    {
        public IQueryable<Employee> GetEmployeeByName(string name)
        {
            return _dbContext.Employees.Where(E => E.Name.ToLower().Contains(name));
        }
    }
}
