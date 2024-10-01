using A_S;
using Microsoft.EntityFrameworkCore;

while (true)
{
    Console.WriteLine("  Login As: ");
    Console.WriteLine("           1.Admin ");
    Console.WriteLine("           2.Student ");
    Console.WriteLine("           3.Teacher ");

    int n = int.Parse(Console.ReadLine());

    if (n == 1)
    {

        //............................................................................................. Admin Login
        using (var dbContext = new AS_DbContext())
        {
            Console.Write("  Enter Admin username: ");
            string l_username = Console.ReadLine();

            Console.Write("  Enter Admin password: ");
            string l_password = Console.ReadLine();


            var user = dbContext.Admins.FirstOrDefault(u => u.Username == l_username && u.Password == l_password);

            if (user != null)
            {
                while (true)
                {
                    Console.WriteLine($"Welcome.................. {user.Username}!.... User Type: {user.Type}");
                    Console.WriteLine();
                    Console.WriteLine("            1.Add Teacher");
                    Console.WriteLine("            2.Add Course");
                    Console.WriteLine("            3.Add Student");
                    Console.WriteLine("            4.Assign a teacher in a course");
                    Console.WriteLine("            5.Assign a students in a course");
                    Console.WriteLine("            6.Set class schedule for a course");
                    Console.WriteLine("            7.Logout");

                    int choice;

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                //...........................................................    ...   add teacher
                                Console.Write("  Enter Teacher Name: ");
                                string teacherName = Console.ReadLine();

                                Console.Write("  Enter Teacher Username: ");
                                string teacherUsername = Console.ReadLine();

                                Console.Write("  Enter Teacher password: ");
                                string teacherPassword = Console.ReadLine();

                                UserType teacherType = UserType.Teacher;


                                using (var context = new AS_DbContext())
                                {
                                    var newTeacher = new Teacher
                                    {
                                        T_Name = teacherName,
                                        T_Username = teacherUsername,
                                        T_Password = teacherPassword,
                                        Type = teacherType,

                                    };
                                    context.Teachers.Add(newTeacher);

                                    context.SaveChanges();
                                    Console.WriteLine(" .............Teacher added to the database.");

                                    static void DisplayTeachers(IEnumerable<Teacher> teachers)
                                    {
                                        Console.WriteLine("Teacher List:");
                                        Console.WriteLine("-------------");
                                        Console.WriteLine(" ID\t    Name\t  Username\t  UserType");
                                        Console.WriteLine("..........................................................");

                                        foreach (var teacher in teachers)
                                        {
                                            Console.WriteLine($"{      teacher.TeacherId}\t{teacher.T_Name}\t{teacher.T_Username}\t{teacher.Type}");
                                        }

                                        Console.WriteLine("...........................................................");
                                    }
                                    DisplayTeachers(new List<Teacher> { newTeacher });
                                    using (var dbcontext = new AS_DbContext())
                                    {
                                        var teachers = context.Teachers.ToList();
                                        DisplayTeachers(teachers);
                                    }
                                }
                                break;


                            case 2:

                                //  ..............................................................add course
                                Console.Write("  Enter course name: ");
                                string courseName = Console.ReadLine();
                                int? teacherId = null;
                                string? t_username = null;
                                Console.Write("  Enter course fees: ");
                                if (double.TryParse(Console.ReadLine(), out double fees))
                                {
                                    var newCourse = new Course
                                    {
                                        CourseName = courseName,
                                        Fees = fees,
                                        TeacherId = teacherId,
                                        T_Username = t_username
                                    };

                                    using (var Context = new AS_DbContext())
                                    {

                                        dbContext.Courses.Add(newCourse);

                                        try
                                        {
                                            dbContext.SaveChanges();
                                            Console.WriteLine("................Course added to the database.");

                                            Console.WriteLine();

                                            static void DisplayCourses(IEnumerable<Course> courses)
                                            {
                                                Console.WriteLine("Course List:");
                                                Console.WriteLine("------------");
                                                Console.WriteLine("ID\t CourseName\t Fees\t    TeacherID\t  TeacherUsername");
                                                Console.WriteLine("......................................................................");

                                                foreach (var course in courses)
                                                {
                                                    Console.WriteLine($"{course.CourseId}     \t{course.CourseName}      \t{course.Fees}        \t{course.TeacherId}       \t{course.T_Username}");
                                                } 

                                                Console.WriteLine("......................................................................");
                                            }
                                            DisplayCourses(new List<Course> { newCourse });
                                            using (var context = new AS_DbContext())
                                            {
                                                var courses = context.Courses.ToList();
                                                DisplayCourses(courses);
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"An error occurred: {ex.Message}");

                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("............Invalid course fees format.");
                                }
                                break;
                            case 3:
                                //...........................................................    ...   add Student
                                Console.Write("  Enter Student name: ");
                                string sName = Console.ReadLine();

                                Console.Write("  Enter Student username: ");
                                string sUsername = Console.ReadLine();

                                Console.Write("  Enter Student password: ");
                                string sPassword = Console.ReadLine();

                                UserType sType = UserType.Student;


                                using (var context = new AS_DbContext())
                                {
                                    var newStudent = new Student
                                    {
                                        S_Name = sName,
                                        S_Username = sUsername,
                                        S_Password = sPassword,
                                        Type = sType,

                                    };
                                    context.Students.Add(newStudent);

                                    context.SaveChanges();
                                    Console.WriteLine("................Student added to the database.");
                                    Console.WriteLine();
                                    static void DisplayStudents(IEnumerable<Student> students)
                                    {
                                        Console.WriteLine("Studnet List:");
                                        Console.WriteLine("-------------");
                                        Console.WriteLine(" ID\t    Name\t  Username\t  UserType");
                                        Console.WriteLine("..........................................................");

                                        foreach (var student in students)
                                        {
                                            Console.WriteLine($"{student.StudentId}\t{student.S_Name}\t{student.S_Username}\t{student.Type}");
                                        }

                                        Console.WriteLine("...........................................................");
                                    }
                                    DisplayStudents(new List<Student> { newStudent });
                                    using (var dbcontext = new AS_DbContext())
                                    {
                                        var students = context.Students.ToList();
                                        DisplayStudents(students);
                                    }
                                }
                                break;
                            case 4:

                                //............................................................   ...     add teacher in course

                                Console.Write("  Enter Coursename: ");
                                string coursename = Console.ReadLine();

                                using (var Context = new AS_DbContext())
                                {
                                    var course = dbContext.Courses.FirstOrDefault(u => u.CourseName == coursename);

                                    if (course != null)
                                    {
                                        Console.Write("  Enter Teacher ID: ");
                                        int teacherid = int.Parse(Console.ReadLine());

                                        Console.Write("  Enter Teacher username: ");
                                        string teacherusername = Console.ReadLine();

                                        var teacher = dbContext.Teachers.FirstOrDefault(u => u.TeacherId == teacherid && u.T_Username == teacherusername);

                                        if (teacher != null)
                                        {

                                            course.TeacherId = teacherid;
                                            course.T_Username = teacherusername;

                                            dbContext.SaveChanges();
                                            Console.WriteLine("...............Teacher added to the course successfully.");
                                            Console.WriteLine();

                                            static void DisplayCourses(IEnumerable<Course> courses)
                                            {
                                                Console.WriteLine("Course-Teacher List:");
                                                Console.WriteLine("CourseID\tCoursename \t Fees \t TeacherID  \t  TeacherUsername");
                                                Console.WriteLine("-----------------------------------------------------------------");

                                                foreach (var course in courses)
                                                {
                                                    Console.WriteLine($"{course.CourseId}\t{course.CourseName}  \t  {course.Fees}   \t  {course.TeacherId}   \t  {course.T_Username}");
                                                }

                                                Console.WriteLine("-----------------------------------------------------------------");
                                            }
                                           
                                            DisplayCourses(new List<Course> { course });
                                            using (var context = new AS_DbContext())
                                            {
                                                var courses = context.Courses.ToList();
                                                DisplayCourses(courses);
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("...........Teacher not found. Please check the Teacher ID and Username.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("............Course not found. Please check the coursename.");
                                    }
                                }

                                break;

                            case 5:
                                //......................................................      add students in a course

                                Console.Write("  Enter courseid: ");
                                int c_Id = int.Parse(Console.ReadLine());

                                Console.Write("  Enter studentid: ");
                                int s_Id = int.Parse(Console.ReadLine());

                                using (var context = new AS_DbContext())
                                {
                                    var existingCourse = context.Courses.FirstOrDefault(course => course.CourseId == c_Id);
                                    var existingStudent = context.Students.FirstOrDefault(student => student.StudentId == s_Id);
                                    if (existingCourse == null)
                                    {
                                        Console.WriteLine(".....Course does not exist.");
                                        return;
                                    }

                                    if (existingStudent == null)
                                    {
                                        Console.WriteLine("......Student does not exist.");
                                        return;
                                    }


                                }

                                using (var context = new AS_DbContext())
                                {
                                    var courseStudent = new CourseStudent
                                    {
                                        CourseId = c_Id,
                                        StudentId = s_Id
                                    };

                                    context.CourseStudents.Add(courseStudent);
                                    context.SaveChanges();
                                    Console.WriteLine("...................Student assigned successfully.");
                                    Console.WriteLine();

                                    static void DisplayCourseStudents(IEnumerable<CourseStudent> courseStudents)
                                    {
                                        Console.WriteLine("Course-Student List:");
                                        Console.WriteLine("CourseID\tStudentID");
                                        Console.WriteLine("---------------------------------------------");

                                        foreach (var courseStudent in courseStudents)
                                        {
                                            Console.WriteLine($"{courseStudent.CourseId}\t\t\t{courseStudent.StudentId}");
                                        }
                                    }
                                        DisplayCourseStudents(new List<CourseStudent> { courseStudent });
                                        using (var dbcontext = new AS_DbContext())
                                        {
                                            var courseStudents = context.CourseStudents.ToList();
                                            DisplayCourseStudents(courseStudents);
                                        }

                                   
                                    break;
                                }
                            case 6:
                                //................................................     set class schedule for a course


                                Console.WriteLine("  Enter Course id: ");
                                int courseid = int.Parse(Console.ReadLine());

                                using (var context = new AS_DbContext())
                                {
                                    var existingCourse = context.Courses
                                        .FirstOrDefault(course => course.CourseId == courseid);

                                    if (existingCourse == null)
                                    {
                                        Console.WriteLine("  Course name does not exist.");
                                        return;
                                    }
                                }

                                Console.WriteLine("  Enter Day 1: ");
                                string day1 = Console.ReadLine();

                                Console.WriteLine("  Enter Day 2: ");
                                string day2 = Console.ReadLine();

                                Console.WriteLine("  Enter Start Time (HH:mm:ss): ");
                                TimeSpan startTime = TimeSpan.Parse(Console.ReadLine());

                                Console.WriteLine("  Enter End Time (HH:mm:ss): ");
                                TimeSpan endTime = TimeSpan.Parse(Console.ReadLine());

                                Console.WriteLine("  Enter Total Classes: ");
                                int totalClasses = int.Parse(Console.ReadLine());

                                using (var context = new AS_DbContext())
                                {
                                    var classSchedule = new ClassSchedule
                                    {
                                        CourseId = courseid,
                                        Day1 = day1,
                                        Day2 = day2,
                                        StartTime = startTime,
                                        EndTime = endTime,
                                        TotalClasses = totalClasses
                                    };

                                    context.ClassSchedules.Add(classSchedule);
                                    context.SaveChanges();
                                    Console.WriteLine("..............ClassSchedule added successfully.");
                                    Console.WriteLine();

                                    static void DisplayClassSchedule(IEnumerable<ClassSchedule> classSchedules)
                                    {
                                        Console.WriteLine("Class Schedule Table:");
                                        Console.WriteLine($"CourseID\tDay1\tDay2\tStartTime\tEndTime   \tTotalClass");
                                       
                                        Console.WriteLine("---------------------------------------------------------------------------");

                                        foreach (var classSchedule in classSchedules)
                                        {
                                            Console.WriteLine($" {classSchedule.CourseId}\t{classSchedule.Day1}\t {classSchedule.Day2}\t {classSchedule.StartTime}\t {classSchedule.EndTime}\t{classSchedule.TotalClasses}");
                                        }
                                    }
                                    DisplayClassSchedule(new List<ClassSchedule> { classSchedule });
                                    using (var dbcontext = new AS_DbContext())
                                    {
                                        var classSchedules = context.ClassSchedules.ToList();
                                        
                                            DisplayClassSchedule(classSchedules);
                                        
                                    }
                                }

                                break;

                            case 7:
                                return;
                            default:
                                Console.WriteLine(".......Invalid choice. Please try again.");
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine(".........Invalid username or password.");

                    }
                }
            }
        }

        Console.WriteLine();
    }
    //............................................................................................. student Login
    else if (n == 2)
    {
        using (var dbContext = new AS_DbContext())
        {
            Console.Write("  Enter Student username: ");
            string l_username = Console.ReadLine();

            Console.Write("  Enter Student password: ");
            string l_password = Console.ReadLine();

            var user1 = dbContext.Students.FirstOrDefault(u => u.S_Username == l_username && u.S_Password == l_password);


            if (user1 != null)
            {
                Console.WriteLine($"................Welcome, {user1.S_Username}!....... User Type: {user1.Type}");
                //.................................................................................. give attendance
                Console.WriteLine("  1. Give Attendance");
                int x = int.Parse(Console.ReadLine());
                if (x == 1)
                {
                    Console.Write("  Enter courseid: ");
                    int c_id = int.Parse(Console.ReadLine());

                    Console.Write("  Enter studentid: ");
                    int s_id = int.Parse(Console.ReadLine());
                    using (var context = new AS_DbContext())
                    {
                        var existingCourseStudent = context.CourseStudents
                            .FirstOrDefault(cs => cs.CourseId == c_id && cs.StudentId == s_id);

                        if (existingCourseStudent == null)
                        {
                            Console.WriteLine(".......Course or Student does not exist in the CourseStudent table.");
                            return;
                        }
                    }

                    Console.Write("  Enter Attendance Date (MM-dd-yyyy): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime attendanceDate))
                    {
                        Console.WriteLine(".......Invalid date format.");
                        return;
                    }

                    Console.Write("  Is the student present? (yes/no): ");
                    string isPresentInput = Console.ReadLine().ToLower();
                    bool isPresent = isPresentInput == "yes";

                    using (var context = new AS_DbContext())
                    {
                        var studentAttendance = new StudentAttendance
                        {
                            CourseId = c_id,
                            StudentId = s_id,
                            AttendanceDate = attendanceDate,
                            IsPresent = isPresent
                        };

                        context.StudentAttendances.Add(studentAttendance);
                        context.SaveChanges();
                        Console.WriteLine("..........Attendance given successfully");
                        Console.WriteLine();

                        static void DisplaySAtten(IEnumerable<StudentAttendance> studentAttendances)
                        {
                            Console.WriteLine("StudentAttendance Table:");
                            Console.WriteLine($"SA_ID\tCourseid\tStudentid\tA_Date\t\tIsPresent");

                            Console.WriteLine("---------------------------------------------------------------------------");

                            foreach (var studentAttendance in studentAttendances)
                            {
                                Console.WriteLine($" {studentAttendance.SA_Id}\t{studentAttendance.CourseId}\t\t {studentAttendance.StudentId}\t \t{studentAttendance.AttendanceDate}\t \t{studentAttendance.IsPresent}");
                            }
                        }
                        DisplaySAtten(new List<StudentAttendance> { studentAttendance });
                        using (var dbcontext = new AS_DbContext())
                        {
                            var studentAttendances = context.StudentAttendances.ToList();

                            DisplaySAtten(studentAttendances);

                        }
                    }


                }
            }

            else
            {
                Console.WriteLine(".........Invalid username or password.");
            }
        }
    }
    //............................................................................................. Teacher Login
    else if (n == 3)
    {
        using (var dbContext = new AS_DbContext())
        {
            Console.Write("  Enter Teacher username: ");
            string l_username = Console.ReadLine();

            Console.Write("  Enter Teacher password: ");
            string l_password = Console.ReadLine();


            var user2 = dbContext.Teachers.FirstOrDefault(u => u.T_Username == l_username && u.T_Password == l_password);

            if (user2 != null)
            {
                Console.WriteLine($"Welcome,...... {user2.T_Username}!...... User Type: {user2.Type}");

                Console.Write("  Enter courseid: ");
                int courseid = int.Parse(Console.ReadLine());

                using (var context = new AS_DbContext())
                {
                    var attendanceRecords = context.StudentAttendances
                        .Where(sa => sa.CourseId == courseid)
                        .ToList();

                    if (attendanceRecords.Any())
                    {
                        Console.WriteLine($"  Attendance Records for Course {courseid}:");

                        Console.WriteLine("    ID\tStudentID\t   AttendanceDate\t\tIsPresent");
                        Console.WriteLine(".....................................................................");

                        foreach (var record in attendanceRecords)
                        {
                            Console.WriteLine($"    {record.SA_Id}\t    {record.StudentId}\t\t{record.AttendanceDate}\t\t{record.IsPresent}");
                        }
                    }
                    else
                    {
                        Console.WriteLine(".........No attendance records found for the course.");
                    }
                }
            }
            else
            {
                Console.WriteLine(".........Invalid username or password.");
            }
        }
    }
}

////.......................................................................   add Admin

//Console.Write("Enter admin username: ");
//string adminUsername = Console.ReadLine();


//Console.Write("Enter admin password: ");
//string adminPassword = Console.ReadLine();

//UserType aType = UserType.Admin;

//using (var context = new AS_DbContext())
//{

//    var admin = new Admin
//    {
//        Username = adminUsername,
//        Password = adminPassword,
//        Type = aType
//    };

//    context.Admins.Add(admin);
//    context.SaveChanges();
//    Console.WriteLine("Admin added to the database.");
//}












