using System;
using System.ComponentModel.DataAnnotations;

namespace WebPagedList.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="姓名")]
        public string Name { get; set; }
        [Display(Name ="年龄")]
        public string Age { get; set; }
    }
}