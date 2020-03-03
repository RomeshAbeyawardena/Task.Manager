using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.Data
{
    public class ProjectTaskStatus
    {
        public int StatusId { get; set; }
        public ProjectTask ProjectTask { get; set; }
    }
}
