public class Client : Personne
{
    private DateTime dateInscription;

    public Client(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal, DateTime dateInscription)
        : base(id, nom, email, telephone, adresse, ville, codePostal)
    {
        this.dateInscription = dateInscription;
    }

    public override void AfficherInfos()
    {
        Console.Write($"ID: {id}");
        Console.Write($" - Nom: {nom}");
        Console.Write($" - Email: {email}");
        Console.Write($" - Téléphone: {telephone}");
        Console.Write($" - Adresse: {adresse}");
        Console.Write($" - Ville: {ville}");
        Console.Write($" - Code Postal: {codePostal}");
        Console.WriteLine($" - Date d'inscription: {dateInscription.ToShortDateString()}");
    }
}