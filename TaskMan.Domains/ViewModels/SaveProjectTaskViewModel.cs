using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.ViewModels
{
    public class SaveProjectTaskViewModel
    {
        public int TaskId { get; set; }
        [Required]
        public string TaskReference { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string TaskDescription { get; set; }
        public string Comment { get; set; }
        public string References { get; set; }
    }
}
