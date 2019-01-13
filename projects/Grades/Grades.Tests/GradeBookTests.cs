using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(50);

            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.HighestGrade, 50);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(50);

            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(stats.LowestGrade, 10);
        }

        [TestMethod]
        public void ComputesAvarageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(81);
            book.AddGrade(91.5f); // incluir o f para considerar o numero como float e nao como double
            book.AddGrade(100);

            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(90.83,stats.AverageGrade, 0.01);
        }
    }
}
