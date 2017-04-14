using System;

namespace CourseCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseFile courseFile = new CourseFile();

            // Get Records from file.
            courseFile.GetRecords(args[0]);

            // Create Catalog and load courses.
            Catalog catalog = new Catalog();
            if (catalog.LoadCourses(courseFile.Courses))
            {
                catalog.PrintCourseList();
            }
            else
            {
                // Circular Reference was found with the data.
                Console.WriteLine("Course Catalog Creation Failure: Circular Reference was found.");
            }
        }
    }
}
