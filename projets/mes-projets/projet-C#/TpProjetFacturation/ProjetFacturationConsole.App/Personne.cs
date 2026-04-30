public abstract class Personne
{
    protected int id;
    protected string nom;
    protected string email;
    protected string telephone;
    protected string adresse;
    protected string ville;
    protected string codePostal;

    public int GetID()
    {
        return id;
    }
    public string GetNom()
    {
        return nom;
    }

    public Personne(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal)
    {
        this.id = id;
        this.nom = nom;
        this.email = email;
        this.telephone = telephone;
        this.adresse = adresse;
        this.ville = ville;
        this.codePostal = codePostal;
    }

    public abstract void AfficherInfos()
    {
        Console.Write($"ID: {id}");
        Console.Write($" - Nom: {nom}");
        Console.Write($" - Email: {email}");
        Console.Write($" - Téléphone: {telephone}");
        Console.Write($" - Adresse: {adresse}");
        Console.Write($" - Ville: {ville}");
        Console.Write($" - Code Postal: {codePostal}");
    }
}