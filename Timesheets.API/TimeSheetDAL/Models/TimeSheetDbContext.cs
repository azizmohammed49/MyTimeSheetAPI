using Microsoft.EntityFrameworkCore;
using TimeSheetDAL.BO;

namespace TimeSheetDAL.Models
{
    public class TimeSheetDbContext : DbContext
    {
        public TimeSheetDbContext()
        {
        }

        public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Seed();
        //}


    }
}
