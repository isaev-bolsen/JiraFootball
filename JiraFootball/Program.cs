using Atlassian.Jira;
using System;

namespace JiraFootball
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Jira jira = Jira.CreateRestClient("https://jira..com", "", "");
			foreach (Issue issue in jira.Issues.GetIssuesFromJqlAsync("").Result)
			{
				Console.WriteLine(issue.Description);
				if(string.IsNullOrWhiteSpace( issue.Description))
				{
					jira.Issues.AssignIssueAsync(issue.Key.Value, issue.Reporter);
				}
			}
		}
	}
}
