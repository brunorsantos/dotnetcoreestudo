using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
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
