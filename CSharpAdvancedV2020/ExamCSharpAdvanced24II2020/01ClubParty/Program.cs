using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Stack<string> reservationData = new Stack<string>(Console.ReadLine().Split());
            Queue<char> halls = new Queue<char>();
            Queue<int> reservations = new Queue<int>();
                        
            while (reservationData.Count > 0)
            {               
                string currentData = reservationData.Peek();
                
                if (char.IsLetter(currentData[0]))
                {
                    halls.Enqueue(char.Parse(currentData));
                    reservationData.Pop();
                    continue;
                }

                if (halls.Count == 0)
                {
                    reservationData.Pop();
                    continue;
                }

                int reservationAmount = int.Parse(currentData);               
                int reservationsSum = reservations.Sum();
                if (capacity >= reservationsSum + reservationAmount)
                {                    
                    reservations.Enqueue(reservationAmount);
                    reservationData.Pop();
                }
                else 
                {                   
                    Console.WriteLine(halls.Dequeue() + " -> " + string.Join(", ", reservations));
                    reservations.Clear();                                      
                }                
            }
        }
    }
}