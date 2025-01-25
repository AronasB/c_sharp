using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD3_22_1
{
    [Serializable]
    public class Professor : IComparable<Professor>, IEquatable<Professor>
    {
        private string surname,
                       name;
        private List<Project> projects;
        /// <summary>
        /// Construction without parameters
        /// </summary>
        public Professor()
        {
            projects = new List<Project>();
            surname = string.Empty;
            name = string.Empty;
        }
        /// <summary>
        /// Places information to professor class
        /// </summary>
        /// <param name="project1">project</param>
        /// <param name="surname">surname</param>
        /// <param name="name">name</param>
        public void Place(Project project1, string surname, string name)
        {
            projects.Add(project1);
            this.surname = surname;
            this.name = name;
        }
        /// <summary>
        /// Adds project
        /// </summary>
        /// <param name="project1">project</param>
        public void AddProject(Project project1)
        {
            projects.Add(project1);
        }
        /// <summary>
        /// Gives first project
        /// </summary>
        /// <returns>project</returns>
        public Project GetProject()
        {
            return projects[0];
        }
        /// <summary>
        /// Returns specific project
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>project</returns>
        public Project GetProject(int i)
        {
            return projects[i];
        }
        /// <summary>
        /// Returns project count
        /// </summary>
        /// <returns>project count</returns>
        public int GetProjectsCount()
        {
            return projects.Count;
        }
        /// <summary>
        /// Returns hascode
        /// </summary>
        /// <returns>hashcode</returns>
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
        /// <summary>
        /// Checks if it is equal
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Professor professorObj = obj as Professor;
            if (professorObj == null) return false;
            else
                return Equals(professorObj);
        }
        /// <summary>
        /// Gives professor information in string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string text = string.Format(" {0,-12} {1,-10} ", surname, name);
            return text;
        }
        /// <summary>
        /// Adds all projects to one string
        /// </summary>
        /// <returns>string</returns>
        public string Projects()
        {
            string text = string.Empty;

            for (int i = 0; i < projects.Count; i++)
            {
                text += projects[i].ToString() + " ";
            }

            return text;
        }
        /// <summary>
        /// Gives all professor information to string
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>string</returns>
        public string ToString(int i)
        {
            string text = string.Format(" {0,-12} {1,-10} {2}", surname, name,
                                        Projects());
            return text;
        }
        /// <summary>
        /// Compares to professors
        /// </summary>
        /// <param name="other">professor</param>
        /// <returns>number</returns>
        public int CompareTo(Professor other)
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
        /// <param name="other">professor</param>
        /// <returns>true or false</returns>
        public bool Equals(Professor other)
        {
            if ((object)other == null) return false;
            if (this.name == other.name && this.surname == other.surname)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if both professors name and surname are same
        /// </summary>
        /// <param name="professor1">Professor class</param>
        /// <param name="professor2">Professor class</param>
        /// <returns>true or flase</returns>
        public static bool operator ==(Professor professor1, Professor professor2)
        {
            if (((object)professor1) == null || ((object)professor2) == null)
                return Object.Equals(professor1, professor2);
            return professor1.Equals(professor2);
        }
        /// <summary>
        /// Checks if both professors name and surname are not same
        /// </summary>
        /// <param name="professor1">Professor class</param>
        /// <param name="professor2">Professor class</param>
        /// <returns>true or flase</returns>
        public static bool operator !=(Professor professor1, Professor professor2)
        {
            return string.Compare(professor1.surname, professor2.surname) != 0 &&
                   string.Compare(professor1.name, professor2.name) != 0;
        }
        /// <summary>
        /// Checks which ones surname or name is higher
        /// </summary>
        /// <param name="professor1">Professor class</param>
        /// <param name="professor2">Professor class</param>
        /// <returns>true or flase</returns>
        public static bool operator >(Professor professor1, Professor professor2)
        {
            int position1 = string.Compare(professor1.surname, professor2.surname)
                , position2 = string.Compare(professor1.name, professor2.name);
            return position1 > 0 || (position1 == 0 && position2 > 0);
        }
        /// <summary>
        /// Checks which ones surname or name is lower
        /// </summary>
        /// <param name="professor1">Professor class</param>
        /// <param name="professor2">Professor class</param>
        /// <returns>true or flase</returns>
        public static bool operator <(Professor professor1, Professor professor2)
        {
            int position1 = string.Compare(professor1.surname, professor2.surname)
                , position2 = string.Compare(professor1.name, professor2.name);
            return position1 < 0 || (position1 == 0 && position2 < 0);
        }
        /// <summary>
        /// Checks if project names are the same
        /// </summary>
        /// <param name="student1">Student class</param>
        /// <param name="professor1">Professor class</param>
        /// <returns></returns>
        public static bool operator ==(Student student1, Professor professor1)
        {
            int position;
            for (int i = 0; i < professor1.projects.Count; i++)
            {
                position = string.Compare(student1.GetProject(),
                                          professor1.projects[i].GetName());

                if (position == 0)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if project names are not the same
        /// </summary>
        /// <param name="student1">Student class</param>
        /// <param name="professor1">Professor class</param>
        /// <returns></returns>
        public static bool operator !=(Student student1, Professor professor1)
        {
            return !(student1 == professor1);
        }
    }
}