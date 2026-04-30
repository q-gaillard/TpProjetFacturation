public abstract class DocumentCommercial
{
    protected string numero;
    protected DateTime dateEmission;
    protected Client client;
    protected Entreprise entreprise;
    protected List<LigneFacture> lignes;

    public DocumentCommercial(string numero, DateTime dateEmission, Client client, Entreprise entreprise)
    {
        this.numero = numero;
        this.dateEmission = dateEmission;
        this.client = client;
        this.entreprise = entreprise;
        this.lignes = new List<LigneFacture>();
    }

    public void AjouterLigne(LigneFacture ligne)
    {
        lignes.Add(ligne);
    }

    public decimal CalculerTotalHT()
    {
        decimal totalHT = 0;
        foreach (var ligne in lignes)
        {
            totalHT += ligne.CalculerMontantHT();
        }
        return totalHT;
    }

    public decimal CalculerTotalTVA()
    {
        decimal totalTVA = 0;
        foreach (var ligne in lignes)
        {
            totalTVA += ligne.CalculerMontantTVA();
        }
        return totalTVA;
    }

    public decimal CalculerTotalTTC()
    {
        return CalculerTotalHT() + CalculerTotalTVA();
    }

    public abstract void AfficherFacture();
}