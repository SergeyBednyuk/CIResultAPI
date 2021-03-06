﻿using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models
{
    public class CIExecutionDto
    {
        public string DbType { get; set; }
        public string BrowserType { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public string Path { get; set; }
        //
        public virtual ICollection<Result> Results { get; set; }
    }
}
