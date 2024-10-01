using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_S
{
    public class ClassSchedule
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Day1 { get; set; }
         public string Day2 { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TotalClasses { get; set; }
        public Course Course { get; set; }
    }
}
