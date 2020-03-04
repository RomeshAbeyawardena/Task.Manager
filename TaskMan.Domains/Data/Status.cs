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
    [MessagePack.MessagePackObject(true)]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Modifier(ModifierFlag.Created)]
        public DateTimeOffset Created { get; set; }

        [Modifier(ModifierFlag.Created | ModifierFlag.Modified)]
        public DateTimeOffset Modified { get; set; }
    }
}
