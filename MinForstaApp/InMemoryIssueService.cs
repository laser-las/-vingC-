public class InMemoryIssueService : IIssueService
{
    private readonly List<Issue> _issues = new List<Issue>();

    public void AddIssue(Issue issue)
    {
        _issues.Add(issue);
    }

    public List<Issue> GetAllIssues()
    {
        return _issues;
    }

    public void ResolveIssue(string title)
    {
        Issue? issue = _issues.FirstOrDefault(i => i.Title == title);
        issue?.Resolve();
    }
}
