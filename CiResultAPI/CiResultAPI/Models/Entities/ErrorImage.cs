using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.Entities
{
    public class ErrorImage
    {
        [Key]
        public int Id { get; set; }
        public byte[] ImageOfError { get; set; }
        public string Name { get; set; }
        //
        public virtual int ResultId { get; set; }
        public virtual Result Result { get; set; }
    }
}
