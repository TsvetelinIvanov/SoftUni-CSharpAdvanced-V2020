using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating 
        { 
            get 
            { 
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return Math.Round(this.players.Average(p => p.SkillLevel)); 
            } 
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(player);
        }
    }
}