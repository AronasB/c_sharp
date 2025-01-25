namespace LD2_22
{
    public class Student
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
    }
}