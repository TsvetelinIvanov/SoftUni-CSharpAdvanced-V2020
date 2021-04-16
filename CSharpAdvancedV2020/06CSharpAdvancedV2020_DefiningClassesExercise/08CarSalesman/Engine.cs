﻿using System;

namespace _08CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power, displacement)
        {            
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }

        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

        public override string ToString()
        {
            string displacementString = this.Displacement.ToString();
            if (this.Displacement == -1)
            {
                displacementString = "n/a";
            }

            return $"{this.Model}:{Environment.NewLine}    Power: {this.Power}{Environment.NewLine}    Displacement: {displacementString}{Environment.NewLine}    Efficiency: {this.Efficiency}";
        }
    }
}