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

    public abstract void AfficherInfos();
}