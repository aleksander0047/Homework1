using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaskForElectiveCourses
{
    class StudentInfo
    {
        public string NameOfTheStudent { get; set; }
        public int FacultyNum { get; set; }
        public string NameOfTheElectiveCourse { get; set; }
        public Dictionary<string, double> NameOfTheElectiveCourseAndGrade { get; set; }
        public double Grades
        {
            get
            {
                return this.NameOfTheElectiveCourseAndGrade.Max(x => x.Value);
            }
        }
        
        public StudentInfo()
        {
            this.NameOfTheElectiveCourseAndGrade = new Dictionary<string, double>(); 
        }
        public override string ToString()
        {
            return $"{this.NameOfTheStudent}, {this.NameOfTheElectiveCourse}, {this.Grades}";
        }
    }
   
    class Program
    { 

        static void Main(string[] args)
        {
       
            Console.WriteLine("Enter student information:");
            Console.WriteLine("Name of elective course => Name of the student => faculty number => grade:");
            List<StudentInfo> studentinfo = new List<StudentInfo>();
            while(true)
            {
                string input = Console.ReadLine();
                if(input=="end")
                {
                    break;
                }
                string[] data = input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim()).ToArray();
                string electivecoursename = data[0];
                string studentname = data[1];
                int facultynumber = int.Parse(data[2]);
                double grade = double.Parse(data[3]);
                if (grade >= 2 && grade <= 6)
                {
                    StudentInfo s = studentinfo.Where(stu => stu.NameOfTheStudent.Equals(studentname)).FirstOrDefault();
                    if (s == null)
                    {
                        s = new StudentInfo() { NameOfTheStudent = studentname, FacultyNum = facultynumber, NameOfTheElectiveCourse = electivecoursename};
                        s.NameOfTheElectiveCourseAndGrade.Add(electivecoursename, grade);
                        studentinfo.Add(s);
                    }
                }
                else
                {
                    Console.WriteLine("The entered grades are not in the range between 2 and 6!");
                }
            }

            Console.WriteLine("Students information:");
            foreach (StudentInfo studentInfo in studentinfo.OrderByDescending(x => x.Grades))
            {
                Console.WriteLine(studentInfo.ToString());
            }

            Console.ReadLine();
        }
    }
}
