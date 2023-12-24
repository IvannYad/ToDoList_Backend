using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Entity;
using ToDoList.DAL.Utility;

namespace ToDoList.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>().HasData(
                new ToDoTask
                {
                    Id = 1,
                    TaskTitle = "Do nothing1",
                    AdditionalDescription = "Just do nothing",
                    TaskStartTime = DateTime.Now,
                    TaskEndTime = DateTime.Now.AddDays(1),
                    Status = StaticData.DoneStatus,
                    Type = StaticData.FeatureType
                },
                new ToDoTask
                {
                    Id = 2,
                    TaskTitle = "Do nothing2",
                    AdditionalDescription = "Just do nothing",
                    TaskStartTime = DateTime.Now,
                    TaskEndTime = DateTime.Now.AddDays(1),
                    Status = StaticData.InProgressStatus,
                    Type = StaticData.BugType
                },
                new ToDoTask
                {
                    Id = 3,
                    TaskTitle = "Do nothing3",
                    AdditionalDescription = "Just do nothing",
                    TaskStartTime = DateTime.Now,
                    TaskEndTime = DateTime.Now.AddDays(1),
                    Status = StaticData.InProgressStatus,
                    Type = StaticData.FeatureType
                },
                new ToDoTask
                {
                    Id = 4,
                    TaskTitle = "Do nothing4",
                    AdditionalDescription = "Just do nothing",
                    TaskStartTime = DateTime.Now,
                    TaskEndTime = DateTime.Now.AddDays(2),
                    Status = StaticData.ToDoStatus,
                    Type = StaticData.BugType
                },
                new ToDoTask
                {
                    Id = 5,
                    TaskTitle = "Do nothing5",
                    AdditionalDescription = "Just do nothing",
                    TaskStartTime = DateTime.Now,
                    TaskEndTime = DateTime.Now.AddDays(3),
                    Status = StaticData.ToDoStatus,
                    Type = StaticData.FeatureType
                }
                );
        }
    }
}
