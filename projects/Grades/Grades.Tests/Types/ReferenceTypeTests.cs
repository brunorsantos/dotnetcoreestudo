using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(81.9f, grades[1]);
        }


        private void AddGrades(float[] grades)
        {
            grades[1] = 81.9f;
        }

        [TestMethod]
        public void UppercaseString()       
        {
            string name = "name";
            name = name.ToUpper();

            Assert.AreEqual("NAME", name);

        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2018, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesByValue()
        {
            int x = 46;
            IncrementNumber(x);
            Assert.AreEqual(x, 46);
            
        }

        public void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("Novo Nome", book1.Name);
        }

        public void GiveBookAName(GradeBook book)
        {
            book.Name = "Novo Nome";
        }

        [TestMethod]
        public void StringComparison()
        {

            string name1 = "Oi";
            string name2 = "oi";

            bool result = String.Equals(name1, name2, System.StringComparison.InvariantCultureIgnoreCase);

        }

        [TestMethod]
        public void IntVariablesHoldsAValue()
        {
            int x1 = 100;
            int x2 = 1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);

        }
        [TestMethod]
        public void GradeBookVariablesHoldAreference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Scott's Book";

            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
