// Definierar klassen (mallen) för ett ärende
public class Issue
{
    // Egenskap för titel som bara kan läsas utifrån (sätts enbart i konstruktorn)
    public string Title { get; }
    
    // Egenskap för status som kan läsas utifrån, men bara ändras inifrån klassen (private set)
    public bool IsResolved { get; private set; }

    // Konstruktor som körs automatiskt när man skapar ett nytt objekt med 'new Issue(...)'
    public Issue(string title)
    {
        // Kontrollerar om titeln är tom/null eller har färre än 3 tecken (utan mellanslag)
        if (string.IsNullOrWhiteSpace(title) || title.Trim().Length < 3)
            // Stoppar skapandet av objektet och kastar ett felmeddelande
            throw new ArgumentException("För kort titel.");

        // Tar bort onödiga mellanslag i början/slutet och sparar titeln i egenskapen Title
        Title = title.Trim();
    }

    // Publik metod som gör det möjligt att markera ärendet som löst utifrån
    public void Resolve()
    {
        // Ändrar egenskapen IsResolved till true (tillåtet eftersom vi är inuti klassen Issue)
        IsResolved = true;
    }
}