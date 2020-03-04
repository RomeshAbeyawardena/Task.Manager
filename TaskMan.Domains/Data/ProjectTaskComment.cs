using DNI.Shared.Contracts.Enumerations;
using DNI.Shared.Services.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.Data
{
    public class ProjectTaskComment
    {
        [Key]
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public string Comment { get; set; }
        [Modifier(ModifierFlag.Created)]
        public DateTimeOffset Created { get; set; }
    }
}
