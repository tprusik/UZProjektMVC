using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Commands
{
   public class CreatePersonCommand
    {
        [Required]
        [MinLength(2, ErrorMessage = "Imie nie składa się z dwóch liter")]
        [MaxLength(20, ErrorMessage = "Imie nie moze być dłuższe niż 20 liter")]
        [Display(Name = "Imię")]
        // [RegularExpression("")] dodać regex
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Nazwisko nie moze być dłuższe niż 20 liter")]
        [Display(Name = "Nazwisko")]
        public string Sourname { get; set; }

        [Display(Name = "Numer Telefonu")]
        public int TelephoneNumber { get; set; }
    }
}
