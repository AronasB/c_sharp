using LD3_22_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Xml.Linq;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests if it creates class list
        /// </summary>
        [TestMethod]
        public void ClassListTest()
        {
            var classList = new ClassList<string>();

            Assert.IsNotNull(classList);
        }
        /// <summary>
        /// Tests if it creates a node from backs
        /// </summary>
        [TestMethod]
        public void SetNodeTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test");

            classList.Begin();
            var result = classList.GetClass();

            Assert.AreEqual("Test", result);
        }
        /// <summary>
        /// Tests if it creates a node from start
        /// </summary>
        [TestMethod]
        public void SetNode2Test()
        {
            var classList = new ClassList<string>();
            classList.SetNode2("Test");

            classList.Begin();
            var result = classList.GetClass();

            Assert.AreEqual("Test", result);
        }
        /// <summary>
        /// Tests if it goes to first data
        /// </summary>
        [TestMethod]
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
        [TestMethod]
        public void NextTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode2("Test1");
            classList.SetNode2("Test2");

            classList.Begin();
            classList.Next();

            Assert.AreEqual("Test2", classList.GetClass());
        }
        /// <summary>
        /// Tests if exist class check method works
        /// </summary>
        [TestMethod]
        public void ExistTest()
        {
            var classList = new ClassList<string>();
            
            classList.Begin();

            Assert.IsFalse(classList.Exist());

            classList.SetNode("Test");
            
            classList.Begin();

            Assert.IsTrue(classList.Exist());
        }
        /// <summary>
        /// Tests if it brings class data
        /// </summary>
        [TestMethod]
        public void GetClassTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test");
            classList.Begin();

            var result = classList.GetClass();

            Assert.AreEqual("Test", result);
        }
        /// <summary>
        /// Tests if it removes dublicates
        /// </summary>
        [TestMethod]
        public void RemoveDuplicatesTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test");
            classList.SetNode("Test");

            classList.RemoveDuplicates();

            classList.Begin();
            var result = classList.GetClass();

            Assert.AreEqual("Test", result);
        }
        /// <summary>
        /// Tests if sort method works
        /// </summary>
        [TestMethod]
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
        [TestMethod]
        public void MostProjectsTest()
        {
            var classList = new ClassList<Professor>();
            var professor1 = new Professor();
            var professor2 = new Professor();
            Project project1 = new Project("Project1", 1);
            professor1.Place(project1, "Test1", "Test1");
            Project project2 = new Project("Project2", 1);
            professor1.AddProject(project2);
            Project project3 = new Project("Project3", 1);
            professor2.Place(project3, "Test2", "Test2");
            classList.SetNode(professor1);
            classList.SetNode(professor2);

            var result = classList.MostProjects();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(professor1.ToString()));
        }
        /// <summary>
        /// Tests if enumerator works
        /// </summary>
        [TestMethod]
        public void GetEnumeratorTest()
        {
            var classList = new ClassList<string>();
            classList.SetNode("Test1");
            classList.SetNode("Test2");

            var enumerator = classList.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("Test2", enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual("Test1", enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }
    }
}