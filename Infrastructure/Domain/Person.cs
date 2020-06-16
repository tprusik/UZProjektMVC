using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Domain
{
    public class Person
    {
        public Person(string _name, string _sourname, int _telephoneNumber,string _userID)
        {
            Name = _name;
            Sourname = _sourname;
            TelephoneNumber = _telephoneNumber;
            PersonID = Guid.NewGuid().ToString();
            UserID = _userID;
        }

        public string Name { get; set; }

        public string Sourname { get; set; }

        public int TelephoneNumber { get; set; }

        public string PersonID;

        public string UserID;

    }
}
