
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public class ContactsDataAccess
    {

        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName, ref string Email,
     ref string Phone, ref string Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select * from contacts where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {

                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    CountryID = (int)Reader["CountryID"];

                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else { ImagePath = ""; }
                }
                else { IsFound = false; }
                Reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static int AddNewContact(string FirstName, string LastName, string Email,
    string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"insert into Contacts (FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath)
       values (@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath);
              select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();

                object result = Command.ExecuteScalar();// return single value

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {

                    return InsertedID;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return -1;

        }


        public static bool UpdateContact(
            int ID, string FirstName, string LastName, string Email,
            string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {


            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Contacts set FirstName=@FirstName,LastName=@LastName,
                          Email=@Email,Phone=@Phone,Address=@Address,DateOfBirth=@DateOfBirth,
                          CountryID=@CountryID,ImagePath=@ImagePath
                        where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {

                Connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { return false; }
            finally { Connection.Close(); }


            return (RowsAffected > 0);

        }



        public static bool DeleteContact(int ContactID)
        {

            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"delete Contacts where ContactID=@ContactID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return (RowsAffected > 0);
        }


        public static DataTable GetAllContacts()
        {

            DataTable dataTable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select * from Contacts";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
                Connection.Close();
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dataTable;
        }



    }
}
