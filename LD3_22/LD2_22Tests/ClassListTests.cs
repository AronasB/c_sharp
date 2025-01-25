using Microsoft.VisualStudio.TestTools.UnitTesting;
using LD2_22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_22.Tests
{
    [TestClass()]
    public class ClassListTests
    {
        /// <summary>
        /// Tests if it creates a linked class
        /// </summary>
        [TestMethod()]
        public void ClassListTest()
        {
            var classList = new ClassList<string>();

            Assert.IsNotNull(classList);
        }
        /// <summary>
        /// Tests if it creates a node from backs
        /// </summary>
        [TestMethod()]
        public void SetNodeTest()
        {
            var classList = new ClassList<string>();

            classList.SetNode("Test");

            Assert.IsNotNull(classList.GetClass());
        }
        /// <summary>
        /// Tests if it creates a node from start
        /// </summary>
        [TestMethod()]
        public void SetNode2Test()
        {
            var classList = new ClassList<string>();

            classList.SetNode2("Test");

            Assert.IsNotNull(classList.GetClass());
        }
        /// <summary>
        /// Tests if it goes to first data
        /// </summary>
        [TestMethod()]
        public void BeginTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test");

            classList.Begin();

            Assert.AreEqual("Test", classList.GetClass());
        }
        /// <summary>
        /// Tests if it goes to next data
        /// </summary>
        [TestMethod()]
        public void NextTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test1");
            classList.SetNode("Test2");

            classList.Begin();
            classList.Next();

            Assert.AreEqual("Test2", classList.GetClass());
        }
        /// <summary>
        /// Tests if exist class check method works
        /// </summary>
        [TestMethod()]
        public void ExistTest()
        {
            var classList = new ClassList<string>();

            Assert.IsFalse(classList.Exist());

            classList.SetNode("Test");

            Assert.IsTrue(classList.Exist());
        }
        /// <summary>
        /// Tests if it brings class data
        /// </summary>
        [TestMethod()]
        public void GetClassTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test");

            var result = classList.GetClass();

            Assert.AreEqual("Test", result);
        }
        /// <summary>
        /// Tests if it removes dublicates
        /// </summary>
        [TestMethod()]
        public void RemoveDuplicatesTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test");
            classList.SetNode("Test");

            classList.RemoveDuplicates();

            var result = classList.GetClass();

            Assert.AreEqual("Test", result);
        }
        /// <summary>
        /// Tests if sort method works
        /// </summary>
        [TestMethod()]
        public void SortTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("C");
            classList.SetNode("B");
            classList.SetNode("A");

            classList.Sort();

            var expected = new List<string> { "A", "B", "C" };
            var actual = new List<string>(classList);
            CollectionAssert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Tests if most project method works
        /// </summary>
        [TestMethod()]
        public void MostProjectsTest()
        {
            var classList = new ClassList<Professor>();
            var professor1 = new Professor();
            var professor2 = new Professor();
            Project project1 = new Project("Project1", 1);
            professor1.AddProject(project1);
            Project project2 = new Project("Project2", 1);
            professor1.AddProject(project2);
            Project project3 = new Project("Project3", 1);
            professor2.AddProject(project3);
            classList.SetNode(professor1);
            classList.SetNode(professor2);

            var result = classList.MostProjects();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains("Professor: 2 projects"));
            Assert.IsTrue(result.Contains("Professor: 1 projects"));
        }
        /// <summary>
        /// Tests if enumerator works
        /// </summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test1");
            classList.SetNode("Test2");

            var enumerator = classList.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("Test1", enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("Test2", enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }
    }
}