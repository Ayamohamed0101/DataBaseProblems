using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSingleContact
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";

        static bool FindContactByID(int ContactID, ref stContact ContactInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "select * from Contacts where ContactID = @ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();//READER

                if (reader.Read())
                {
                    isFound = true;

                    ContactInfo.ID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];

                }
                else { isFound = false; }
                reader.Close();
                connection.Close();


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return isFound;
        }

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
        static void Main(string[] args)
        {
            stContact ContactInfo = new stContact();

            if (FindContactByID(1, ref ContactInfo))
            {
                Console.WriteLine($"\nContact ID: {ContactInfo.ID}");
                Console.WriteLine($"Name: {ContactInfo.FirstName}");
                Console.WriteLine($"Email: {ContactInfo.Email}");
                Console.WriteLine($"Phone: {ContactInfo.Phone}");
                Console.WriteLine($"Address: {ContactInfo.Address}");
                Console.WriteLine($"CountryID: {ContactInfo.CountryID}");

            }
            else
            {
                Console.WriteLine("Contact not Found");
            }

            Console.ReadLine();


        }
    }
}
