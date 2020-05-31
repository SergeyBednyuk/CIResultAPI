using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models
{
    public class FeatureDto
    {
        public string Name { get; set; }
        //
        public virtual ICollection<Result> Results { get; set; }
    }
}
