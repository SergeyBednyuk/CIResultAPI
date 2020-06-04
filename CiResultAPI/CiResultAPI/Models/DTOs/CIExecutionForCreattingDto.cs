using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.DTOs
{
    public class CIExecutionForCreattingDto
    {
        public string DbType { get; set; }
        public string BrowserType { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public string Path { get; set; }
        
    }
}
