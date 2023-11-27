namespace AbstractFactory
{
    interface IFabriqueVehicule
    {
        IVehicule CreateVehicule(string type);
    }

    interface IVehicule
    {
        string Name { get; set; }
        string Model { get; set; }
        string type { get; set; }
    }

    class FabriqueVehicule : IFabriqueVehicule
    {
        public IVehicule CreateVehicule(string type)
        {
            IVehicule vehicule = new Vehicule();
            if (type == "electric")
            {
                vehicule.Name = "tesla";
                vehicule.Model = "S";
                vehicule.type = "Electrique";
            }
            if (type == "essence")
            {
                vehicule.Name = "renaud";
                vehicule.Model = "kangoo";
                vehicule.type = "Essence";
            }
            if (type == "hybride")
            {
                vehicule.Name = "toyota";
                vehicule.Model = "chr";
                vehicule.type = "Hybride";
            }
            return vehicule;
        }
    }

    class Vehicule : IVehicule
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string type { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFabriqueVehicule fabrique = new FabriqueVehicule();
            IVehicule electric = fabrique.CreateVehicule("electric");
            IVehicule essence = fabrique.CreateVehicule("essence");
            IVehicule hybride = fabrique.CreateVehicule("hybride");
            bool sorti = false;

            while (sorti == false)
            {

                Console.WriteLine("Quel véhicule souhaitez vous ?");
                Console.WriteLine("Véhicule electric ? Taper 1");
                Console.WriteLine("Véhicule essence ? Taper 2");
                Console.WriteLine("Véhicule hybride ? Taper 3");
                Console.WriteLine("Pour sortir ? Taper 4");
                string chose = Console.ReadLine();

                switch (chose)
                {

                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Le nom de la marque sera : " + electric.Name);
                        Console.WriteLine("Le model sera : " + electric.Model);
                        Console.WriteLine("Le type sera : " + electric.type);
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("");
                        break;

                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Le nom de la marque sera : " + essence.Name);
                        Console.WriteLine("Le model sera : " + essence.Model);
                        Console.WriteLine("Le type sera : " + essence.type);
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("");
                        break;

                    case "3":
                        Console.WriteLine("");
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Le nom de la marque sera : " + hybride.Name);
                        Console.WriteLine("Le model sera : " + hybride.Model);
                        Console.WriteLine("Le type sera : " + hybride.type);
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("");
                        break;

                    case "4":
                        sorti = true;
                        break;
                    default:
                        // Logique pour un type de véhicule inconnu
                        break;
                }

            }


        }
    }
}