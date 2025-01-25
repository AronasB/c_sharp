using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace LD2_22
{
    public static class InOutUtils
    {
        /// <summary>
        /// Reads data and saves students list
        /// </summary>
        /// <param name="fileName">file data path</param>
        /// <returns>students list</returns>
        public static ClassList<Student> ReadStudents(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            ClassList<Student> studentList = new ClassList<Student>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string project, surname, name, group;

                project = parts[0].Trim();
                surname = parts[1].Trim();
                name = parts[2].Trim();
                group = parts[3].Trim();

                Student student = new Student();

                student.Place(project, surname, name, group);

                studentList.SetNode(student);
            }

            return studentList;
        }
        /// <summary>
        /// Reads data and saves students list
        /// </summary>
        /// <param name="fileName">file data path</param>
        /// <returns>students list</returns>
        public static ClassList<Student> ReadStudents(Stream fin)
        {
            string line = null;

            ClassList<Student> studentList = new ClassList<Student>();

            using (StreamReader reader = new StreamReader(fin))
            {
                while((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string project, surname, name, group;

                    project = parts[0].Trim();
                    surname = parts[1].Trim();
                    name = parts[2].Trim();
                    group = parts[3].Trim();

                    Student student = new Student();

                    student.Place(project, surname, name, group);

                    studentList.SetNode(student);
                }
            }
            return studentList;
        }
        /// <summary>
        /// Reads data and saves professor list
        /// </summary>
        /// <param name="fileName">file data path</param>
        /// <returns>professor list</returns>
        public static ClassList<Professor> ReadProfessor(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            ClassList<Professor> professorList = new ClassList<Professor>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                string surname, name, projectName;
                int hours;
                Project project;

                projectName = parts[0].Trim();
                surname = parts[1].Trim();
                name = parts[2].Trim();
                hours = int.Parse(parts[3]);

                project = new Project(projectName, hours);

                Professor professor = new Professor();

                professor.Place(project, surname, name);

                professorList.SetNode(professor);
            }

            return professorList;
        }
        /// <summary>
        /// Reads data and saves students list
        /// </summary>
        /// <param name="fileName">file data path</param>
        /// <returns>students list</returns>
        public static ClassList<Professor> ReadProfessor(Stream fin)
        {
            string line = null;

            ClassList<Professor> professorList = new ClassList<Professor>();

            using (StreamReader reader = new StreamReader(fin))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string surname, name, projectName;
                    int hours;
                    Project project;

                    projectName = parts[0].Trim();
                    surname = parts[1].Trim();
                    name = parts[2].Trim();
                    hours = int.Parse(parts[3]);

                    project = new Project(projectName, hours);

                    Professor professor = new Professor();

                    professor.Place(project, surname, name);

                    professorList.SetNode(professor);
                }
            }
            return professorList;
        }
        /// <summary>
        /// Prints to text file professors with full information
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="professorList">professor list</param>
        /// <param name="header">header</param>
        public static void PrintFirstProfessor(string fileName,
                                               ClassList<Professor> professorList,
                                               string header)
        {
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(header);
                fr.WriteLine();
                fr.WriteLine(string.Format("{0,-12} {1,-10}  {2, -80}", "Pavardė",
                                           "Vardas", "Temos ir val. skaičius"));
                fr.WriteLine();
                
                if (professorList != null)
                {
                    for (professorList.Begin(); professorList.Exist();
                         professorList.Next())
                    {
                        fr.WriteLine(professorList.GetClass().ToString(0));
                    }
                }
                else
                    fr.WriteLine("Nėra duomenų");
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Prints professor name and surname to text file
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="professorList">professor list</param>
        /// <param name="header">header</param>
        public static void PrintData<type>(string fileName,
                                          IEnumerable<type> professorList,
                                          string header) 
            where type: IComparable<type>, IEquatable<type>
        {
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(header);
                fr.WriteLine();
                fr.WriteLine(string.Format("{0,-12} {1,-10}", "Pavardė",
                                           "Vardas"));
                fr.WriteLine();

                if (professorList != null)
                {
                    foreach (type data in professorList)
                    {
                        fr.WriteLine(data.ToString());
                    }
                }
                else
                    fr.WriteLine("Nėra duomenų");
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Prints professors with most projects to text file
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="mostProjects">projects</param>
        /// <param name="header">header</param>
        public static void PrintMostProjects(string fileName,
                                             List<string> mostProjects,
                                             string header)
        {
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(header);
                if (mostProjects.Count != 0)
                {
                    foreach (string project in mostProjects)
                    {
                        fr.WriteLine(project);
                    }
                }
                else
                    fr.WriteLine("Nėra");
            }
        }
        /// <summary>
        /// Prints projects to text file
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="projects">projects</param>
        /// <param name="header">header</param>
        public static void PrintProjects(string fileName, List<Project> projects,
                                         string header)
        {
            using (var fr = File.AppendText(fileName))
            {
                fr.WriteLine(header);
                if (projects.Count != 0)
                {
                    foreach (Project project in projects)
                    {
                        fr.WriteLine(project.ToString());
                    }
                }
                else
                    fr.WriteLine("Nerasta");
            }
        }
    }
}