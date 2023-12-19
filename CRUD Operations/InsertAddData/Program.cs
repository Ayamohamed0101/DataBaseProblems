using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertAddData
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


        static void AddNewContact(stContact newContact)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "insert into Contacts (FirstName,LastName,Email,Phone,Address,CountryID)" +
                "Values(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID)";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
            command.Parameters.AddWithValue("@LastName", newContact.LastName);
            command.Parameters.AddWithValue("@Email", newContact.Email);
            command.Parameters.AddWithValue("@Phone", newContact.Phone);
            command.Parameters.AddWithValue("@Address", newContact.Address);
            command.Parameters.AddWithValue("@CountryID", newContact.CountryID);

            try
            {

                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();//

                if (RowsAffected > 0) { Console.WriteLine("Record inserted Successfully"); }
                else { Console.WriteLine("Record insertion Faild!"); }
                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }


        static void Main(string[] args)
        {
            stContact contact = new stContact
            {
                FirstName = "Mddddddddddddohammed",
                LastName = "Abu-Hadhoud",
                Email = "m@example.com",
                Phone = "1234567890",
                Address = "123 Main Street",
                CountryID = 5,
            };

            AddNewContact(contact);

            Console.ReadLine();
        }

    }
}
