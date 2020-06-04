using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.DTOs
{
    public class ErrorImageForUpdatingDto
    {
        public byte[] ImageOfError { get; set; }
        public string Name { get; set; }
    }
}
