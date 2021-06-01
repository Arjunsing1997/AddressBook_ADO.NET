using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AddressBook_ADO;
namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Addresses the book return true.
        /// </summary>
        [TestMethod]
        public void AddressBook_Return_TRUE()
        {
            AddressBookRepository addressBook = new AddressBookRepository();
            bool Actual = addressBook.GetAllEmployee();
            bool Exp = true;

            Assert.AreEqual(Exp, Actual);

        }

        /// <summary>
        /// Adds the newdetails.
        /// </summary>
        [TestMethod]
        public void AddNewdetails()
        {
            AddressBookRepository addressBook = new AddressBookRepository();
            bool Actual = addressBook.AddNewdetails();
            bool Exp = true;

            Assert.AreEqual(Exp, Actual);

        }

        /// <summary>
        /// Edits the details.
        /// </summary>
        [TestMethod]
        public void EditDetails()
        {
            AddressBookRepository addressBook = new AddressBookRepository();
            bool Actual = addressBook.EditDetails();
            bool Exp = true;

            Assert.AreEqual(Exp, Actual);

        }
    }
}
