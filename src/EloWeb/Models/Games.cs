﻿using System.Collections.Generic;
using System.Linq;

namespace EloWeb.Models
{
    public class Games
    {
        public enum GamesSortOrder
        {
            MostRecentFirst = 1,
            MostRecentLast = 2
        }

        private static List<Game> _games = new List<Game>();

        public static void Initialise(IEnumerable<string> games)
        {
            _games = games.Select(Game.FromString).ToList();
        }

        public static void Add(Game game)
        {
            _games.Add(game);
        }

        public static IEnumerable<Game> All()
        {
            return _games.AsEnumerable();
        }

        public static IEnumerable<Game> MostRecent(int howMany, GamesSortOrder sortOrder)
        {
            var games = _games.AsEnumerable()
                .Reverse()
                .Take(howMany);

            if (sortOrder == GamesSortOrder.MostRecentLast)
                return games.Reverse();

            return games;
        }

        public static IEnumerable<Game> GamesByPlayer(string name)
        {
            return _games.Where(game => game.Winner == name || game.Loser == name);
        }

        public static IEnumerable<Game> WinsByPlayer(string name)
        {
            return _games.Where(game => game.Winner == name);
        }

        public static IEnumerable<Game> LossesByPlayer(string name)
        {
            return _games.Where(game => game.Loser == name);
        }
    }
}