using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.Count)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player removedPlayer = this.roster.FirstOrDefault(p => p.Name == name);
            if (removedPlayer == null)
            {
                return false;
            }

            this.roster.Remove(removedPlayer);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name && p.Rank != "Member");
            player.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name && p.Rank != "Trial");
            player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] removedPlayers = this.roster.Where(p => p.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);

            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder("Players in the guild: " + this.Name + Environment.NewLine + string.Join(Environment.NewLine, this.roster.Select(p => p.ToString().Trim())));            

            return reportBuilder.ToString().Trim();
        }
    }
}
