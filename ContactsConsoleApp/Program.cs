
using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsConsoleApp
{
    internal class Program
    {
        static void testFindContact(int ID)
        {
            clsContact Contact1 = clsContact.FindContactbyID(ID);

            if (Contact1 != null)
            {

                Console.WriteLine(Contact1.FirstName + " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else
            {

                Console.WriteLine("Contact [" + ID + "] Not Found!");
            }
        }
        static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();
            Contact1.FirstName = "Fajjjhjkhjkdi";
            Contact1.LastName = "Maher";
            Contact1.Email = "A@a.cjkjjghghom";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 3;
            Contact1.ImagePath = "";

            if (Contact1.save())
            {
                Console.WriteLine("Contact Added Successfully with Id=" + Contact1.ID);
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
        static void testUpdateContact(int ID)
        {

            clsContact Contact1 = clsContact.FindContactbyID(ID);
            Contact1.FirstName = "Lina";
            Contact1.LastName = "Maher";
            Contact1.Email = "A2jjkjkhkjhk@a.com";
            Contact1.Phone = "222kkkkkk2";
            Contact1.Address = "222";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.save())
            {
                Console.WriteLine("Contact Updated Successfuly");
            }
            else { Console.WriteLine("Contact with ID=" + ID + " not found!"); }

        }
        static void testDeleteContact(int ID)
        {
            if (ContactsBusinessLayer.clsContact.__DeleteContact(ID)  )
            {

                Console.WriteLine("DELETED SUCCESSFULLY");
            }
            else { Console.WriteLine("DELETE FAILED"); }

        }
        static void ListContacts()
        {

            DataTable dataTable = clsContact.GetAllContacts();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]}");

            }
        }


        static void Main(string[] args)
        {
            //testAddNewContact();
            //testFindContact(7);
            //testUpdateContact(5);
           // testDeleteContact(4);
            ListContacts(); 
            
        }
    }
}