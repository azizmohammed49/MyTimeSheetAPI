using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheetDAL.BO;
using TimeSheetDAL.Models;

namespace TimeSheetDAL.DO
{
    public interface IEmployeeDb
    {
        void Insert(Employee D);
        void Update(Employee D);
        void Delete(int did);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByEmpId(int empId);
    }
    public class EmployeeDb : IEmployeeDb, IDisposable
    {
        public TimeSheetDbContext DbContext;

        public EmployeeDb(TimeSheetDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public void Delete(int empId)
        {
            var T = DbContext.Employees.Find(empId);
            DbContext.Remove(T);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public Employee GetEmployeeByEmpId(int empId)
        {
            var T = DbContext.Employees.Find(empId);
            return T;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var emp = DbContext.Employees.Include(e => e.Task);
            return emp.ToList();
        }

        public void Insert(Employee E)
        {
            DbContext.Add(E);
            DbContext.SaveChanges();
        }

        public void Update(Employee E)
        {
            DbContext.Update(E);
            DbContext.SaveChanges();
        }
    }
}
