using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Game
{
    public class GameService
    {

        public int GetIntKeyDown(int min, int max,out bool isParsed)
        {
            int choice;
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice))
            {
                if (choice >= min && choice <= max)
                {
                    isParsed = true;
                }
                else
                {
                    isParsed = false;
                    choice = 0;
                }
            }
            else
            {
                isParsed = false;
                choice = 0;
            }
            return choice;
        }
    }
}
