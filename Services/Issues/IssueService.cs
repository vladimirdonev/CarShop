using AutoMapper;
using CarShop.Data;
using CarShop.Models;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Services.Issues
{
    public class IssueService : IIssueService
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public IssueService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public ICollection<AllIssuesViewModel> all(string carId)
        {
            var issues = this.db.Issues.Where(x => x.CarId == carId).ToList();

            var issuesViewModels = new List<AllIssuesViewModel>();

            foreach (var issue in issues)
            {
                this.db.Entry(issue).Reference(x => x.Car).Load();
                issuesViewModels.Add(this.mapper.Map<Issue, AllIssuesViewModel>(issue));
            }

            return issuesViewModels;
        }

        public void CreateIssue(CreateIssueViewModel createIssueViewModel, string carId)
        {
            var issue = new Issue();
            issue = this.mapper.Map<CreateIssueViewModel, Issue>(createIssueViewModel);
            issue.CarId = carId;
            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public void DeleteIssue(string IssueId)
        {
            var issue = this.db.Issues.FirstOrDefault(x => x.Id == IssueId);
            this.db.Issues.Remove(issue);
            this.db.SaveChanges();
        }

        public string FindCarId(string issueId)
        {
            var carId = this.db.Issues.Where(x => x.Id == issueId).FirstOrDefault().CarId;
            return carId;
        }

        public void Fix(string issueId)
        {
            var issue = this.db.Issues.Where(x => x.Id == issueId).FirstOrDefault();
            issue.IsFixed = true;
            this.db.Entry(issue).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            this.db.Update(issue);
            this.db.SaveChanges();
        }
    }
}
