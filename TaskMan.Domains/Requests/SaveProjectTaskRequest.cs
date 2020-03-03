using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Domains.Responses;

namespace TaskMan.Domains.Requests
{
    public class SaveProjectTaskRequest : IRequest<SaveProjectTaskResponse>
    {
        public int TaskId { get; set; }
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
