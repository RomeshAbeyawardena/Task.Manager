using DNI.Shared.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Domains.Data;

namespace TaskMan.Data
{
    public class TaskManDbContext : DbContextBase
    {
        public TaskManDbContext(Microsoft.EntityFrameworkCore.DbContextOptions dbContextOption)
            : base(dbContextOption, true, true, true)
        {

        }


        public DbSet<Project> Projects { get; set; }
        public DbSet<Domains.Data.Task> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ProjectTaskComment> ProjectTaskComments { get; set; }
        public DbSet<ProjectTaskStatus> ProjectTaskStatuses { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<TaskReference> TaskReferences { get; set; }
    }
}
