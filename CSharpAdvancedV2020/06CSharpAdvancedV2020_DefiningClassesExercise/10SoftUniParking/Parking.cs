using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.capacity = capacity;
        }

        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int Count => this.Cars.Count;

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.Cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.Cars.Remove(car);

            return "Successfully removed " + registrationNumber;
        }

        public Car GetCar(string registrationNumber)
        {
            return this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            RegistrationNumbers.ForEach(rn => this.RemoveCar(rn));
            //foreach (string registrationNumber in RegistrationNumbers)
            //{
            //    Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            //    if (car != null)
            //    {
            //        this.Cars.Remove(car);
            //    }
            //}
        }
    }
}