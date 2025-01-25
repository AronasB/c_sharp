using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD3_22_1
{
    [Serializable]
    public class Student : IComparable<Student>, IEquatable<Student>
    {
        private string projectName,
                       name,
                       surname,
                       group;
        /// <summary>
        /// Construction without parameters
        /// </summary>
        public Student()
        {
            projectName = string.Empty;
            name = string.Empty;
            surname = string.Empty;
            group = string.Empty;
        }
        /// <summary>
        /// Places given information in student class
        /// </summary>
        /// <param name="projectName">Project name</param>
        /// <param name="surname">Surname</param>
        /// <param name="name">Name</param>
        /// <param name="group">Group</param>
        public void Place(string projectName, string surname, string name,
                          string group)
        {
            this.projectName = projectName;
            this.surname = surname;
            this.name = name;
            this.group = group;
        }
        /// <summary>
        /// Gives Project name
        /// </summary>
        /// <returns>Project name</returns>
        public string GetProject()
        {
            return projectName;
        }
        /// <summary>
        /// Gives name
        /// </summary>
        /// <returns>Name</returns>
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Gives surname
        /// </summary>
        /// <returns>Surname</returns>
        public string GetSurname()
        {
            return surname;
        }
        /// <summary>
        /// Gives group name
        /// </summary>
        /// <returns>group</returns>
        public string GetGroup()
        {
            return group;
        }
        /// <summary>
        /// Returns combined information to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string text = string.Format("{0,-35} {1,-12} {2,-10} {3,-6}",
                                        projectName, surname, name, group);
            return text;
        }
        /// <summary>
        /// Compares two students
        /// </summary>
        /// <param name="other">other student</param>
        /// <returns>0 or 1</returns>
        public int CompareTo(Student other)
        {
            if ((object)other == null) return 1;
            if (surname.CompareTo(other.surname) != 0)
                return surname.CompareTo(other.surname);
            else
                return name.CompareTo(other.name);
        }
        /// <summary>
        /// Checks if they are the same
        /// </summary>
        /// <param name="obj">student</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Student studentObj = obj as Student;
            if (studentObj == null) return false;
            else
                return Equals(studentObj);
        }
        /// <summary>
        /// Cheks if name and surname are the same
        /// </summary>
        /// <param name="other">student</param>
        /// <returns>true or false</returns>
        public bool Equals(Student other)
        {
            if ((object)other == null) return false;
            if (this.name == other.name && this.surname == other.surname)
                return true;
            else
                return false;
        }
        /// <summary>
        /// returns name hashcode
        /// </summary>
        /// <returns>name hashcode</returns>
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }
}