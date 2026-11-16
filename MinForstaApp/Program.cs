Console.Write("Ange titel: ");
string title = Console.ReadLine() ?? "";

Console.Write("Ange prioritet (1-3): ");
int.TryParse(Console.ReadLine(), out int priority);

try
{
    Issue arende = new Issue(title, priority);
    Console.WriteLine($"Ärende skapat: {arende.Title} (Prioritet: {arende.Priority})");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Kunde inte skapa ärende: {ex.Message}");
}

class Issue
{
    public string Title { get; }
    public int Priority { get; }

    public Issue(string title, int priority)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Trim().Length < 3)
        {
            throw new ArgumentException("Titeln måste innehålla minst tre tecken.");
        }

        if (priority < 1 || priority > 3)
        {
            throw new ArgumentException("Prioritet måste vara mellan 1 och 3.");
        }

        Title = title.Trim();
        Priority = priority;
    }
}