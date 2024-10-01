using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_S
{
    public class Teacher
    {
       
        public int TeacherId { get; set; }
        public string T_Name { get; set; }
        public string T_Username { get; set; }
        public string T_Password { get; set; }
        public UserType Type { get; set; }
    }
}
