List<Issue> issues = new List<Issue>();
bool running = true;
while (running)
{
    Console.WriteLine("\n===============================");
    Console.WriteLine("   ÄRENDEHANTERING (MENY)");
    Console.WriteLine("===============================");
    Console.WriteLine("1. Lägg till nytt ärende");
    Console.WriteLine("2. Markera ett ärende som löst");
    Console.WriteLine("3. Visa alla ärenden");
    Console.WriteLine("4. Avsluta");
    Console.Write("Välj ett alternativ (1-4): ");

    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            Console.Write("Skriv titel på ärendet (minst 3 tecken): ");
            string? title = Console.ReadLine();

            try
            {
                // Skapar ett nytt Issue-objekt med det du skrev in och skickar till tjänsten
                Issue newIssue = new Issue(title ?? "");
                issues.Add(newIssue);
            }
            catch (ArgumentException ex)
            {
                // Fångar felet från Issue-konstruktorn om titeln är för kort
                Console.WriteLine($"Fel: {ex.Message} Försök igen.");
            }
            break;

        case "2":
            Console.Write("Skriv exakt titel på ärendet som ska markeras som löst: ");
            string? resolveTitle = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(resolveTitle))
            {
                Issue? issue = issues.FirstOrDefault(i => i.Title == resolveTitle.Trim());
                issue?.Resolve();
            }
            break;

        case "3":

            if (issues.Count == 0)
            {
                Console.WriteLine("Det finns inga ärenden i listan.");
            }
            else
            {
                Console.Write("Vill du ha korta eller långa beskrivningar av ärendena? (kort/lång): ");
                string? detailChoice = Console.ReadLine()?.ToLower();
                if (detailChoice == "kort")
                {
                    ShortIssueService shortService = new ShortIssueService();
                    foreach (Issue issue in issues)
                    {
                        string issueInfo = shortService.ShowIssue(issue);
                        Console.WriteLine(issueInfo);
                    }
                }
                else if (detailChoice == "lång")
                {
                    DetailedIssueService detailedService = new DetailedIssueService();
                    foreach (Issue issue in issues)
                    {
                        string issueInfo = detailedService.ShowIssue(issue);
                        Console.WriteLine(issueInfo);
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Visar korta beskrivningar som standard.");
                    ShortIssueService shortService = new ShortIssueService();
                    foreach (Issue issue in issues)
                    {
                        string issueInfo = shortService.ShowIssue(issue);
                        Console.WriteLine(issueInfo);
                    }
                }
                Console.WriteLine("--- Alla ärenden ---");
                foreach (Issue issue in issues)
                {
                    string status = issue.IsResolved ? "Löst" : "Pågående";
                    Console.WriteLine($"Titel: {issue.Title} | Status: {status}");
                }
            }
            break;

        case "4":
            running = false;
            Console.WriteLine("Avslutar programmet...");
            break;

        default:
            Console.WriteLine("Ogiltigt val. Skriv en siffra mellan 1 och 4.");
            break;
    }
}