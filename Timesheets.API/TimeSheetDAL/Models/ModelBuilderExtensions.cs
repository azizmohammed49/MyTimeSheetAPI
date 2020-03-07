using Microsoft.EntityFrameworkCore;
using TimeSheetDAL.BO;

namespace TimeSheetDAL.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData
            (
                new Task
                {
                    TaskId = 1,
                    Name = "Sick Leave",
                    Description = "Apply this task on sick leave."
                },
                new Task
                {
                    TaskId = 2,
                    Name = "Scrum Ceremonies",
                    Description = "Scrum meetings, standup, sprint plannig, grooming etc."
                },
                new Task
                {
                    TaskId = 3,
                    Name = "Internal Meetings",
                    Description = "Meetings Meetings."
                },
                new Task
                {
                    TaskId = 4,
                    Name = "Development",
                    Description = "Development tasks, features, change requets."
                },
                new Task
                {
                    TaskId = 5,
                    Name = "Bug Fixes",
                    Description = "You know what it means."
                }
            );
        }
    }
}
