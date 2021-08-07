using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Services.Issues
{
    public interface IIssueService
    {
        public void CreateIssue(CreateIssueViewModel createIssueViewModel,string carId);

        public void Fix(string issueId);

        public void DeleteIssue(string IssueId);

        public ICollection<AllIssuesViewModel> all(string carId);

        public string FindCarId(string issueId);
    }
}
