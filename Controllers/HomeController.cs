using System;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repo){
            this.repository = repo;
        }
        public ViewResult Index(){
            int hours = DateTime.Now.Hour;
            ViewBag.Greeting = hours < 12 ? "Good Morning": "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm(){
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse){
            if(ModelState.IsValid){
                repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }else{
                return View();
            }
        }
        public ViewResult ListResponses(){
            return View(repository.Responses.Where(r => r.WillAttend == true));
        }
        
    }
}