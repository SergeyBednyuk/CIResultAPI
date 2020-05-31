using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.Entities
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string ResultOfTest { get; set; }
        public int Total { get; set; }
        public int Passed { get; set; }
        public int Failed { get; set; }
        public int Skipped { get; set; }
        public string ErrorMessage { get; set; }
        public string NameOfVirtualMachine { get; set; }
        //
        public virtual ICollection<ErrorImage> ErrorImages { get; set; }
        public virtual int FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual int CIExecutionId { get; set; }
        public virtual CIExecution CIExecution { get; set; }
    }
}
