List<Issue> issues = new List<Issue>
{
    new Issue { Title = "Datorn startar inte", Priority = 1 },
    new Issue { Title = "Skrivaren saknar papper", Priority = 3 },
    new Issue { Title = "Långsamt Wi-Fi i konferensrummet", Priority = 2 }
};

foreach (Issue issue in issues)
{
    Console.WriteLine($"Ärende: {issue.Title} | Prioritet: {issue.Priority}");
}

class Issue
{
    public string Title { get; set; } = "";
    public int Priority { get; set; }
}