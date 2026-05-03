namespace ProjetFacturationConsole.Tests;

using Xunit;
using System;

[TestClass]
public class FactureTests
{
    [TestMethode]
    public void Test_TotalHT_Ligne()
    {
        //Arrange
        LigneFacture ligne = new LigneFacture("Produit A", 10, 2, 20);

        // Act
        decimal result = ligne.CalculerMontantHT();

        // Assert
        Assert.Equal(20, result);
    }

    [TestMethode]
    public void Test_TotalTTC_Ligne()
    {
        // Arrange
        LigneFacture ligne = new LigneFacture("Produit A", 10, 2, 20);

        // Act
        decimal result = ligne.CalculerMontantHT() + ligne.CalculerMontantTVA();

        // Assert
        Assert.Equal(24, result);
    }

    [TestMethode]
    public void Test_TotalTTC_Facture_MultiplesLignes()
    {
        // Arrange
        Client client = new Client(1, "Durand", "a@a.com", "0600000000", "Rue A", "Paris", "75000", DateTime.Now);
        Entreprise entreprise = new Entreprise(1, "ACME", "b@b.com", "0100000000", "Rue B", "Paris", "75000", "123456789");

        Facture facture = new Facture("F001", DateTime.Now, client, entreprise, DateTime.Now.AddDays(30), "non payer");

        facture.AjouterLigne(new LigneFacture("Produit A", 10, 2, 20));
        facture.AjouterLigne(new LigneFacture("Produit B", 5, 4, 20));

        // Act
        decimal total = facture.CalculerTotalTTC();

        // Assert
        Assert.Equal(48, total);
    }
}
