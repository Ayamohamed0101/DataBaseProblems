
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode
        {
            Addnew=0,Update=1
        }
        public enMode Mode = enMode.Addnew;//WILL CHANGED INSIDE METHOD



        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string ImagePath { set; get; }
        public int CountryID { set; get; }

        // make 2 constructor
        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";
            this.Mode = enMode.Addnew;
        }
        //PRIVATE
        private clsContact(int ID, string FirstName, string LastName, string Email,
           string Phone, string Address, DateTime DateOfBirth, string ImagePath, int CountryID)
        {

            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            this.CountryID = CountryID;
            this.Mode = enMode.Update;
        }


        public static clsContact FindContactbyID(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (ContactsDataAccessLayer.ContactsDataAccess.GetContactInfoByID(
              ID, ref FirstName, ref LastName, ref Email,
                ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new clsContact(ID, FirstName, LastName,
                    Email, Phone, Address, DateOfBirth, ImagePath, CountryID);

            }

            else
            {
                return null;
            }


        }

        private bool __AddNewContact()
        {
            this.ID=ContactsDataAccess.AddNewContact(
                this.FirstName, this.LastName, this.Email, this.Phone,
               this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

              


            return this.ID != -1;
        }
     
        public bool __UpdateContact () 
        { 
       return ContactsDataAccess.UpdateContact(this. ID,this.FirstName, this.LastName, this.Email, this.Phone,
               this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);


        }

        public bool save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (__AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return (__UpdateContact());


            }
            return false;
        }


        public static bool __DeleteContact(int id)
        {
            return ContactsDataAccess.DeleteContact( id );

        }
        public static DataTable GetAllContacts()
        {
            return ContactsDataAccess.GetAllContacts();

        }


    }




}
