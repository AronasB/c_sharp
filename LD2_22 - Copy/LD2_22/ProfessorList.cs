using System.Collections.Generic;

namespace LD2_22
{
    public sealed class ProfessorList
    {
        private ProfessorNode head;
        private ProfessorNode tail;
        private ProfessorNode d;
        /// <summary>
        /// Sets head and list to null
        /// </summary>
        public ProfessorList()
        {
            head = null;
            tail = null;
        }
        /// <summary>
        /// Adds new professor node in backwards
        /// </summary>
        /// <param name="professor1">Professor class</param>
        public void SetNode(Professor professor1)
        {
            head = new ProfessorNode(professor1, head);
        }
        /// <summary>
        /// Adds a new professor node in start of the list
        /// </summary>
        /// <param name="professor1">Professor class</param>
        public void SetNode2(Professor professor1)
        {
            var temp = new ProfessorNode(professor1, null);
            if (head != null)
            {
                tail.link = temp;
                tail = temp;
            }
            else
            {
                head = temp;
                tail = temp;
            }
        }
        /// <summary>
        /// Set node d to head
        /// </summary>
        public void Begin()
        {
            d = head;
        }
        /// <summary>
        /// Moves to next link
        /// </summary>
        public void Next()
        {
            d = d.link;
        }
        /// <summary>
        /// Checks if it's still excists
        /// </summary>
        /// <returns>true or false</returns>
        public bool Exist()
        {
            return d != null;
        }
        /// <summary>
        /// Returns professor
        /// </summary>
        /// <returns>Professor</returns>
        public Professor GetProfessor()
        {
            return d.data;
        }
        /// <summary>
        /// Checks if there is duplicates and then removes it
        /// </summary>
        public void RemoveDuplicates()
        {
            ProfessorNode current = head;

            while (current != null)
            {
                ProfessorNode previous = current;
                ProfessorNode runner = current.link;

                while (runner != null)
                {
                    if (current.data == runner.data)
                    {
                        current.data.AddProject(runner.data.GetProject());
                        previous.link = runner.link;
                        runner = runner.link;
                    }
                    else
                    {
                        previous = runner;
                        runner = runner.link;
                    }
                }
                current = current.link;
            }
        }
        /// <summary>
        /// Sorts professors by surname and name
        /// </summary>
        public void Sort()
        {
            for (ProfessorNode current = head; current != null;
                current = current.link)
            {
                ProfessorNode minv = current;

                for (ProfessorNode runner = current.link; runner != null;
                    runner = runner.link)
                {
                    if (runner.data < minv.data)
                    {
                        minv = runner;
                    }
                    Professor professor = minv.data;
                    minv.data = current.data;
                    current.data = professor;
                }
            }
        }
        /// <summary>
        /// Finds professors who have most projects
        /// </summary>
        /// <returns>string list</returns>
        public List<string> MostProjects()
        {
            int most = -1, temp;
            List<string> result = new List<string>();

            for (Begin(); Exist(); Next())
            {
                temp = d.data.GetProjectsCount();

                if (temp > most)
                {
                    most = temp;
                    result.Clear();
                    result.Add(d.data.ToString());
                }
                else if ( temp == most)
                {
                    result.Add(d.data.ToString());
                }
            }

            if (most > 0) 
            {
                result.Insert(0, "" + most);
            }
            return result;
        }
    }
}