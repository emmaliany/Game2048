using System;

namespace game_2048.ui
{
    /// <summary>
    /// static class that all its methods print on screen
    /// </summary>
    public static class ConsoleOutput
    {
        /// <summary>
        /// print 2d array on screen
        /// </summary>
        /// <param name="board">print matrix on board</param>
        public static void PrintArray(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// check game status
        /// </summary>
        /// <param name="game">current game object</param>
        /// <returns>bool -> true - the game ended, false - current game still going</returns>
        public static bool DidGameEnd(Game game)
        {
            if (game.Status == Required.Enums.GameStatus.Lose)
            {
                Console.WriteLine("you lost the game!");
                return true;
            }

            if (game.Status == Required.Enums.GameStatus.Win)
            {
                Console.WriteLine("you won the game!");
                return true;
            }
            return false;
        }

        /// <summary>
        /// ask player if they want to start a new game
        /// </summary>
        /// <returns>bool -> true/false - if start a new game</returns>
        public static bool IsNewGame()
        {
            while (true)
            {
                Console.WriteLine("would you like to start a new game? Y/N");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "Y")
                {
                    return true;
                }
                if (choice.ToUpper() == "N")
                {
                    return false;
                }
                Console.WriteLine("answer is not valid, please try again.");
            }
        }

        /// <summary>
        /// exit program and print proper message on screen
        /// </summary>
        public static void ExitProgram()
        {
            Console.WriteLine("Ending game");
            System.Environment.Exit(0);
        }

        /// <summary>
        /// get from player his wanted move
        /// </summary>
        /// <returns>int -> plater's choice (move)</returns>
        public static int MoveChoice()
        {
            while (true)
            {
                Console.WriteLine("enter your move of choice\n\t1. up\n\t2. down\n\t3. left\n\t4. right\n\t5. quit");
                string move = Console.ReadLine();
                if (move != "1" && move != "2" && move != "3" && move != "4" && move != "5")
                {
                    Console.WriteLine("invalid answer, please try again");
                    continue;
                }
                return int.Parse(move)-1;
            }
        }
    }
}
