using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_S
{
  public class StudentAttendance
    {
       [Key] public int SA_Id { get; set; }      
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
    }
}
