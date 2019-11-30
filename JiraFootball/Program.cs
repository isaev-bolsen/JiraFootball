using System;
using Atlassian.Jira;

namespace JiraFootball
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Jira jira = Jira.CreateRestClient("https://jira..com", "", "");
            foreach (Issue issue in jira.Issues.GetIssuesFromJqlAsync("assignee = currentUser() AND resolution = Unresolved order by updated DESC").Result)
            {
                if (DescriptionIsWrong(issue))
                {
                    Console.WriteLine($"Changing Assignment for {issue.Key} due to wrong description");
                    jira.Issues.AssignIssueAsync(issue.Key.Value, issue.Reporter);
                }
            }
        }

        private static bool DescriptionIsWrong(Issue issue)
        {
            return issue.Description.Trim().Length < 5; 
        }
    }
}
