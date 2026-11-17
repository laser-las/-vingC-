public class DetailedIssueService : IIssueService
{
    public string ShowIssue(Issue issue)
    {
        string status = issue.IsResolved ? "Löst" : "Ej löst";
        string issueInfo = $"Titel: {issue.Title}, Status: {status}";
        Console.WriteLine($"Logg: Visar ärende - {issueInfo}");
        return issueInfo;
    }
}
