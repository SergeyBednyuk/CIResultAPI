﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models
{
    public class ErrorImageDto
    {
        public byte[] ImageOfError { get; set; }
        public string Name { get; set; }
        //
        public virtual int ResultId { get; set; }
    }
}
