using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2_22
{
    public static class TaskUtils
    {
        /// <summary>
        /// Finds all professors who projects where choosed by students
        /// </summary>
        /// <param name="studentList">Students list</param>
        /// <param name="professorList">Professors list</param>
        /// <returns>Professors list</returns>
        public static ProfessorList Selected(StudentList studentList,
                                             ProfessorList professorList)
        {
            ProfessorList professorList1 = new ProfessorList();
            for (professorList.Begin(); professorList.Exist();
                     professorList.Next())
            {
                for (studentList.Begin(); studentList.Exist(); studentList.Next())
                {
                    if(studentList.GetStudent() == professorList.GetProfessor())
                    {
                        professorList1.SetNode2(professorList.GetProfessor());
                        break;
                    }
                }
            }
            return professorList1;
        }
        /// <summary>
        /// Saves all projects associated with professor
        /// </summary>
        /// <param name="professor">Professor class</param>
        /// <param name="professorList">Professor list</param>
        /// <returns>projects</returns>
        public static List<Project> FindProjects(Professor professor,
                                                 ProfessorList professorList)
        {
            List<Project> projects = new List<Project>();

            for (professorList.Begin(); professorList.Exist();
                 professorList.Next())
            {
                Professor professor1 = professorList.GetProfessor();
                if(professor == professor1)
                {
                    for(int i = 0; i < professor1.GetProjectsCount(); i++)
                    {
                        projects.Add(professor1.GetProject(i));
                    }
                }
            }

            return projects;
        }
    }
}