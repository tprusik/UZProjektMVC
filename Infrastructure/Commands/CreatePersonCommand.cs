using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Commands
{
   public class CreatePersonCommand
    {
    
        [MinLength(2, ErrorMessage = "Imie musi być dłuższe niż dwie litery.")]
        [MaxLength(20, ErrorMessage = "Imie nie moze być dłuższe niż 20 liter")]
        [Display(Name = "Imię")]
        [RegularExpression("^([a-zA-Z]{2,20})", ErrorMessage = "Niepoprawny format - imie składa się tylko z liter")]
        public string Name { get;  set; }

        [MaxLength(20, ErrorMessage = "Nazwisko nie moze być dłuższe niż 20 liter")]
        [RegularExpression("^([a-zA-Z]{2,20})", ErrorMessage = "Niepoprawny format - nazwisko składa się tylko z liter")]
        [Display(Name = "Nazwisko")]
        public string Sourname { get;  set; }

        [RegularExpression(@"^(\d{9})$", ErrorMessage = "Numer telefonu składa się z 9 cyfr.")]
        [Display(Name = "Numer Telefonu")]
        public int TelephoneNumber { get; set; }
    }
}
