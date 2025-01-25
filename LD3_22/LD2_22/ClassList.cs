using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace LD2_22
{
    [Serializable]
    public sealed class ClassList<type>: IEnumerable<type>
        where type : IComparable<type>, IEquatable<type>
    {
        [Serializable]
        private sealed class ClassNode<type1>
            where type1 : IComparable<type>, IEquatable<type>
        {
            /// <summary>
            /// Class class
            /// </summary>
            public type1 data { get; set; }
            /// <summary>
            /// Adress
            /// </summary>
            public ClassNode<type1> link { get; set; }
            /// <summary>
            /// Saves adress and class
            /// </summary>
            /// <param name="data">class</param>
            /// <param name="link">Adress</param>
            public ClassNode(type1 data, ClassNode<type1> link)
            {
                this.data = data;
                this.link = link;
            }
        }
        //
        private ClassNode<type> head;
        private ClassNode<type> tail;
        private ClassNode<type> d;
        /// <summary>
        /// Sets head and list to null
        /// </summary>
        public ClassList()
        {
            head = null;
            tail = null;
        }
        /// <summary>
        /// Adds new Class node in backwards
        /// </summary>
        /// <param name="Class1">Class class</param>
        public void SetNode(type Class1)
        {
            head = new ClassNode<type>(Class1, head);
        }
        /// <summary>
        /// Adds a new Class node in start of the list
        /// </summary>
        /// <param name="Class1">Class class</param>
        public void SetNode2(type Class1)
        {
            var temp = new ClassNode<type>(Class1, null);
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
        /// Returns Class
        /// </summary>
        /// <returns>Class</returns>
        public type GetClass()
        {
            return d.data;
        }
        /// <summary>
        /// Checks if there is duplicates and then removes it
        /// </summary>
        public void RemoveDuplicates()
        {
            ClassNode<type> current = head;

            while (current != null)
            {
                ClassNode<type> previous = current;
                ClassNode<type> runner = current.link;

                while (runner != null)
                {
                    if (current.data.Equals(runner.data))
                    {
                        if (current.data is Professor Class1 && runner.data is
                            Professor Class2)
                        {
                            Class1.AddProject(Class2.GetProject());

                        }
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
        /// Sorts Classs by surname and name
        /// </summary>
        public void Sort()
        {
            for (ClassNode<type> current = head; current != null;
                current = current.link)
            {
                ClassNode<type> minv = current;

                for (ClassNode<type> runner = current.link; runner != null;
                    runner = runner.link)
                {
                    if (runner.data.CompareTo(minv.data) < 0)
                    {
                        minv = runner;
                    }
                    type Class = minv.data;
                    minv.data = current.data;
                    current.data = Class;
                }
            }
        }
        /// <summary>
        /// Finds Classs who have most projects
        /// </summary>
        /// <returns>string list</returns>
        public List<string> MostProjects()
        {
            int most = -1, temp;
            List<string> result = new List<string>();

            for (Begin(); Exist(); Next())
            {
                if(d.data is Professor Class1)
                {
                    temp = Class1.GetProjectsCount();

                    if (temp > most)
                    {
                        most = temp;
                        result.Clear();
                        result.Add(d.data.ToString());
                    }
                    else if (temp == most)
                    {
                        result.Add(d.data.ToString());
                    }
                }
            }

            if (most > 0) 
            {
                result.Insert(0, "" + most);
            }
            return result;
        }
        /// <summary>
        /// Enumerator which goes trough all class data
        /// </summary>
        /// <returns>data</returns>
        public IEnumerator<type> GetEnumerator()
        {
            for (ClassNode<type> dd = head; dd != null; dd = dd.link)
            {
                yield return dd.data;
            }
        }
        /// <summary>
        /// Not implimented
        /// </summary>
        /// <returns>NotImplementedException</returns>
        /// <exception cref="NotImplementedException">exception</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}