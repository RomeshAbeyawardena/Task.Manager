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
    public class ProjectTaskStatus
    {
        [Key]
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public int StatusId { get; set; }
        public ProjectTask ProjectTask { get; set; }
        
        [Modifier(ModifierFlag.Created)]
        public DateTimeOffset Created { get; set; }

        [Modifier(ModifierFlag.Created 
                    | ModifierFlag.Modified)]
        public DateTimeOffset Modified { get; set; }
    }
}
