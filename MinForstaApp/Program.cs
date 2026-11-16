string titel = "";
while (true)
{
    Console.Write("Ange titel (minst 3 tecken): ");
    titel = (Console.ReadLine() ?? "").Trim();

    if (titel.Length >= 3)
    {
        break;
    }

    Console.WriteLine("Ogiltig titel. Får inte vara tom och måste innehålla minst 3 tecken.");
}

int prioritet;
while (true)
{
    Console.Write("Ange prioritet (1, 2 eller 3): ");
    string prioInput = Console.ReadLine() ?? "";

    if (int.TryParse(prioInput, out prioritet) && prioritet >= 1 && prioritet <= 3)
    {
        break;
    }

    Console.WriteLine("Ogiltig prioritet. Du måste ange 1, 2 eller 3.");
}

Console.WriteLine();
Console.WriteLine("--- Sammanfattning ---");
Console.WriteLine($"Titel: {titel}");
Console.WriteLine($"Prioritet: {prioritet}");
Console.WriteLine();

List<string> titlar = new List<string>
{
    titel,
    "Nätverksproblem på plan 2",
    "Trasig skrivare i receptionen"
};

Console.WriteLine("Alla titlar i listan:");
foreach (string t in titlar)
{
    Console.WriteLine($"- {t}");
}