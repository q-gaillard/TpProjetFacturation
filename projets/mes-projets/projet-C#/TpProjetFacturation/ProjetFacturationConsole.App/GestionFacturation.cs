using System.Runtime.Serialization;

public class GestionFacturation
{
    private List<Client> clients;
    private List<Entreprise> entreprises;
    private Dictionary<int, Client> dictionnaireClients;
    private Dictionary<int, Entreprise> dictionnaireEntreprises;

    public GestionFacturation()
    {
        clients = new List<Client>();
        entreprises = new List<Entreprise>();
        dictionnaireClients = new Dictionary<int, Client>();
        dictionnaireEntreprises = new Dictionary<int, Entreprise>();
    }

    public void AfficherMenu()
    {
        Console.WriteLine("=== Menu de Gestion de Facturation ===");
        Console.WriteLine("1. Importer clients depuis CSV");
        Console.WriteLine("2. Importer entreprises depuis CSV");
        Console.WriteLine("3. Afficher clients");
        Console.WriteLine("4. Afficher entreprises");
        Console.WriteLine("5. Créer facture");
        Console.WriteLine("6. Afficher carnet de contact");
        Console.WriteLine("");
        Console.Write("Veuillez choisir une option: ");
        string choix = Console.ReadLine();
        switch (choix)
        {
            case "1":
                ImporterClientsDepuisCSV();
                break;
            case "2":
                ImporterEntreprisesDepuisCSV();
                break;
            case "3":
                AfficherClients();
                break;
            case "4":
                AfficherEntreprises();
                break;
            case "5":
                CreerFacture();
                break;
            case "6":
                AfficherCarnetContact();
                break;
            default:
                Console.WriteLine("Option invalide. Veuillez réessayer.");
                break;
        }
    }

    public void ImporterClientsDepuisCSV()
    {
        
    }

    public void ImporterEntreprisesDepuisCSV()
    {
        
    }

    public void ChargerClientsDepuisjson()
    {
        
    }

    public void ChargerEntreprisesDepuisjson()
    {
        
    }

    public void AfficherClients()
    {
        if (clients.Count == 0)
        {
            Console.WriteLine("Aucun client à afficher.");
            return;
        }
        else
        {
            Console.WriteLine("=== Liste des Clients ===");
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.GetID()} - {client.GetNom()}");
                Console.WriteLine("");
            }
        }
    }

    public void AfficherEntreprises()
    {
        if (entreprises.Count == 0)
        {
            Console.WriteLine("Aucune entreprise à afficher.");
            return;
        }
        else
        {
            Console.WriteLine("=== Liste des Entreprises ===");
            foreach (var entreprise in entreprises)
            {
                Console.WriteLine($"{entreprise.GetID()} - {entreprise.GetNom()}");
                Console.WriteLine("");
            }
        }
    }

    public void CreerFacture()
    {
        
    }

    public void GenererFichierTexteFacture(Facture facture)
    {
        
    }

    public void AfficherCarnetContact()
    {
        
    }
}