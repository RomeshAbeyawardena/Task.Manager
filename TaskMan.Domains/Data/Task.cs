﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Domains.Data
{
    public class Task
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public object Description { get; set; }
    }
}
