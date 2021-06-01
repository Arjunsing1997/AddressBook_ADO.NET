using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Ado .NET");
            AddressBookRepository repo = new AddressBookRepository();
            repo.GetAllEmployee();  //Retrieving Data from DataBase
            repo.AddNewdetails();   //Inserting values into the Table

            Console.ReadLine();
        }
    }
}
