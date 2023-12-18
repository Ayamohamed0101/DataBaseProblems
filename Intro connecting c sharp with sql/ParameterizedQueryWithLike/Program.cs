using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedQueryWithLike
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";

        //1- startwith ===> query + '' + @start with +'%'
        //2- contain ===>   query + '%' + @Contains + '%'
        //3- contain ===>   query + '%' + @EndsWith + ''


        static void SearchContactsStartsWith(string StartsWith)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = "Select * from Contacts Where FirstName like '' + @StartsWith + '%' ";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartsWith", StartsWith);

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

        static void SearchContactsEndsWith(string EndsWith)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "select * from Contacts where FirstName like '%' + @EndsWith + ''";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@EndsWith", EndsWith);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

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
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void SearchContactsContains(string Contains)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "select * from Contacts where FirstName like '%' + @Contains + '%'";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

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
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("--------Contacts Starts With 'j'");
            //SearchContactsStartsWith("j");

            Console.WriteLine("--------Contacts Ends With 'ne'");
            SearchContactsEndsWith("ne");


            Console.WriteLine("--------Contacts Contains 'ae'");
            SearchContactsContains("ae");
            Console.ReadLine();












        }
    }
}