using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveAutoNumafterInserting
{
    internal class Program
    {

        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";



        public struct stContact
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }


        static void UpdateContact(int ContactID, stContact newContact)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"Update Contacts set
                      FirstName=@FirstName,
                      LastName=@LastName,
                      Email=@Email,
                      Phone=@Phone,
                      Address=@Address,
                      CountryID=@CountryID
                   Where ContactID=@ContactID";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
            command.Parameters.AddWithValue("@LastName", newContact.LastName);
            command.Parameters.AddWithValue("@Email", newContact.Email);
            command.Parameters.AddWithValue("@Phone", newContact.Phone);
            command.Parameters.AddWithValue("@Address", newContact.Address);
            command.Parameters.AddWithValue("@CountryID", newContact.CountryID);
            command.Parameters.AddWithValue("@ContactID", ContactID);


            try
            {

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine($"Updated Successfully");
                }
                else { Console.WriteLine("Update Failed!"); }



                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }


        static void Main(string[] args)
        {
            stContact contact = new stContact
            {
                FirstName = "LaJLKLKKila",
                LastName = "MahDDDDDDDDer",
                Email = "m@example.com",
                Phone = "1234567890",
                Address = "123 Main Street",
                CountryID = 1,
            }; 

           UpdateContact(4, contact);
            Console.ReadLine();

        }
    }
}
