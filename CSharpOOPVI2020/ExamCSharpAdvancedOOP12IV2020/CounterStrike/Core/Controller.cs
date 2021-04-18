using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            switch (type)
            {
                case nameof(Pistol):
                    gun = new Pistol(name, bulletsCount);
                    break;
                case nameof(Rifle):
                    gun = new Rifle(name, bulletsCount);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;
            switch (type)
            {
                case nameof(Terrorist):
                    player = new Terrorist(username, health, armor, gun);
                    break;
                case nameof(CounterTerrorist):
                    player = new CounterTerrorist(username, health, armor, gun);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
        }        

        public string StartGame()
        {
            IPlayer[] alivePlayers = this.players.Models.Where(p => p.IsAlive).ToArray();
            string winner = this.map.Start(alivePlayers);

            return winner;
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (IPlayer player in this.players.Models.OrderBy(p => p.GetType().Name).ThenByDescending(p => p.Health).ThenBy(p => p.Username))
            {
                reportBuilder.AppendLine(player.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}