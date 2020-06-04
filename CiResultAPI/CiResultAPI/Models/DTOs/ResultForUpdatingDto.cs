using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.DTOs
{
    public class ResultForUpdatingDto
    {
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
        [Required]
        public virtual int FeatureId { get; set; }
        [Required]
        public virtual int CIExecutionId { get; set; }
    }
}
