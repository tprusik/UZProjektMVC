using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api.Models
{
   public class Person
    {

        public Person(string _name,string _sourname,int _telephoneNumber)
        {
            Name = _name;
            Sourname = _sourname;
            TelephoneNumber = _telephoneNumber;
            guid = Guid.NewGuid();
        }
     
        [Required]//wymagane pole
        [MinLength(2,ErrorMessage ="Imie nie składa się z dwóch liter")]
        [MaxLength(20,ErrorMessage ="Imie nie moze być dłuższe niż 20 liter")]
        [Display(Name = "Imię")]
        // [RegularExpression("")] dodaj regex
        public string Name { get; set; }

        [Display(Name ="Nazwisko")]
        public string Sourname { get; set; }

        [Display(Name = "Numer Telefonu")]  // nazwa wyswietlana 
        public int TelephoneNumber { get; set; }
        public Guid guid;

    }
}