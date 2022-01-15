using ContellectTask_MahamedMamdouh.Models;
using ContellectTask_MahamedMamdouh.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContellectTask_MahamedMamdouh.Controllers
{
    public class ContactsController : Controller
    {


        private readonly IContactsRepository ContactsRepository;

        public ContactsController(IContactsRepository ContactsRepository)
        {
            this.ContactsRepository = ContactsRepository;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("SessionUserName") ==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var test = HttpContext.Session.GetString("SessionUserName");
            TempData["ContactModel"] = ContactsRepository.List(1);
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            TempData["ContactModel"] = ContactsRepository.List(currentPageIndex);
           return View();
        }



        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contacts Contact)
        {
            try
            {
                if (ContactsRepository.Add(Contact))
                {
                    TempData["msg"] = "Save Done Successfuly";
                }
                else
                {
                    TempData["msg"] = "error";

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }                        

    

        // POST: ContactsController/Edit/5
        [HttpPost]
        public ActionResult Edit(string ContactId, string jsonData)
        {
            try
            {
                int id = Convert.ToInt32(ContactId);
                List<Contacts> contact = new List<Contacts>();
                contact = JsonConvert.DeserializeObject<List<Contacts>>(jsonData, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                
                if (ContactsRepository.Update(contact[0]))
                {
                    return Json(new { success = true });

                }
                else
                {
                    return Json(new { success = false });

                }
            }
            catch(Exception e)
            {
                return Json(new { success = false });

            }
        }

        // GET: ContactsController/Delete/5
        public ActionResult Delete(int ContactId)
        {
           
          
            if (ContactsRepository.Delete(ContactId))
            {
                return Json(new { success = true });

            }
            else
            {
                return Json(new { success = false });

            }
        }

   
    }
}
