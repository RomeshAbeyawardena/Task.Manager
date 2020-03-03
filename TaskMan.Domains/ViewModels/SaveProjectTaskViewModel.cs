using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.ViewModels
{
    public class SaveProjectTaskViewModel
    {
        public int TaskId { get; set; }
        public string TaskReference { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string TaskDescription { get; set; }
    }
}
