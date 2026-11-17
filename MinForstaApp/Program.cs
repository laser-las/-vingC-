// Skapar tjänsten via interfacet IIssueService
IIssueService issueService = new ConsoleLoggingIssueService();

// Lägger till ett par startärenden så listan inte är helt tom från början (kan tas bort om du vill)
issueService.AddIssue(new Issue("Datorn startar inte"));
issueService.AddIssue(new Issue("Nätverksproblem på plan 2"));

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
                issueService.AddIssue(newIssue);
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
                issueService.ResolveIssue(resolveTitle.Trim());
            }
            break;

        case "3":
            List<Issue> allIssues = issueService.GetAllIssues();

            if (allIssues.Count == 0)
            {
                Console.WriteLine("Det finns inga ärenden i listan.");
            }
            else
            {
                Console.WriteLine("--- Alla ärenden ---");
                foreach (Issue issue in allIssues)
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