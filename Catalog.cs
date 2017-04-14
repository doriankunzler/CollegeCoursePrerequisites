using System;
using System.Collections.Generic;

namespace CourseCatalog
{
    class Catalog
    {

        public Dictionary<string, List<string>> CourseList { get; private set; }

        public Catalog()
        {
            CourseList = new Dictionary<string, List<string>>();
        }

        public bool LoadCourses(string[] courses)
        {
            foreach (string courseItem in courses)
            {
                if (String.IsNullOrEmpty(courseItem))
                {
                    continue;
                }

                char[] delim = { ':' };
                string[] splitItem = courseItem.Split(delim, StringSplitOptions.RemoveEmptyEntries);
                string course = splitItem[0].Trim();
                string prereq = splitItem[1].Trim();

                if (String.IsNullOrEmpty(prereq))
                {
                    addPrereq(course);
                }
                else
                {
                    if (!addCourse(course, prereq))
                    {
                        CourseList.Clear();
                        return false;
                    }
                }
            }

            return true;
        }

        private bool addCourse(string course, string prereq)
        {
            if (prereq == course)
            {
                return false;
            }

            if (CourseList.ContainsKey(prereq))
            {
                CourseList[prereq].Add(course);
            }

            else if (CourseList.ContainsKey(course))
            {
                if (CourseList[course].Contains(prereq))
                {
                    return false;
                }

                CourseList[prereq] = CourseList[course];
                CourseList[prereq].Add(course);
                CourseList.Remove(course);
            }
            else
            {
                string key = findCourse(prereq);

                if (key == course)
                {
                    return false;
                }

                if (!String.IsNullOrEmpty(key))
                {
                    CourseList[key].Add(course);
                }
                else
                {
                    CourseList[prereq] = new List<string>();
                    CourseList[prereq].Add(course);
                }
            }

            return true;
        }

        private void addPrereq(string prereq)
        {
            if (!CourseList.ContainsKey(prereq))
            {
                CourseList[prereq] = new List<string>();
            }
        }

        private string findCourse(string course)
        {
            foreach (string key in CourseList.Keys)
            {
                if (CourseList[key].Contains(course))
                {
                    return key;
                }
            }

            return "";
        }

        public void PrintCourseList()
        {
            string output = String.Join(", ", CourseList.Keys);

            foreach (string key in CourseList.Keys)
            {
                for (int i = 0; i < CourseList[key].Count; i++)
                {
                    output += ", ";
                    output += CourseList[key][i];
                }
            }

            Console.WriteLine(output);
        }


    }
}
