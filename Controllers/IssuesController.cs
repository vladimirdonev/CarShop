using CarShop.ViewModels.Issues;
using CarShop.Services.Issues;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CarShop.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        private IIssueService issueServise;

        public IssuesController(IIssueService issueServise)
        {
            this.issueServise = issueServise;
        }

        [HttpGet]
        public IActionResult AddIssue(string carId)
        {
            this.ViewBag.id = carId;
            return this.View();
        }

        [HttpPost]
        public IActionResult AddIssue(CreateIssueViewModel createIssueViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createIssueViewModel);
            }
            this.issueServise.CreateIssue(createIssueViewModel, createIssueViewModel.CarId);
            return this.RedirectToAction("AllIssues", "Issues", new { createIssueViewModel.CarId });
        }

        [HttpGet]
        [Authorize(Roles = "Mechanic")]
        public IActionResult Fix(string issueId)
        {
            this.issueServise.Fix(issueId);
            var carId = this.issueServise.FindCarId(issueId);
            return this.RedirectToAction("AllIssues", "Issues",new { carId });
        }

        [HttpGet]
        public IActionResult Delete(string issueId)
        {
            var carId = this.issueServise.FindCarId(issueId);
            this.issueServise.DeleteIssue(issueId);
            return this.RedirectToAction("AllIssues", "Issues", new { carId });
        }

        [HttpGet]
        public IActionResult AllIssues(string carId)
        {
            var issues = this.issueServise.all(carId);
            this.ViewBag.id = carId;
            return this.View(issues);
        }
    }
}
