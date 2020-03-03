using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.Data
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public Task Task { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
    }
}
