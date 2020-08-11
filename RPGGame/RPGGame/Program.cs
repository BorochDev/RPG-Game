using RPGGame.Game;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace RPGGame
{
    class Program
    {
        static void Main()
        {
            GameScreen Game = new GameScreen();
            Game.Start();
        }
    }
}
