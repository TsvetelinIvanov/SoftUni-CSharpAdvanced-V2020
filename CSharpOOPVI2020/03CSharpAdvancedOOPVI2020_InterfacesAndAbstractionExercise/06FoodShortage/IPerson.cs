﻿namespace _06FoodShortage
{
    public interface IPerson : IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}