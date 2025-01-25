using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace LD2_22
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var professorList = new ClassList<Professor>();
            var studentList = new ClassList<Student>();
            
            try{
                studentList = GetData<ClassList<Student>>(studentList,
                                                          "App_Data/U22a.txt");
                professorList = GetData<ClassList<Professor>>(professorList,
                                                             "App_Data/U22b.txt");
            }
            catch(FileNotFoundException)
            {
                studentList = null;
                professorList = null;
            }

            Action(studentList, professorList);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string CResults = Server.MapPath("App_Data/U22Rez.txt");

            Professor professor = new Professor();
            List<Project> projectList = new List<Project>();

            Label7.Text = "Temų sąrašas:";


            professor.Place(null, TextBox2.Text, TextBox1.Text);

            var professorList = (ClassList<Professor>)Session["professor"];

            projectList = TaskUtils.FindProjects(professor, professorList);

            PrintProjects1(projectList, Table6);

            InOutUtils.PrintProjects(CResults, projectList, "Temų sąrašas:");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            var studentList = (ClassList<Student>)Session["student"];
            if (FileUpload1.HasFile && FileUpload1.FileName.EndsWith(".txt"))
            {
                studentList = InOutUtils.ReadStudents(FileUpload1.FileContent);

                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream(
                       Server.MapPath("App_Data/U22a.txt"), FileMode.Create))
                {
                    formatter.Serialize(fileStream, studentList);
                }
            }
            var professorList = (ClassList<Professor>)Session["professor"];
            if (FileUpload2.HasFile && FileUpload2.FileName.EndsWith(".txt"))
            {
                professorList = InOutUtils.ReadProfessor(FileUpload2.FileContent);
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream(
                       Server.MapPath("App_Data/U22b.txt"), FileMode.Create))
                {
                    formatter.Serialize(fileStream, professorList);
                }
            }
            Action(studentList, professorList);
        }
        /// <summary>
        /// Does certain methods and adds new information to tables 
        /// </summary>
        /// <param name="studentList">Student list</param>
        /// <param name="professorList">Professor list</param>
        private void Action(ClassList<Student> studentList,
                            ClassList<Professor> professorList)
        {
            string CResults = Server.MapPath("App_Data/U22Rez.txt");

            List<string> mostProjects;

            Label3.Text = "Įvesti studentų duomenys:";
            Label4.Text = "Įvesti dėstytojų duomenys:";
            Label5.Text = "Surikiuotas dėstytojų sąrašas";
            Label6.Text = "Sąrašas dėstytojų, kurių siūlomos temos buvo" +
                           " pasirinktos studentų";
            Label8.Text = "Daugiausiai projektinių darbų:";
            Label9.Text = "Įveskite dėstytojo vardą ir pavardę";

            Table1.Rows.Clear();
            Table2.Rows.Clear();
            Table3.Rows.Clear();
            Table4.Rows.Clear();
            Table5.Rows.Clear();
            Table6.Rows.Clear();

            Session["professor"] = professorList;
            Session["student"] = studentList;

            if (File.Exists(CResults))
                File.Delete(CResults);

            PrintData(studentList, Table1);
            PrintFirstProfessor1(professorList, Table2);

            InOutUtils.PrintData(CResults, studentList, "Įvesti studentų" +
                                                            " duomenys:");
            InOutUtils.PrintFirstProfessor(CResults, professorList, "Įvesti" +
                                                        " dėstytojų duomenys:");

            professorList.RemoveDuplicates();

            professorList.Sort();

            PrintData(professorList, Table3);

            InOutUtils.PrintData(CResults, professorList, "Surikiuotas" +
                                                            " dėstytojų sąrašas");

            professorList = TaskUtils.Selected(studentList, professorList);

            professorList.Sort();

            PrintData(professorList, Table4);


            InOutUtils.PrintData(CResults, professorList, "Sąrašas" +
                    " dėstytojų, kurių siūlomos temos buvo pasirinktos studentų");

            mostProjects = professorList.MostProjects();

            PrintMostProjects1(mostProjects, Table5);

            InOutUtils.PrintMostProjects(CResults, mostProjects, "Daugiausiai" +
                                                           " projektinių darbų:");

        }
        /// <summary>
        /// Creates a row
        /// </summary>
        /// <param name="name">given string</param>
        /// <returns>row</returns>
        private static TableRow CreateRow(string name)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            cell.Text = name;

            row.Cells.Add(cell);

            return row;
        }
        /// <summary>
        /// Makes a table of professor information
        /// </summary>
        /// <param name="professorList">professor list</param>
        /// <param name="listBox">list box</param>
        private void PrintFirstProfessor1(ClassList<Professor> professorList,
                                         Table tableName)
        {
            if (professorList != null)
            {
                for (professorList.Begin(); professorList.Exist();
                     professorList.Next())
                {
                    Professor professor = professorList.GetClass();
                    tableName.Rows.Add(CreateRow(professor.ToString(0)));
                }
            }
            else
                tableName.Rows.Add(CreateRow("Nėra duomenų"));
        }
        /// <summary>
        /// Makes a table for certain list information
        /// </summary>
        /// <param name="professorList">professor list</param>
        /// <param name="listBox">list box</param>
        private static void PrintData<type>(IEnumerable<type> professorList,
                                            Table tableName)
            where type: IComparable<type>, IEquatable<type>
        {
            if (professorList != null)
            {
                foreach (type professor in professorList)
                {
                    tableName.Rows.Add(CreateRow(professor.ToString()));
                }
            }
            else
                tableName.Rows.Add(CreateRow("Nėra duomenų"));
        }
        /// <summary>
        /// Makes a listbox of professors who have most projects
        /// </summary>
        /// <param name="mostProjects">most projects</param>
        /// <param name="listBox">list box</param>
        private void PrintMostProjects1(List<string> mostProjects,
                                        Table tableName)
        {
            if (mostProjects.Count != 0)
            {
                foreach (string project in mostProjects)
                {
                    tableName.Rows.Add(CreateRow(project));
                }
            }
            else
                tableName.Rows.Add(CreateRow("Nėra"));
        }
        /// <summary>
        /// Makes a listbox of projects
        /// </summary>
        /// <param name="projects">projects</param>
        /// <param name="listBox">list box</param>
        private void PrintProjects1(List<Project> projects, Table tableName)
        {
            if (projects.Count != 0)
            {
                foreach (Project project in projects)
                {
                    tableName.Rows.Add(CreateRow(project.ToString()));
                }
            }
            else
                tableName.Rows.Add(CreateRow("Nerasta"));
        }
        /// <summary>
        /// Gets from file data
        /// </summary>
        /// <typeparam name="type">List type</typeparam>
        /// <param name="classList">Class list</param>
        /// <param name="filePath">File path</param>
        /// <returns>class List</returns>
        private type GetData<type>(type classList, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(Server.MapPath(filePath)
                   , FileMode.Open, FileAccess.Read))
            {
                classList = (type)formatter.Deserialize(fileStream);
            }
            return classList;
        }
    }
}