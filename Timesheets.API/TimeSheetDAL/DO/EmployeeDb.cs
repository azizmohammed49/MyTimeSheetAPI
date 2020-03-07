using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheetDAL.BO;
using TimeSheetDAL.Models;
using TimeSheetDAL.ViewModel;

namespace TimeSheetDAL.DO
{
    public interface IEmployeeDb
    {
        void Insert(Employee D);
        void Update(Employee D);
        void Delete(int did);
        IEnumerable<TaskViewModel> GetEmployees();
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
            var emp = DbContext.Employees
                .Include(e => e.Task)
                .FirstOrDefault(m => m.EmpId == empId);
            return emp;
        }

        public IEnumerable<TaskViewModel> GetEmployees()
        {
            List<TaskViewModel> empModels = new List<TaskViewModel>();
            var emp = DbContext.Employees.Include(e => e.Task).AsNoTracking();
            foreach (var item in emp)
            {
                TaskViewModel model = new TaskViewModel()
                {
                    EmpID = item.EmpId,
                    EmpName = item.Name,
                    Code = item.Code,
                    TaskName = item.Task.Name,
                    Description = item.Task.Description

                };
                empModels.Add(model);
            }
            return empModels;
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
