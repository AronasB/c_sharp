using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2_22
{
    public sealed class StudentNode
    {
        /// <summary>
        /// Student class
        /// </summary>
        public Student data {  get; set; }
        /// <summary>
        /// Adresss
        /// </summary>
        public StudentNode link { get; set; }
        /// <summary>
        /// Saves adress and student class
        /// </summary>
        /// <param name="data">Student class</param>
        /// <param name="link">Adress</param>
        public StudentNode(Student data, StudentNode link)
        {
            this.data = data;
            this.link = link;
        }
    }
}