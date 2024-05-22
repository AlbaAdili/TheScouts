using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheScouts.Models;
using TheScouts.Services;

namespace TheScouts.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _service;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationController(IApplicationService service, IWebHostEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _environment = environment;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);

            if (User.IsInRole("Admin") || User.IsInRole("SuperAdmin"))
            {
                var allApplications = await _service.GetAllAsync();
                return View(allApplications);
            }
            else
            {
                var userApplications = await _service.FindApplicationsByUserIdAsync(userId);
                return View(userApplications);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create(int positionId)
        {
            var model = new Application
            {
                Id = positionId,
            };

            var position = await _service.FindPositionAsync(positionId);
            if(position != null)
            {
                ViewData["JobTitle"] = position.JobTitle;
                ViewData["Location"] = $"{position.City}, {position.Country}";
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Application application, IFormFile resume)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                application.UserId = userId;

                if (resume != null && resume.Length > 0)
                {
                    var resumes = Path.Combine(_environment.WebRootPath, "resumes");
                    var fileName = Guid.NewGuid().ToString() + "_" + application.Name + "-" + application.Surname + "-" + Path.GetFileName(resume.FileName);
                    var filePath = Path.Combine(resumes, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await resume.CopyToAsync(fileStream);
                    }

                    application.Resume = "/resumes/" + fileName;
                }

                await _service.AddAsync(application);
                return RedirectToAction("SuccessMessage");
            }

            return View(application);
        }

        public IActionResult SuccessMessage()
        {
            ViewBag.SuccessMessage = "Application submitted successfully!";

            return PartialView("_SuccessMessage", ViewBag.SuccessMessage);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Applications(int id)
        {
            var applications = await _service.FindApplicationsAsync(id);
            var positionName = await _service.GetPositionNameByIdAsync(id);

            ViewBag.PositionName = positionName;

            return View(applications);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var applications = await _service.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                applications = applications
                    .Where(application =>
                        application.Name.ToLower().Contains(searchTerm.ToLower()) ||
                        application.Surname.ToLower().Contains(searchTerm.ToLower())
                    )
                    .ToList();
            }

            return View("Index", applications);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> UpdateStatus(int applicationId, string status)
        {
            var updatedApplication = await _service.UpdateStatus(applicationId, status);

            if (updatedApplication != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}