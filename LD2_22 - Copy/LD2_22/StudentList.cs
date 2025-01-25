using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2_22
{
    public sealed class StudentList
    {
        private StudentNode head;
        private StudentNode tail;
        private StudentNode d;
        /// <summary>
        /// Sets head and list to null
        /// </summary>
        public StudentList()
        {
            head = null;
            tail = null;
        }
        /// <summary>
        /// Adds new student node in backwards
        /// </summary>
        /// <param name="Student1">Student class</param>
        public void SetNode(Student Student1)
        {
            head = new StudentNode(Student1, head);
        }
        /// <summary>
        /// Adds a new student node in start of the list
        /// </summary>
        /// <param name="Student1">Student class</param>
        public void SetNode2(Student Student1)
        {
            var temp = new StudentNode(Student1, null);
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
        /// Returns student class
        /// </summary>
        /// <returns>Student</returns>
        public Student GetStudent()
        {
            return d.data; 
        }
    }
}