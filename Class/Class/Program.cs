using System;
using System.Collections.Generic;
namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            results();
            var Barce = Barca();
            Team Barcelona = new Team("Barcelona", Barce);
            var Madrid = MadridRe();
            Team Real = new Team("Real", Madrid);
            // List<Team> team = new List<Team>() { };
            Match ElClasico = new Match(Barcelona, Real, "27.03.2018", "5-5");
            ElClasico.SaveMatch(ElClasico.Home, ElClasico.Away, ElClasico.Time, ElClasico.Raxunok);
            Console.WriteLine(ElClasico.ToString());

            Console.WriteLine(Barcelona.ToString());
            foreach (var symon in Barce)
                Console.WriteLine(symon.ToString());
            Console.WriteLine(Real.ToString());
            foreach (var symon in Madrid)
                Console.WriteLine(symon.ToString());
            Console.ReadKey();
        }
        static List<Match> results()
        {
            var res = new List<Match> { };
            return res;
        }
        static List<Player> Barca()
        {
            var gg = new List<Player> { };
            gg.Add(new Player("TerShtehen"));
            gg.Add(new Player("Umtiti"));
            gg.Add(new Player("Pique"));
            gg.Add(new Player("Denis Suares"));
            gg.Add(new Player("Jordi Alba"));
            gg.Add(new Player("Sergio Buskets"));
            gg.Add(new Player("Andreas Inesta"));
            gg.Add(new Player("Ivan Rakitic"));
            gg.Add(new Player("Lionel Messi"));
            gg.Add(new Player("Luis Suares"));
            gg.Add(new Player("Philippe Countinho"));
            return gg;
        }
        static List<Player> MadridRe()
        {
            var gg = new List<Player> { };
            gg.Add(new Player("Player1"));
            gg.Add(new Player("Player2"));
            gg.Add(new Player("Player3"));
            gg.Add(new Player("Player4"));
            gg.Add(new Player("Player5"));
            gg.Add(new Player("Player6"));
            gg.Add(new Player("Player7"));
            gg.Add(new Player("Player8"));
            gg.Add(new Player("Player9"));
            gg.Add(new Player("Player10"));
            gg.Add(new Player("Player11"));
            return gg;
            //}
            //foreach(var symon in results)
            //    Console.WriteLine(results);
        }
        class Team
        {
            private List<Player> playerlist;
            string name;
            public string Name
            {
                set { name = value; }
                get { return name; }
            }
            public List<Player> PlayerList
            {
                set { playerlist = value; }
                get { return playerlist; }
            }

            public Team(string name, List<Player> playerlist)
            {
                this.playerlist = new List<Player> { };
                Name = name;
            }
            public override string ToString()
            {
                return "Team :" + Name;
            }
        }
        class Match
        {
            private List<Match> results;
            private string raxunok;
            private string time;
            private Team home;
            private Team away;
            public Team Home
            {
                set { home = value; }
                get { return home; }
            }
            public Team Away
            {
                set { away = value; }
                get { return away; }
            }
            public string Raxunok
            {
                set { raxunok = value; }
                get { return raxunok; }
            }
            public List<Match> Results
            {
                set { results = value; }
                get { return results; }
            }
            public string Time
            {
                set { time = value; }
                get { return time; }
            }
            public Match(Team home, Team away, string time, string raxunok)
            {
                Time = time;
                Raxunok = raxunok;
                Away = away;
                Home = home;
                Results = new List<Match>();
            }
            public override string ToString()
            {
                return Home + "-" + Away + "  " + Raxunok + "  " + Time;
            }
            public void SaveMatch(Team home, Team away, string time, string raxunok)
            {
                results.Add(new Match(home, away, time, raxunok));
            }
        }
        class Player
        {
            string fullname;
            public string FullName
            {
                set { fullname = value; }
                get { return fullname; }
            }
            public Player(string fullname)
            {
                FullName = fullname;
            }
            public override string ToString()
            {
                return "Player's name :" + FullName;
            }
        }
    }
}