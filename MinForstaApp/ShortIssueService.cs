public class ShortIssueService : IIssueService
{
    public string ShowIssue(Issue issue)
    {
        string status = issue.IsResolved ? "Löst" : "Ej löst";
        return $"Titel: {issue.Title}, Status: {status}";
    }
}
