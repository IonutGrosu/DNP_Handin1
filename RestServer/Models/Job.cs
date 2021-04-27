using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(32)]
        public string JobTitle { get; set; }
        [Required, Range(0, Int32.MaxValue, ErrorMessage = "Please enter a valid salary")]
        public int Salary { get; set; }
    }
}