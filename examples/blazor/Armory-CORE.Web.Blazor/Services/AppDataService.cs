using Armory_CORE.Web.Blazor.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Armory_CORE.Web.Blazor.Services
{
    public class Game
    {
        public GameType GameType { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }

    public class AppDataService
    {
        #region Game State

        private Game _selectedGame = null;
        public Game SelectedGame
        {
            get
            {
                return _selectedGame;
            }
            set
            {
                _selectedGame = value;
                foreach (var game in Games)
                {
                    game.Class = value == null ? null : (game != value ? "collapsed" : "expand");
                }

                Console.WriteLine("[INFO] Game changed.");

                NotifyStateChanged();
            }
        }
        public IEnumerable<Game> Games { get; set; } = new List<Game> {
            new Game { GameType = GameType.WoW, Slug = "wow", Name = "World of Warcraft"},
            new Game { GameType = GameType.D3, Slug = "d3", Name = "Diablo III"},
            new Game { GameType = GameType.SC2, Slug = "sc2", Name = "StarCraft II" },
        };

        public void SelectGameByType(GameType gameType)
        {
            SelectedGame = Games.FirstOrDefault(q => q.GameType == gameType);
        }

        #endregion

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
