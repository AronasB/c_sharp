using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;

namespace LD2_22
{
    public static class InOutUtils
    {
        /// <summary>
        /// Reads data and saves students list
        /// </summary>
        /// <param name="fileName">file data path</param>
        /// <returns>students list</returns>
        public static StudentList ReadStudents(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            StudentList studentList = new StudentList();

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
        /// Reads data and saves professor list
        /// </summary>
        /// <param name="fileName">file data path</param>
        /// <returns>professor list</returns>
        public static ProfessorList ReadProfessor(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            ProfessorList professorList = new ProfessorList();

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
        /// Prints to text file students
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="studentList">students list</param>
        /// <param name="header"> header</param>
        public static void PrintStudents(string fileName, StudentList studentList,
                                         string header)
        {
            using (var fr = File.AppendText(fileName)) 
            {
                fr.WriteLine(header);
                fr.WriteLine();
                fr.WriteLine(string.Format("{0,-35} {1,-12} {2,-10} {3,-6}",
                                           "Tema", "Pavardė", "Vardas", "Grupė"));
                fr.WriteLine();
                if (studentList != null)
                {
                    for (studentList.Begin(); studentList.Exist();
                         studentList.Next())
                    {
                        fr.WriteLine(studentList.GetStudent().ToString());
                    }
                }
                else
                    fr.WriteLine("Nėra duomenų");

                fr.WriteLine();
            }
        }
        /// <summary>
        /// Prints to text file professors with full information
        /// </summary>
        /// <param name="fileName">file path</param>
        /// <param name="professorList">professor list</param>
        /// <param name="header">header</param>
        public static void PrintFirstProfessor(string fileName,
                                               ProfessorList professorList,
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
                        fr.WriteLine(professorList.GetProfessor().ToString(0));
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
        public static void PrintProfessor(string fileName,
                                          ProfessorList professorList,
                                          string header)
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
                    for (professorList.Begin(); professorList.Exist();
                         professorList.Next())
                    {
                        fr.WriteLine(professorList.GetProfessor().ToString());
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