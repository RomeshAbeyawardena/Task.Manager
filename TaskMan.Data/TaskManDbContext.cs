using DNI.Shared.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Data
{
    public class TaskManDbContext : DbContextBase
    {
        public TaskManDbContext(Microsoft.EntityFrameworkCore.DbContextOptions dbContextOption)
            : base(dbContextOption, true, true, true)
        {

        }
    }
}
