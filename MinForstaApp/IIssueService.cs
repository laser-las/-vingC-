public interface IIssueService
{
    void AddIssue(Issue issue);
    List<Issue> GetAllIssues();
    void ResolveIssue(string title);
}
