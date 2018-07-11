using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class WorkerImage
    {
        public int Id { get; set; }
        [Display(Name ="File")]
        public string FileName { get; set; }
    }
}