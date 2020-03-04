﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNI.Shared.Contracts.Enumerations;
using DNI.Shared.Services.Attributes;

namespace TaskMan.Domains.Data
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Modifier(ModifierFlag.Created)]
        public DateTimeOffset Created { get; set; }

        [Modifier(ModifierFlag.Created 
                    | ModifierFlag.Modified)]
        public DateTimeOffset Modified { get; set; }
    }
}
