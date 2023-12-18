using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteScalar
{
    internal class Program
    {


        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";


        static string GetFirstName(int ContactID)
        {
            string FirstName = "";
            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "select FirstName from Contacts where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar(); //Retrieve a Single Value 
                if (result != null) { FirstName = result.ToString(); } else { FirstName = ""; }

                connection.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return FirstName;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetFirstName(1));
        }
    }


   



    }
