namespace _07RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, string engineSpeed, string enginePower, string cargoWeight, string cargoType, string tire1Pressure, string tire1Age, string tire2Pressure, string tire2Age, string tire3Pressure, string tire3Age, string tire4Pressure, string tire4Age)
        {
            this.Model = model;
            this.Engine = new Engine(int.Parse(engineSpeed), int.Parse(enginePower));
            this.Cargo = new Cargo(cargoType, int.Parse(cargoWeight));
            this.Tires = new Tire[4];
            this.Tires[0] = new Tire(int.Parse(tire1Age), double.Parse(tire1Pressure));
            this.Tires[1] = new Tire(int.Parse(tire2Age), double.Parse(tire2Pressure));
            this.Tires[2] = new Tire(int.Parse(tire3Age), double.Parse(tire3Pressure));
            this.Tires[3] = new Tire(int.Parse(tire4Age), double.Parse(tire4Pressure));
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }
    }
}