using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AddressBook_ADO;
namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddressBook_Return_TRUE()
        {
            AddressBookRepository addressBook = new AddressBookRepository();
            bool Actual = addressBook.GetAllEmployee();
            bool Exp = true;

            Assert.AreEqual(Exp, Actual);

        }

        [TestMethod]
        public void AddNewdetails()
        {
            AddressBookRepository addressBook = new AddressBookRepository();
            bool Actual = addressBook.AddNewdetails();
            bool Exp = true;

            Assert.AreEqual(Exp, Actual);

        }
    }
}
