using System;
using System.Collections.Generic;

namespace _05CreationalPatterns_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperCarBuilder superBuilder = new SuperCarBuilder();
            NotSuperCarBuilder notSuperBuilder = new NotSuperCarBuilder();

            CarFactory factory = new CarFactory();
            List<CarBuilder> builders = new List<CarBuilder> { superBuilder, notSuperBuilder };

            foreach (CarBuilder builder in builders)
            {
                Car car = factory.Build(builder);
                Console.WriteLine($"The Car requested by " +
                    $"{builder.GetType().Name}: " +
                    $"\n--------------------------------------" +
                    $"\nHorse Power: {car.HorsePower}" +
                    $"\nImpressive Feature: {car.MostImpressiveFeature}" +
                    $"\nTop Speed: {car.TopSpeedMPH} mph\n");
            }

            //The Car requested by SuperCarBuilder:
            //--------------------------------------
            //Horse Power: 1640
            //Impressive Feature: Can Fly
            //Top Speed: 600 mph

            //The Car requested by NotSuperCarBuilder:
            //--------------------------------------
            //Horse Power: 120
            //Impressive Feature: Has Air Conditioning
            //Top Speed: 70 mph
        }
    }
}