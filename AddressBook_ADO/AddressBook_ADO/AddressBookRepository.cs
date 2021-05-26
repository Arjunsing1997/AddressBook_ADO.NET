using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AddressBook_ADO
{
    public class AddressBookRepository
    {
        public static string ConnectionString = "Data Source=DESKTOP-CL8506B;Initial Catalog=Address_Book_SQL;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);
        public bool GetAllEmployee()
        {
            try
            {

                AddressBookModel model = new AddressBookModel();
                connection.Open();
                using (connection)
                {
                    string query = @"SELECT * FROM Address_Book";



                    SqlCommand cmd = new SqlCommand(query, this.connection);



                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("FirstName\tLastName\tCity\tState\tZip\tPhone\tEmail");
                        while (dr.Read())
                        {
                            model.FirstName = dr.GetString(0);
                            model.LastName = dr.GetString(1);
                            model.City = dr.GetString(2);
                            model.StateName = dr.GetString(3);
                            model.Zip = dr.GetInt32(4);
                            model.Phone = dr.GetString(5);
                            model.Email = dr.GetString(6);

                            //Display Retrieve Data
                            Console.WriteLine("{0}\t\t,{1}\t\t,{2}\t,{3}\t,{4}\t,{5}", model.FirstName, model.LastName, model.City, model.StateName, model.Zip, model.Phone, model.Email);
                            //Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data Found");
                    }
                    //Closing SQL reader
                    dr.Close();

                    //Closing SQL Connection
                    connection.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
