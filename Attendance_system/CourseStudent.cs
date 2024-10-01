using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_S
{
    public class CourseStudent
    {
       [Key] public int CS_ID { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
