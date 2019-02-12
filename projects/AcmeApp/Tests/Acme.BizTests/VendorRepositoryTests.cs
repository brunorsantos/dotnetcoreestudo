using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            var repository = new VendorRepository();
            var expected = 42;

            var actual = repository.RetrieveValue<int>("Select...", 42);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            var repository = new VendorRepository();
            var expected = "test";

            var actual = repository.RetrieveValue<string>("Select...", "test");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            var repository = new VendorRepository();
            var expected = new List<Vendor>();

            expected.Add(new Vendor()
            { VendorId = 1, CompanyName = "Test", Email = "teste@teste.com" });
            expected.Add(new Vendor()
            { VendorId = 2, CompanyName = "Test", Email = "teste1@teste.com" });

            var actual = repository.Retrieve();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
   
}