using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DartsAssistant.Models
{
    public interface IGameManager
    {
        public List<Player> players { get; set; }
        public GameMode GameMode { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<int> CurrentThrows { get; set; }
        public void StartGame(GameMode gameMode, ESectorType checkout);
        public void NextThrow(int points);
        public void NextPlayer();
        public void EndGame();
    }
}
