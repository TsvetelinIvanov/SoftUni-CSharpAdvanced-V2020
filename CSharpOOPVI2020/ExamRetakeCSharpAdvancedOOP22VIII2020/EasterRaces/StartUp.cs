﻿using EasterRaces.Core.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}