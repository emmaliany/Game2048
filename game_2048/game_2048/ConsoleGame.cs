using System;

namespace game_2048
{
    class ConsoleGame
    {
        /// <summary>
        /// this method keeps current game running until loss/win or if the player wants to quit
        /// </summary>
        public static void StartGame()
        {
            bool isKeepPlaying = true;

            while (isKeepPlaying)
            {
                Console.Clear();
                Console.WriteLine("stating game");
                Game game = new Game();
                ui.ConsoleOutput.PrintArray(game.BoardGame.Data);

                while (true)
                {
                    Console.WriteLine($"you have {game.Points} points");
                    int move = ui.ConsoleOutput.MoveChoice();

                    game.Move((Required.Enums.Direction)move);
                    ui.ConsoleOutput.PrintArray(game.BoardGame.Data);
                    Console.WriteLine();

                    if (ui.ConsoleOutput.DidGameEnd(game))
                    {
                        isKeepPlaying = ui.ConsoleOutput.IsNewGame();
                        break;
                    }
                }
            }
        }

              
    }
}
