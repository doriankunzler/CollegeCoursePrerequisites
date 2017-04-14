using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCatalog
{
    class CourseFile
    {
        public string Filename { get; private set; }
        public string[] Courses { get; private set; }

        public CourseFile()
        {

        }

        public CourseFile(string filename)
        {
            Filename = filename;
        }

        public void GetRecords()
        {
            try
            {
                Courses = File.ReadAllLines(Filename);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException)
                {
                    Console.WriteLine("File not found!");
                    throw new FileNotFoundException(@"The file was not found", e);
                }
                else if (e is ArgumentException)
                {
                    Console.WriteLine("Invalid Path!");
                    throw new ArgumentException(@"The path was invalid", e);
                }
            }
        }

        public void GetRecords(string filename)
        {
            Filename = filename;
            GetRecords();
        }
    }
}
