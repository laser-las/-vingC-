Console.Write("Ange en titel: ");
string input = Console.ReadLine() ?? "";

string titel = input.Trim();

if (titel.Length >= 3)
{
    Console.WriteLine($"Titeln '{titel}' är godkänd!");
}
else
{
    Console.WriteLine("Ogiltig titel. Titeln måste innehålla minst tre tecken.");
}