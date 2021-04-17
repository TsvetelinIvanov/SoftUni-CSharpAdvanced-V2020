using System;

namespace _05FootballTeamGenerator
{
    public class Player
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between {MinStatValue} and {MaxStatValue}.");
                }

                this.shooting = value;
            }
        }

        public double SkillLevel => (double)(this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5;
    }
}