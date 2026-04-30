public class Facture : DocumentCommercial
{
    private DateTime dateEcheance;
    private string statut;

    public override void AfficherFacture()
    {
        Console.WriteLine("FACTURE\n");
        Console.WriteLine($"Numéro: {numero}\n");
        Console.WriteLine($"Date d'émission: {dateEmission.ToShortDateString()}\n");
        Console.WriteLine($"Date d'échéance: {dateEcheance.ToShortDateString()}\n");
        Console.WriteLine($"Statut: {statut}\n");
        Console.WriteLine("entreprise:");
        entreprise.AfficherInfos();
        Console.WriteLine("\nclient:");
        client.AfficherInfos();
        Console.WriteLine("\nLignes:");
        foreach (var ligne in lignes)
        {
            ligne.AfficherLigne();
        }
        Console.WriteLine($"\nTotal HT: {CalculerTotalHT():C}");
        Console.WriteLine($"Total TVA: {CalculerTotalTVA():C}");
        Console.WriteLine($"Total TTC: {CalculerTotalTTC():C}");
    }
}