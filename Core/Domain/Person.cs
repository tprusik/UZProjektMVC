using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Person 
    {
        public Person(string _name, string _sourname, int _telephoneNumber,string _userID)
        {
            SetName(_name);
            SetSourname(_sourname);
            SetTelephoneNumber(_telephoneNumber);
            PersonID = Guid.NewGuid().ToString();
            UserID = _userID;
        }

        public Person(string _name, string _sourname, int _telephoneNumber,string _personID, string _userID)
        {
            SetName(_name);
            SetSourname(_sourname);
            SetTelephoneNumber(_telephoneNumber);
            SetPersonID(_personID);
            SetUserID(_userID);
        }

        private void SetName(string name)
        {

            Name = name;
        }

        private void SetSourname(string sourname)
        {
            Sourname = sourname;
        }
        private void SetTelephoneNumber(int telephoneNumber)
        {
            if (double.IsNaN(telephoneNumber))
            {
                throw new Exception("Longitude must be a number.");
            }

            TelephoneNumber = telephoneNumber;
        }

        private void SetUserID(string userID)
        {
            if (UserID == userID)
                return;
            UserID = userID;
        }

        private void SetPersonID(string personID)
        {
            if (PersonID == personID)
                return;
            PersonID = personID;
        }

        public string Name { get; set; }

        public string Sourname { get; set; }

        public int TelephoneNumber { get; set; }

        public string PersonID;

        public string UserID;
    }
}
