using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD2_22
{
    public sealed class ProfessorNode
    {
        /// <summary>
        /// Professor class
        /// </summary>
        public Professor data {  get; set; }
        /// <summary>
        /// Adress
        /// </summary>
        public ProfessorNode link { get; set; }
        /// <summary>
        /// Saves adress and professor class
        /// </summary>
        /// <param name="data">Professor class</param>
        /// <param name="link">Adress</param>
        public ProfessorNode(Professor data, ProfessorNode link)
        {
            this.data = data;
            this.link = link;
        }
    }
}