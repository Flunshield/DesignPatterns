namespace AbstractFactory
{
    interface IFabriqueVehicule
    {
        IVehicule CreateVehiculeElectrique();
        IVehicule CreateVehiculeEssence();
    }

    interface IVehicule
    {
        string Name { get; set; }
        string Model { get; set; }
        string type { get; set; }
    }

    class FabriqueVehicule : IFabriqueVehicule
    {
        public IVehicule CreateVehiculeElectrique()
        {
            return new VehiculeElectrique();
        }

        public IVehicule CreateVehiculeEssence()
        {
            return new VehiculeEssence();
        }
    }

    class VehiculeElectrique : IVehicule
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string type { get; set; }
    }

    class VehiculeEssence : IVehicule
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
            string type = "electric";

            IVehicule vehicule = null;

            if (type == "electric")
            {
                vehicule = fabrique.CreateVehiculeElectrique();
            }
            else if (type == "essence")
            {
                vehicule = fabrique.CreateVehiculeEssence();
            }
            vehicule.Name = "julien";
            vehicule.Model = "tesla";

        }
    }
}
