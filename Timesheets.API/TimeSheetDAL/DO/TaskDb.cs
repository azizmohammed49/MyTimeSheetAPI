using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheetDAL.BO;
using TimeSheetDAL.Models;

namespace TimeSheetDAL.DO
{
    public interface ITaskDb
    {
        void Insert(Task D);
        void Update(Task D);
        void Delete(int did);
        IEnumerable<Task> GetTasks();
        Task GetTaskByTid(int did);
    }
    public class TaskDb : ITaskDb, IDisposable
    {
        private TimeSheetDbContext DbContext;

        public TaskDb()
        {
            DbContext = new TimeSheetDbContext();
        }
        public void Delete(int tid)
        {
            var T = DbContext.Tasks.Find(tid);
            DbContext.Remove(T);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public Task GetTaskByTid(int tid)
        {
            var T = DbContext.Tasks.Find(tid);
            return T;
        }

        public IEnumerable<Task> GetTasks()
        {
            var T = DbContext.Tasks.ToList();
            return T;
        }

        public void Insert(Task T)
        {
            DbContext.Add(T);
            DbContext.SaveChanges();
        }

        public void Update(Task T)
        {
            DbContext.Update(T);
            DbContext.SaveChanges();
        }
    }
}
