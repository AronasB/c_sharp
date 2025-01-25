using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD3_22_1
{
    [Serializable]
    public class Project
    {
        private string name;
        private int duration;
        /// <summary>
        /// Construction with parameters
        /// </summary>
        /// <param name="name">project name</param>
        /// <param name="duration">project duration</param>
        public Project(string name, int duration)
        {
            this.name = name;
            this.duration = duration;
        }
        /// <summary>
        /// Returns project name
        /// </summary>
        /// <returns>project name</returns>
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Returns project duration
        /// </summary>
        /// <returns>project duration</returns>
        public int GetDuration()
        {
            return duration;
        }
        /// <summary>
        /// Gives all information to one strings
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Format("{0,-35} {1,5}", name, duration);
        }
    }
}