using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheScouts.Services;
using TheScouts.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TheScouts.Controllers
{
    public class JobsController : Controller
    {
        private readonly IPositionService _service;

        public JobsController(IPositionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var positions = await _service.GetAllAsync();
            return View(positions);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var position = await _service.FindOneAsync(id);
            return View(position);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Create(Position position)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(position);
                return RedirectToAction("Index");
            }
            return View(position);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var position = await _service.FindOneAsync(id);
            if(position != null)
            {
                await _service.DeleteAsync(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(int id)
        {
            var position = await _service.FindOneAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(position);
                return RedirectToAction("Index");
            }
            return View(position);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, string category)
        {
            var positions = await _service.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                positions = positions
                    .Where(position => position.JobTitle.ToLower().Contains(searchTerm.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                positions = positions
                    .Where(position => position.Country.ToLower() == category.ToLower())
                    .ToList();
            }

            ViewData["Category"] = category ?? "All";

            return View("Index", positions);
        }
    }
}

