using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Domains.Requests;
using TaskMan.Domains.ViewModels;

namespace TaskMan.Domains
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<SaveProjectTaskViewModel, SaveProjectTaskRequest>();
        }
    }
}
