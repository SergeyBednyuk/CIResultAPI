using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.Entities
{
    public class CIExecution
    {
        [Key]
        public int Id { get; set; }
        public string DbType { get; set; }
        public string BrowserType { get; set; }
        public string Name { get; set; }
        //?
        public string Product { get; set; }
        //[NotMapped]
        public string Path { get; set; }
        //
        public virtual ICollection<Result> Results { get; set; }
    }
}
