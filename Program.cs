using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseFile courseFile = new CourseFile();
            courseFile.GetRecords(args[0]);

            Catalog catalog = new Catalog();
            if (catalog.LoadCourses(courseFile.Courses))
            {
                catalog.PrintCatalog();
            }
            else
            {
                Console.WriteLine("Course Catalog Creation Failure: Circular Reference was found.");
            }
        }
    }
}
