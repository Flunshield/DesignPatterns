using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        societe societe1 = new societeSansFilial();
        societe1.ajouteVehicule();
        societe1.ajouteVehicule();
        societe societe2 = new societeMaire();
        societe2.ajouteVehicule();

        societe groupe = new societeMaire();
        groupe.ajouteFilial(societe2);
        groupe.ajouteFilial(societe1);

        double countcoutEntretient = groupe.countCoutEntretient();
        Console.WriteLine(countcoutEntretient);
    }
}


// Class abstraite
public abstract class societe {
    protected static double countVehicule = 5.0;
    protected int nbrVehicvules = 0;

    public void ajouteVehicule()
    {
        nbrVehicvules += 1;
    }

    public abstract double countCoutEntretient();
    public abstract bool ajouteFilial(societe filiale);
}

// class concrete
public class societeSansFilial: societe
{
    public override bool ajouteFilial(societe filiale)
    {
        return false;
    }
    public override double countCoutEntretient()
    {
        return countVehicule * nbrVehicvules;
    }
}

// class concrete
public class societeMaire: societe
{
    protected List<societe> filiales = new List<societe>();

    public override bool ajouteFilial(societe filiale)
    {
        filiales.Add(filiale);
        return true;
    }
    public override double countCoutEntretient()
    {
        double cout = 0.0;
        foreach (societe filiale in filiales)
        {
            cout = cout + filiale.countCoutEntretient();
        }
        return cout + countVehicule * nbrVehicvules;
    }
}