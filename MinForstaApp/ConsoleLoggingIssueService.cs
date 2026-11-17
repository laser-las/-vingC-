public class ConsoleLoggingIssueService : IIssueService
{
    private readonly List<Issue> _issues = new List<Issue>();

    public void AddIssue(Issue issue)
    {
        _issues.Add(issue);
        Console.WriteLine($"Logg: Lade till ärendet '{issue.Title}'.");
    }

    public List<Issue> GetAllIssues()
    {
        Console.WriteLine($"Logg: Hämtade {_issues.Count} ärenden.");
        return _issues;
    }

    public void ResolveIssue(string title)
    {
        Issue? issue = _issues.FirstOrDefault(i => i.Title == title);
        if (issue != null)
        {
            issue.Resolve();
            Console.WriteLine($"Logg: Markerade '{title}' som löst.");
        }
    }
}
