int prioritet;

while (true)
{
    Console.Write("Ange prioritet (1-3): ");
    string input = Console.ReadLine() ?? "";

    if (int.TryParse(input, out prioritet) && prioritet >= 1 && prioritet <= 3)
    {
        break;
    }

    Console.WriteLine("Ogiltig prioritet. Du måste ange ett heltal mellan 1 och 3.");
}

Console.WriteLine($"Vald prioritet: {prioritet}");