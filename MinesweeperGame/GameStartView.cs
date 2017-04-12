using MinesweeperUILogic;

namespace MinesweeperConsoleApp
{
    public class GameStartView
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            IMinesweeperController game = new MinesweeperController();
            game.start();
        }
    }
}
