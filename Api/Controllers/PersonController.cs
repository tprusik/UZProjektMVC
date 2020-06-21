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

        private readonly PersonService personService;

        public PersonController()
        {
            personService = new PersonService();
        }

        [HttpGet]
        public ActionResult CompleteAddress(CreateAddressCommand createAddress)
        {
            var personDTO = personService.Load(User.Identity.GetUserId());
            var addressDTO = personService.LoadAddress(personDTO.PersonID); 

            if(addressDTO!=null)
            {
                ViewBag.Message = "Już dodałeś adres czy chcesz go zaktualizować ?";
            }

            if (addressDTO == null && ModelState.IsValid)
            {

                personService.CompleteAddress(createAddress, personDTO.PersonID);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult DeletePerson()
        {
            personService.DeletePerson(User.Identity.GetUserId());

            return View();
        }

        public ActionResult CreatePerson(CreatePersonCommand createPerson)
        {
            var person = personService.Load(User.Identity.GetUserId());

            if (person != null)
            {
                
                return RedirectToAction("Index", "Home");
            }

            if (person == null && ModelState.IsValid) 
            {
               personService.Create(createPerson, User.Identity.GetUserId());
               return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
           
        

        [HttpGet]
        public ActionResult ViewPerson()
        {
            ViewBag.Message = "ViewPerson";
            var person = personService.Load(User.Identity.GetUserId());
            return View(person);
        }

        [HttpGet]
        public ActionResult ViewAllPerson()
        {
            ViewBag.Message = "All Persons";

            var personList = personService.LoadAll();

            return View(personList);
        }

    }
}
