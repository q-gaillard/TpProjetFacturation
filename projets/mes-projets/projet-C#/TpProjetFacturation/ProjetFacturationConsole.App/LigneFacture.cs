public class LigneFacture
{
    private string description;
    private int quantite;
    private decimal prixUnitaireHT;
    private decimal tauxTVA;

    public LigneFacture(string description, int quantite, decimal prixUnitaireHT, decimal tauxTVA)
    {
        this.description = description;
        this.quantite = quantite;
        this.prixUnitaireHT = prixUnitaireHT;
        this.tauxTVA = tauxTVA;
    }

    public decimal CalculerMontantHT()
    {
        return quantite * prixUnitaireHT;
    }

    public decimal CalculerMontantTVA()
    {
        return CalculerMontantHT() * (tauxTVA / 100);
    }

    public decimal CalculerTotalTTC()
    {
        return CalculerMontantHT() + CalculerMontantTVA();
    }
}