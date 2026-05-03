using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;

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
        bool boolMenu = true;
        while (boolMenu)
        {
            Console.WriteLine("=== Menu de Gestion de Facturation ===");
            Console.WriteLine("1 - Importer clients depuis CSV");
            Console.WriteLine("2 - Importer entreprises depuis CSV");
            Console.WriteLine("3 - Afficher clients");
            Console.WriteLine("4 - Afficher entreprises");
            Console.WriteLine("5 - Créer facture");
            Console.WriteLine("6 - Afficher carnet de contact");
            Console.WriteLine("0 - quitter");
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
                case "0":
                    boolMenu = false;
                    break;
                default:
                    Console.WriteLine("Option invalide. Veuillez réessayer.");
                    break;
            }
        }
    }

    public void ImporterClientsDepuisCSV()
    {
        string[] lignes = File.ReadAllLines("clients.csv");

        foreach (string ligne in lignes)
        {
            string[] champs = ligne.Split(';');

            Client client = new Client(
                int.Parse(champs[0]),
                champs[1],
                champs[2],
                champs[3],
                champs[4],
                champs[5],
                champs[6],
                DateTime.Parse(champs[7])
            );

            Console.WriteLine($"\nLe client {client.GetNom} à bien été ajouté à la listes des clients\n");
            clients.Add(client);
            dictionnaireClients.Add(client.GetID, client);
            ExporterClientEnJson(clients, "clients.json");
        }
    }

    public void ImporterEntreprisesDepuisCSV()
    {
        string[] lignes = File.ReadAllLines("entreprises.csv");

        foreach (string ligne in lignes)
        {
            string[] champs = ligne.Split(';');

            Entreprise entreprise = new Entreprise(
                int.Parse(champs[0]),
                champs[1],
                champs[2],
                champs[3],
                champs[4],
                champs[5],
                champs[6],
                champs[7]
            );

            Console.WriteLine($"\nL'entreprise {entreprise.GetNom} à bien été ajouté à la listes des entreprises\n");
            entreprises.Add(entreprise);
            dictionnaireEntreprises.Add(entreprise.GetID, entreprise);
            ExporterEntreprisesEnJson(entreprises, "entreprises.json");
        }
    }

    public void ChargerClientsDepuisjson()
    {  
        if (!File.Exists("clients.json"))
        {
            clients = new List<Client>();
            return;
        }

        string json = File.ReadAllText("clients.json");

        List<Client>? clientsDepuisFichier = JsonSerializer.Deserialize<List<Client>>(json);

        clients = clientsDepuisFichier ?? new List<Client>();
    }

    public void ChargerEntreprisesDepuisjson()
    {
        if (!File.Exists("entreprises.json"))
        {
            clients = new List<Entreprise>();
            return;
        }

        string json = File.ReadAllText("entreprises.json");

        List<Client>? clientsDepuisFichier = JsonSerializer.Deserialize<List<Entreprise>>(json);

        clients = clientsDepuisFichier ?? new List<Entreprise>();
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
        if (clients.Count() == 0)
        {
            ChargerClientsDepuisjson();
        }

        if (entreprises.Count() == 0)
        {
            ChargerEntreprisesDepuisjson();
        }

        AfficherEntreprises();
        Console.WriteLine("\nchoisisez un ID d'entreprise : ");
        int idEntreprise = int.Parse(Console.ReadLine());
        Entreprise entreprise = dictionnaireEntreprises[idEntreprise];

        AfficherClients();
        Console.WriteLine("\nchoisisez un ID de client : ");
        int idClient = int.Parse(Console.ReadLine());
        Client client = dictionnaireClients[idClient];

        Console.WriteLine("\n quel est la date d'emission : ");
        DateTime dateEmission = DateTime.Parse(Console.ReadLine());
        DateTime dateEcheance = dateEmission;
        dateEcheance.AddDays(30);

        Console.WriteLine("\n quel le numéro : ");
        int numero = int.Parse(Console.ReadLine());

        bool boolLigneFacture = true;
        List<LigneFacture> lignes= new List<LigneFacture>();
        while (boolLigneFacture)
        {
            Console.WriteLine("\n--- ligne de la facture ---");
            Console.WriteLine("entrer une description : ");
            string description = Console.ReadLine();
            Console.WriteLine("entrer une quantité : ");
            int quantite = int.Parse(Console.ReadLine());
            Console.WriteLine("entrer un prix unitaire : ");
            decimal prixUnitaireHT = decimal.Parse(Console.ReadLine());
            Console.WriteLine("entrer un taux de TVA : ");
            decimal tauxTVA = decimal.Parse(Console.ReadLine());

            lignes.Add(LigneFacture(description, quantite, prixUnitaireHT, tauxTVA));
            Console.WriteLine("ligne terminé\nvoulez vous crée une nouvelle ligne ( y / n )");
            choix = Console.ReadLine();
            if (choix != "y")
            {
                boolLigneFacture = false;
            }
        }

        Facture facture = new Facture(numero, dateEmission, client, entreprise, dateEcheace, "non payer");
        Console.WriteLine("\nConfirmer la génération du fichier texte ? ( y / n ) ");
        string choix = Console.ReadLine();
        if (choix == "y")
        {
            GenererFichierTexteFacture(facture);
        }
    }

    public void GenererFichierTexteFacture(Facture facture)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("FACTURE\n");

        sb.AppendLine($"Numéro: {facture.Numero}");
        sb.AppendLine($"Date d'émission: {facture.DateEmission.ToShortDateString()}");
        sb.AppendLine($"Date d'échéance: {facture.DateEcheance.ToShortDateString()}");
        sb.AppendLine($"Statut: {facture.Statut}");

        sb.AppendLine("\nEntreprise:");
        facture.Entreprise.AfficherInfos();

        sb.AppendLine("\nClient:");
        facture.Client.AfficherInfos();

        sb.AppendLine("\nLignes:");
        foreach (var ligne in facture.Lignes)
        {
            ligne.AfficherLigne();
        }

        sb.AppendLine($"\nTotal HT: {facture.CalculerTotalHT():C}");
        sb.AppendLine($"Total TVA: {facture.CalculerTotalTVA():C}");
        sb.AppendLine($"Total TTC: {facture.CalculerTotalTTC():C}");

        File.WriteAllText("facture.txt", sb.ToString());
    }

    public void AfficherCarnetContact()
    {
        if (clients.Count() == 0)
        {
            ChargerClientsDepuisjson();
        }

        if (entreprises.Count() == 0)
        {
            ChargerEntreprisesDepuisjson();
        }

        List<Personne> personnes = new List<Personne>();

        foreach (Client client in clients)
        {
            personnes.Add(client);
        }

        foreach (Entreprise entreprise in entreprises)
        {
            personnes.Add(entreprise);
        }

        Console.WriteLine("\n Cartnet de contact : ");
        foreach ( Personne personne in personnes)
        {
            personne.AfficherInfos();
        }
    }

    private void ExporterClientsEnJson(List<Client> clients, string nomJson)
    {
        if (!File.Exists(nomJson))
        {
            File.Create(nomJson).Dispose();
        }

        string json = JsonSerializer.Serialize(clients, new JsonSerializerOptions{ WriteIndented = true });

        File.WriteAllText(nomJson, json);
    }

    private void ExporterEntreprisesEnJson(List<Entreprise> entreprises, string nomJson)
    {
        if (!File.Exists(nomJson))
        {
            File.Create(nomJson).Dispose();
        }

        string json = JsonSerializer.Serialize(entreprises, new JsonSerializerOptions{ WriteIndented = true });

        File.WriteAllText(nomJson, json);
    }
}