using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheScouts.Models;
using TheScouts.Services;

namespace TheScouts.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var contacts = await _service.GetAllAsync();
            return View(contacts);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Details(int id)
        {
            var contact = await _service.FindOneAsync(id);
            return View(contact);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(contact);
                return RedirectToAction("SuccessMessage");
            }
            return View(contact);
        }

        public IActionResult SuccessMessage()
        {
            ViewBag.SuccessMessage = "Message submitted successfully!";

            return PartialView("_SuccessMessage", ViewBag.SuccessMessage);
        }
    }
}

