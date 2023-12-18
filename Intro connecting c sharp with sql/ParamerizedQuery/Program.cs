using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParamerizedQuery
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";

        static void PrintAllContacts(string FirstName1)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = "select * from Contacts where FirstName=@FirstName1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName1", FirstName1);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    int ContactID = (int)Reader["ContactID"];
                    string FirstName = (string)Reader["FirstName"];
                    string LastName = (string)Reader["LastName"];
                    string Email = (string)Reader["Email"];
                    string Phone = (string)Reader["Phone"];
                    string Address = (string)Reader["Address"];
                    int CountryID = (int)Reader["CountryID"];

                    Console.WriteLine($"Contact ID: {ContactID}");
                    Console.WriteLine($"First Name: {FirstName}");
                    Console.WriteLine($"Last Name: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"Country ID: {CountryID}");
                    Console.WriteLine();

                }
                Reader.Close();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
        static void PrintAllContacts2parameter(string FirstName1,int CountryID1)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = "select * from Contacts where FirstName=@FirstName1 and countryID=@CountryID1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName1", FirstName1);
            Command.Parameters.AddWithValue("@CountryID1", @CountryID1);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    int ContactID = (int)Reader["ContactID"];
                    string FirstName = (string)Reader["FirstName"];
                    string LastName = (string)Reader["LastName"];
                    string Email = (string)Reader["Email"];
                    string Phone = (string)Reader["Phone"];
                    string Address = (string)Reader["Address"];
                    int CountryID = (int)Reader["CountryID"];

                    Console.WriteLine($"Contact ID: {ContactID}");
                    Console.WriteLine($"First Name: {FirstName}");
                    Console.WriteLine($"Last Name: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"Country ID: {CountryID}");
                    Console.WriteLine();

                }
                Reader.Close();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }

        static void Main(string[] args)
        {

          //  PrintAllContacts("jane");
            PrintAllContacts2parameter("Janee", 1);
            Console.ReadLine();


        }
    }
}
