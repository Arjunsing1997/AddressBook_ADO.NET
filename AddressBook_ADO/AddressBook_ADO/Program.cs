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
            Program Employee = new Program();
            Console.WriteLine("Welcome To Address Book Ado .NET");
            Employee.Menu();
            Console.ReadLine();
        }

        public void Menu()
        {
            AddressBookRepository repo = new AddressBookRepository();
            Console.WriteLine("Enter Your Choice:");
            Console.WriteLine("1)Display all Employee Details\n" +
                               "2)Add Details\n" +
                               "3)Edit\n" +
                               "4)Delete" +
                               "5)search by City ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    repo.GetAllEmployee();  //Retrieving Data from DataBase
                    break;
                case 2:
                    repo.AddNewdetails();   //Inserting values into the Table
                    break;

                case 3:
                    repo.EditDetails();
                    break;
                case 4:
                    repo.DeleteContacts();
                    break;
                case 5:
                    repo.RetrieveByCity();
                    break;
                default :
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
