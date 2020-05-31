using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.Entities
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //
        public virtual ICollection<Result> Results { get; set; }
    }
}
