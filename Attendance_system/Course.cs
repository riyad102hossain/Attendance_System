using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_S
{
    public class Course
    {
        
       [Key] public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public double? Fees { get; set; }
        public int? TeacherId { get; set; }
    
        public string? T_Username { get; set; }

        public IEnumerable<CourseStudent>? StudentCourses { get; set; }
    }
}