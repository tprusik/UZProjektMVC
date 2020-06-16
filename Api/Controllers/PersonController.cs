using Api.Models;
using Infrastructure.Commands;
using Infrastructure.DTO;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Api.Controllers
{
    [Authorize]
    
    public class PersonController : Controller
    {
        [HttpGet]
        public ActionResult CompleteAddress(CreateAddressCommand createAddress)
        {
            var personDTO = PersonService.Load(User.Identity.GetUserId());
            var addressDTO = PersonService.LoadAddress(personDTO.PersonID); 

            if(addressDTO!=null)
            {
                ViewBag.Message = "Już dodałeś adres czy chcesz go zaktualizować ?";
            }

            if (addressDTO == null && ModelState.IsValid)
            {

                PersonService.CompleteAddress(createAddress, personDTO.PersonID);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult DeletePerson()
        {
            PersonRepository.Delete(User.Identity.GetUserId());

            return View();
        }

        public ActionResult CreatePerson(CreatePersonCommand createPerson)
        {
            var person = PersonService.Load(User.Identity.GetUserId());

            if (person != null)
            {
                
                return RedirectToAction("Index", "Home");
            }

            if (person == null && ModelState.IsValid) 
            {
               PersonService.Create(createPerson, User.Identity.GetUserId());
               return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
           
        

        [HttpGet]
        public ActionResult ViewPerson()
        {
            ViewBag.Message = "ViewPerson";
            var person = PersonService.Load(User.Identity.GetUserId());
            return View(person);
        }

        [HttpGet]
        public ActionResult ViewAllPerson()
        {
            ViewBag.Message = "All Persons";

            var personList = PersonService.LoadAll();

            return View(personList);
        }

    }
}
