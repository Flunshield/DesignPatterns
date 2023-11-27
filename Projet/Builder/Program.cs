using System;
using System.Collections.Generic;

// Produit - Document
class Document
{
}

// Produits concrets
class BonDeCommande : Document
{
}

class DemandeImmatriculation : Document
{
}

class CertificatCession : Document
{
}

// Constructeur - Interface pour la création des produits
interface ConstructeurLiasseVehicule
{
    void ConstruitBonDeCommande();
    void ConstruitDemandeImmatriculation();
    void ConstruitCertificatCession();
}

// Constructeurs concrets
class ConstructeurLiasseVehiculeHtml : ConstructeurLiasseVehicule
{
    private LiasseVehicule _liaison = new LiasseVehicule();

    public void ConstruitBonDeCommande()
    {
        _liaison.AjouteDocument(new BonDeCommande());
    }

    public void ConstruitDemandeImmatriculation()
    {
        _liaison.AjouteDocument(new DemandeImmatriculation());
    }

    public void ConstruitCertificatCession()
    {
        _liaison.AjouteDocument(new CertificatCession());
    }

    public LiasseVehicule GetResult()
    {
        return _liaison;
    }
}

class ConstructeurLiasseVehiculePdf : ConstructeurLiasseVehicule
{
    private LiasseVehicule _liaison = new LiasseVehicule();

    public void ConstruitBonDeCommande()
    {
        _liaison.AjouteDocument(new BonDeCommande());
    }

    public void ConstruitDemandeImmatriculation()
    {
        _liaison.AjouteDocument(new DemandeImmatriculation());
    }

    public void ConstruitCertificatCession()
    {
        _liaison.AjouteDocument(new CertificatCession());
    }

    public LiasseVehicule GetResult()
    {
        return _liaison;
    }
}

// Produit final - Liasse de documents
class LiasseVehicule
{
    private List<Document> _documents = new List<Document>();

    public void AjouteDocument(Document document)
    {
        _documents.Add(document);
    }

    public void Affiche()
    {
        foreach (var document in _documents)
        {
            Console.WriteLine(document.GetType().Name);
        }
    }
}

// Client
class Commercial
{
    public void ConstruitLiasse(ConstructeurLiasseVehicule constructeur)
    {
        constructeur.ConstruitBonDeCommande();
        constructeur.ConstruitDemandeImmatriculation();
        constructeur.ConstruitCertificatCession();
    }
}

class Program
{
    static void Main()
    {
        Commercial commercial = new Commercial();

        // Client choisit le constructeur HTML
        ConstructeurLiasseVehiculeHtml constructeurHtml = new ConstructeurLiasseVehiculeHtml();
        commercial.ConstruitLiasse(constructeurHtml);
        LiasseVehicule liaisonHtml = constructeurHtml.GetResult();
        liaisonHtml.Affiche();

        // Client choisit le constructeur PDF
        ConstructeurLiasseVehiculePdf constructeurPdf = new ConstructeurLiasseVehiculePdf();
        commercial.ConstruitLiasse(constructeurPdf);
        LiasseVehicule liaisonPdf = constructeurPdf.GetResult();
        liaisonPdf.Affiche();
    }
}
