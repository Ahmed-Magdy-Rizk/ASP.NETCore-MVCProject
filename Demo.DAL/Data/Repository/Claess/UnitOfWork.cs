using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repository.Interfaces;

namespace Demo.DAL.Data.Repository.Claess
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;
        private readonly AppDbContext _dbContext;

        public UnitOfWork(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, AppDbContext dbContext)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _dbContext = dbContext;
        }

        public IEmployeeRepository EmployeeRepository 
        { 
            get { return _employeeRepository; }
            set { _employeeRepository = value; }
        }
        public IDepartmentRepository DepartmentRepository 
        { 
            get { return _departmentRepository; }
            set { _departmentRepository = value; }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
