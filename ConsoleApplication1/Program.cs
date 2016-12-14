using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> polandPlayers = new List<Player>() { new Player("Lewandowski", 5, 9) };

            Player player1 = new Player("Krychowiak", 1, 5);
            Player player2 = new Player("Wawrzyniak", 0, 0);
            Player player3 = new Player("Ronaldo", 8, 10);
            polandPlayers.Add(player1);
            polandPlayers.Add(player2);
            polandPlayers.Add(player3);

            IEnumerable<Player> playersWithGoals = PlayersWithGoals(polandPlayers);

            Player bestPlayer = playersWithGoals.OrderBy(x => x.Rate).LastOrDefault();

            polandPlayers.Remove(player2);

            Console.WriteLine(bestPlayer.Surname);

            
            int maxGoals = playersWithGoals.Max(x => x.Goals);
            Console.WriteLine("Najwieksza liczba bramek: " + maxGoals);

            int goalsSum = playersWithGoals.Sum(x => x.Goals);

            Console.WriteLine("Suma bramek: " + goalsSum);

        }

        static List<Player> PlayersWithGoals(List<Player> players)
        {
            List<Player> result = new List<Player>();

            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].Goals > 0)
                {
                    Console.WriteLine(players[i].Surname);
                    result.Add(players[i]);
                }
            }
            return result;
        }
    }

    public class Team
    {
        public string Name;
        public List<Player> Players;

        public Team(string name, List<Player> players)
        {
            this.Name = name;
            this.Players = players;
        }

    }

    public class Player
    {
        public string Surname;
        public int Goals;
        public int Rate;

        public Player(string surname, int goals, int rate)
        {
            this.Surname = surname;
            this.Goals = goals;
            this.Rate = rate;
        }
    }
}
