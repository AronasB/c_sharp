using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LD2_22
{
    public partial class WebForm : System.Web.UI.Page
    {
        private StudentList studentList;
        private ProfessorList professorList;
        protected void Page_Load(object sender, EventArgs e)
        {
            string CData1 = Server.MapPath("App_Data/U22a1.txt");
            string CData2 = Server.MapPath("App_Data/U22b.txt");
            string CResults = Server.MapPath("App_Data/U22Rez.txt");

            studentList = InOutUtils.ReadStudents(CData1);
            professorList = InOutUtils.ReadProfessor(CData2);

            List<string> mostProjects;

            Label3.Text = "Įvesti studentų duomenys:";
            Label4.Text = "Įvesti dėstytojų duomenys:";
            Label5.Text = "Surikiuotas dėstytojų sąrašas";
            Label6.Text = "Sąrašas dėstytojų, kurių siūlomos temos buvo" +
                           " pasirinktos studentų";
            Label8.Text = "Daugiausiai projektinių darbų:";
            Label9.Text = "Įveskite dėstytojo vardą ir pavardę";

            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            ListBox4.Items.Clear();
            ListBox5.Items.Clear();
            ListBox6.Items.Clear();
            ListBox7.Items.Clear();

            ListBox6.Visible = false;

            if(File.Exists(CResults))
                File.Delete(CResults);

            PrintStudents(studentList);
            PrintFirstProfessor(professorList, ListBox2);

            InOutUtils.PrintStudents(CResults, studentList, "Įvesti studentų" +
                                                            " duomenys:");
            InOutUtils.PrintFirstProfessor(CResults, professorList, "Įvesti" +
                                                        " dėstytojų duomenys:");

            professorList.RemoveDuplicates();

            professorList.Sort();

            PrintProfessor(professorList, ListBox4);

            InOutUtils.PrintProfessor(CResults, professorList, "Surikiuotas" +
                                                            " dėstytojų sąrašas");

            professorList = TaskUtils.Selected(studentList, professorList);

            professorList.Sort();

            PrintProfessor(professorList, ListBox5);

            InOutUtils.PrintProfessor(CResults, professorList, "Sąrašas" +
                    " dėstytojų, kurių siūlomos temos buvo pasirinktos studentų");

            mostProjects = professorList.MostProjects();

            PrintMostProjects(mostProjects, ListBox7);

            InOutUtils.PrintMostProjects(CResults, mostProjects, "Daugiausiai" +
                                                           " projektinių darbų:");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string CResults = Server.MapPath("App_Data/U22Rez.txt");

            Professor professor = new Professor();
            List<Project> projectList = new List<Project>();

            Label7.Text = "Temų sąrašas:";

            ListBox6.Items.Clear();

            ListBox6.Visible = true;

            professor.Place(null, TextBox2.Text, TextBox1.Text);

            projectList = TaskUtils.FindProjects(professor, professorList);

            PrintProjects(projectList, ListBox6);

            InOutUtils.PrintProjects(CResults, projectList, "Temų sąrašas:");
        }
        /// <summary>
        /// Makes listbox of student information
        /// </summary>
        /// <param name="studentList">student list</param>
        private void PrintStudents(StudentList studentList)
        {
            if (studentList != null)
            {
                for (studentList.Begin(); studentList.Exist(); studentList.Next())
                {
                    Student student = studentList.GetStudent();
                    ListBox1.Items.Add(student.ToString());
                }
            }
            else
                ListBox1.Items.Add("Nėra duomenų");
        }
        /// <summary>
        /// Makes a listbox of professor information
        /// </summary>
        /// <param name="professorList">professor list</param>
        /// <param name="listBox">list box</param>
        private void PrintFirstProfessor(ProfessorList professorList,
                                         ListBox listBox)
        {
            if (professorList != null)
            {
                for (professorList.Begin(); professorList.Exist();
                     professorList.Next())
                {
                    Professor professor = professorList.GetProfessor();
                    listBox.Items.Add(professor.ToString(0));
                }
            }
            else
                listBox.Items.Add("Nėra duomenų");
        }
        /// <summary>
        /// Makes a listbox of professor information
        /// </summary>
        /// <param name="professorList">professor list</param>
        /// <param name="listBox">list box</param>
        private void PrintProfessor(ProfessorList professorList, ListBox listBox)
        {
            if (professorList != null)
            {
                for (professorList.Begin(); professorList.Exist();
                     professorList.Next())
                {
                    Professor professor = professorList.GetProfessor();
                    listBox.Items.Add(professor.ToString());
                }
            }
            else
                listBox.Items.Add("Nėra duomenų");
        }
        /// <summary>
        /// Makes a listbox of professors who have most projects
        /// </summary>
        /// <param name="mostProjects">most projects</param>
        /// <param name="listBox">list box</param>
        private void PrintMostProjects(List<string> mostProjects, ListBox listBox)
        {
            if (mostProjects.Count != 0)
            {
                foreach (string project in mostProjects)
                {
                    listBox.Items.Add(project);
                }
            }
            else
                listBox.Items.Add("Nėra");
        }
        /// <summary>
        /// Makes a listbox of projects
        /// </summary>
        /// <param name="projects">projects</param>
        /// <param name="listBox">list box</param>
        private void PrintProjects(List<Project> projects, ListBox listBox)
        {
            if (projects.Count != 0)
            {
                foreach (Project project in projects)
                {
                    listBox.Items.Add(project.ToString());
                }
            }
            else
                listBox.Items.Add("Nerasta");
        }
    }
}