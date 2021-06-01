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
        public static SqlConnection ConnectionString()
        {
            string ConnectionString = "Data Source=DESKTOP-CL8506B;Initial Catalog=Address_Book_SQL;Integrated Security=True";
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
       
        public bool GetAllEmployee()
        {

            try
            {
                SqlConnection connection = ConnectionString();

                AddressBookModel model = new AddressBookModel();
                connection.Open();
                using (connection)
                {
                    string query = @"SELECT * FROM Address_Book";
                    SqlCommand cmd = new SqlCommand(query, connection);
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

        public bool AddNewdetails()
        {
            try
            {
                SqlConnection connection = ConnectionString();

                AddressBookModel model = new AddressBookModel();
                connection.Open();
                using (connection)
                {
                    string query = @"INSERT INTO Address_Book VALUES('Ram','Ramesh','Bengaluru','Karnataka','560099','845784','ramraj@gmail.com');";
                    SqlCommand cmd = new SqlCommand(query, connection);
                   int  result = cmd.ExecuteNonQuery();        //ExecuteNonQuery is to modify the the Date base Data and Returns Integer Value
                    if(result != 0)
                    {
                        return true;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EditDetails()
        {
            SqlConnection connection = ConnectionString();
            try
            {
                string query = @"update Address_Book set City = 'Nizamabad' , StateName = 'Hyderabad' where FirstName = 'Arjun';";
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    int result = command.ExecuteNonQuery();  //ExecuteNonQuery is to modify the the Date base Data and Returns Integer Value
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteContacts()
        {
            SqlConnection connection = ConnectionString();
            try
            {
                string query = @"DELETE FROM Address_Book WHERE FirstName = 'Ram';";
                bool returnValue = ExecuteQuery(query, connection);
                Console.WriteLine("Row Deleted  Successfully....");
                return returnValue;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool RetrieveByCity()
        {
            SqlConnection connection = ConnectionString();
            AddressBookModel model = new AddressBookModel();
            try
            {
                
                string query = @"Select * from Address_Book Where City = 'Bengaluru';";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                using (connection)
                {
                    if (dr.HasRows)
                    {
                        Console.WriteLine("FirstName\tCity");
                        while (dr.Read())
                        {
                            model.FirstName = dr.GetString(0);
                            model.City = dr.GetString(2);

                            //Display Retrieve Data
                            Console.WriteLine("{0}\t\t{1}", model.FirstName, model.City);
                            //Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data Not Found");
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool ExecuteQuery(string query, SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int result = command.ExecuteNonQuery();  //ExecuteNonQuery is to modify the the Date base Data and Returns Integer Value
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
