﻿using System;
using EloWeb.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace EloWeb.Tests.UnitTests
{
    public class GamesTests
    {
        [Test]
        public void CanPersistAndRetrieveAGame()
        {
            var game = new Game {Winner = "A", Loser = "B"};

            var gameString = game.Serialize();
            var recreatedGame = Game.Deserialize(gameString);

            Assert.AreEqual(game, recreatedGame);
        }

        [Test]
        public void CanAddAGameToTheList()
        {
            var games = new List<Game>
            {
                new Game {Winner = "A", Loser = "B"},
                new Game {Winner = "A", Loser = "C"},
                new Game {Winner = "B", Loser = "C"},
            };

            Games.Initialise(games);

            Assert.AreEqual(games, Games.All);
        }

        [Test]
        public void CanRetrieveNMostRecentGames()
        {
            var game1 = new Game {Winner = "A", Loser = "B"};
            var game2 = new Game {Winner = "A", Loser = "C"};
            var game3 = new Game {Winner = "B", Loser = "C"};

            Games.Initialise(new[] {game1, game2, game3});

            var expected = new List<Game>
            {
                game2,
                game3
            };

            Assert.AreEqual(expected, Games.MostRecent(2, Games.GamesSortOrder.MostRecentLast));
        }

        [Test]
        public void CanRetrieveGamesPlayedByAParticularPlayer()
        {
            var game1 = new Game { Winner = "A", Loser = "B" };
            var game2 = new Game { Winner = "A", Loser = "C" };
            var game3 = new Game { Winner = "B", Loser = "C" };

            Games.Initialise(new[] { game1, game2, game3 });

            var expected = new List<Game>
            {
                game2,
                game3
            };

            var player = new Player("C");

            Assert.AreEqual(expected, Games.ByPlayer(player));
        }
    }
}
