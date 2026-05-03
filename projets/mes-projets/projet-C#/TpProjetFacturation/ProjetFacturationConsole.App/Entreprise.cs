public class Entreprise : Personne
{
    private string siret;

    public Entreprise(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal, string siret)
        : base(id, nom, email, telephone, adresse, ville, codePostal)
    {
        this.siret = siret;
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
        Console.WriteLine($" - SIRET: {siret}");
    }
}