bool korProgram = true;

while (korProgram)
{
    Console.WriteLine("1 Information");
    Console.WriteLine("2 Registrera titel");
    Console.WriteLine("0 Avsluta");
    Console.Write("Välj ett alternativ: ");

    string val = Console.ReadLine() ?? "";

    switch (val)
    {
        case "1":
            Console.WriteLine("Detta är en konsolapplikation för att registrera ärenden.");
            break;
        case "2":
            Console.Write("Ange titel: ");
            string titel = (Console.ReadLine() ?? "").Trim();
            Console.WriteLine($"Registrerad titel: {titel}");
            break;
        case "0":
            Console.WriteLine("Programmet avslutas.");
            korProgram = false;
            break;
        default:
            Console.WriteLine("Ogiltigt val, försök igen.");
            break;
    }

    Console.WriteLine();
}