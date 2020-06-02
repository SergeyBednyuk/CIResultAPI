using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.DTOs
{
    public class ErrorImageDtoForCreationg
    {
        public byte[] ImageOfError { get; set; }
        public string Name { get; set; }
        //
        public virtual int ResultId { get; set; }
    }
}
