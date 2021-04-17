using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputData = input.Split(';');
                try
                {
                    string command = inputData[0];
                    switch (command)
                    {
                        case "Team":
                            string teamName = inputData[1];
                            Team teamToAdding = new Team(teamName);
                            teams.Add(teamToAdding);
                            break;
                        case "Add":
                            string teamToAddingPlayerName = inputData[1];
                            Team teamToAddingPlayer = teams.FirstOrDefault(t => t.Name == teamToAddingPlayerName);
                            if (teamToAddingPlayer == null)
                            {
                                throw new ArgumentException($"Team {teamToAddingPlayerName} does not exist.");
                            }

                            string playerToAddingName = inputData[2];
                            int endurance = int.Parse(inputData[3]);
                            int sprint = int.Parse(inputData[4]);
                            int dribble = int.Parse(inputData[5]);
                            int passing = int.Parse(inputData[6]);
                            int shooting = int.Parse(inputData[7]);
                            Player playerToAdding = new Player(playerToAddingName, endurance, sprint, dribble, passing, shooting);
                            teamToAddingPlayer.AddPlayer(playerToAdding);
                            break;
                        case "Remove":
                            string teamToRemovingPlayerName = inputData[1];
                            Team teamToRemovingPlayer = teams.FirstOrDefault(t => t.Name == teamToRemovingPlayerName);
                            if (teamToRemovingPlayer == null)
                            {
                                throw new ArgumentException($"Team {teamToRemovingPlayerName} does not exist.");
                            }

                            string playerToRemovingName = inputData[2];
                            teamToRemovingPlayer.RemovePlayer(playerToRemovingName);
                            break;
                        case "Rating":
                            string teamToRatingName = inputData[1];
                            Team teamToRating = teams.FirstOrDefault(t => t.Name == teamToRatingName);
                            if (teamToRating == null)
                            {
                                throw new ArgumentException($"Team {teamToRatingName} does not exist.");
                            }                            

                            Console.WriteLine(teamToRating.Name + " - " + teamToRating.Rating);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}