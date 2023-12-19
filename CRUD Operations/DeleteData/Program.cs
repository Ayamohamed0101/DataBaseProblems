using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteData
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


        static void DeleteContact(int ContactID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = @"Delete from Contacts Where ContactID=@ContactID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine($"Deleted Successfully");
                }
                else { Console.WriteLine("Delete Failed!"); }

                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
        static void DeleteContacts(string ContactsID)
        {

            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = @"Delete from Contacts Where ContactID in(" + ContactsID + ")";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactsID);

            try
            {

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine($"Deleted Successfully");
                }
                else { Console.WriteLine("Delete Failed!"); }

                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }


        static void Main(string[] args)
        {
           // DeleteContact(10);
            DeleteContacts("3,5,6");

            Console.ReadLine();

        }
    }
    }
