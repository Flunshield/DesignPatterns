using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Societe societe1 = new societeSansFilial();
        societe1.ajouteVehicule();
        societe1.ajouteVehicule();
        Societe societe2 = new societeMere();
        societe2.ajouteVehicule();
        societe2.ajouteFilial(societe1);

        Societe groupe = new societeMere();
        groupe.ajouteFilial(societe2);

        double countcoutEntretient = groupe.countCoutEntretien();
        Console.WriteLine(countcoutEntretient);
    }
}


// Class abstraite
public abstract class Societe {
    protected static double countVehicule = 5.0;
    protected int nbrVehicvules = 0;

    public void ajouteVehicule()
    {
        nbrVehicvules += 1;
    }

    public abstract double countCoutEntretien();
    public abstract bool ajouteFilial(Societe filiale);
}

// class concrete
public class societeSansFilial: Societe
{
    public override bool ajouteFilial(Societe filiale)
    {
        return false;
    }
    public override double countCoutEntretien()
    {
        return countVehicule * nbrVehicvules;
    }
}

// class concrete
public class societeMere: Societe
{
    protected List<Societe> filiales = new List<Societe>();

    public override bool ajouteFilial(Societe filiale)
    {
        filiales.Add(filiale);
        return true;
    }
    public override double countCoutEntretien()
    {
        double cout = 0.0;
        foreach (Societe filiale in filiales)
        {
            cout = cout + filiale.countCoutEntretien();
        }
        return cout + countVehicule * nbrVehicvules;
    }
}