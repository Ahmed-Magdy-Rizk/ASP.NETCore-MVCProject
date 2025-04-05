using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.DAL.Data.Repository.Interfaces
{
    internal interface IDepartmentRepository
    {
        // Get All
        IEnumerable<Department> GetAll(bool withtracking); // we choose to use IEnumerable over ICollection and IQueryable because we need to get all the data not filtiratrion nedded
        // Get Department by Id 
        Department GetById(int id);
        // Update
        int Update(Department Entity); // return type is int because it will return the number of affected rows
        // Delete
        int Delete(Department Entity);
        // Insert
        int Add(Department Entity);




    }
}
