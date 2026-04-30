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
        base.AfficherInfos();
        Console.WriteLine($" - Date d'inscription: {dateInscription.ToShortDateString()}");
    }
}