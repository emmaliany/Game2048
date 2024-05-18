using System.Text.RegularExpressions;

namespace game_2048.logic
{
    public static class BoardStatus
    {
        /// <summary>
        /// check if cell is used
        /// </summary>
        /// <param name="cell">cell that the function check</param>
        /// <returns>bool -> true/false if cell is taken</returns>
        public static bool IsTaken(string cell)
        {
            return Regex.IsMatch(cell, @"^\d+$");
        }

        /// <summary>
        /// check if that are any possible moves
        /// </summary>
        /// <param name="data">game board</param>
        /// <returns>bool -> true/false if that are any possible moves</returns>
        public static bool IsPossibleMove(string[,] data)
        {
            return IsMoveUp(data)||IsMoveDown(data)||IsMoveLeft(data)||IsMoveRight(data);
        }

        /// <summary>
        /// check if the board can to a move up
        /// </summary>
        /// <param name="data">game board</param>
        /// <returns>bool -> true/false if up is a possible movement</returns>
        private static bool IsMoveUp(string[,] data)
        {
            for (int col = 1; col < data.GetLength(1); col += 2)
            {
                for (int row = 3; row < data.GetLength(0); row += 2)
                {
                    int beforeRow = row - 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)
                    {
                        continue;
                    }
                    while (beforeRow > 0)
                    {
                        if (data[beforeRow, col] == Required.Constants.EMPTY)
                        {
                            return true;
                        }
                        if (data[beforeRow, col] == data[row, col])
                        {
                            return true;
                        }
                        if (data[beforeRow, col] != data[row, col])
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// check if the board can to a move down
        /// </summary>
        /// <param name="data">game board</param>
        /// <returns>bool -> true/false if down is a possible movement</returns>
        private static bool IsMoveDown(string[,] data)
        {
            for (int col = 1; col < data.GetLength(1); col += 2)
            {
                for (int row = data.GetLength(0) - 4; row > 0; row -= 2)
                {
                    int afterRow = row + 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)
                    {
                        continue;
                    }
                    while (afterRow < data.GetLength(0))
                    {
                        if (data[afterRow, col] == Required.Constants.EMPTY)
                        {
                            return true;
                        }
                        if (data[afterRow, col] == data[row, col])
                        {
                            return true;
                        }
                        if (data[afterRow, col] != data[row, col])
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// check if the board can to a move left
        /// </summary>
        /// <param name="data">game board</param>
        /// <returns>bool -> true/false if left is a possible movement</returns>
        private static bool IsMoveLeft(string[,] data)
        {
            for (int row = 1; row < data.GetLength(0); row += 2)
            {
                for (int col = 3; col < data.GetLength(1); col += 2)
                {
                    int beforeCol = col - 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)
                    {
                        continue;
                    }
                    while (beforeCol > 0)
                    {
                        if (data[row, beforeCol] == Required.Constants.EMPTY)
                        {
                            return true;
                        }

                        if (data[row, beforeCol] == data[row, col])
                        {
                            return true;
                        }
                        if (data[row, beforeCol] != data[row, col])
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// check if the board can to a move right
        /// </summary>
        /// <param name="data">game board</param>
        /// <returns>bool -> true/false if right is a possible movement</returns>
        private static bool IsMoveRight(string[,] data)
        {
            for (int row = 1; row < data.GetLength(0); row += 2)
            {
                for (int col = data.GetLength(1) - 4; col > 0; col -= 2)
                {
                    int afterCol = col + 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)
                    {
                        continue;
                    }
                    while (afterCol < data.GetLength(1))
                    {
                        if (data[row, afterCol] == Required.Constants.EMPTY)
                        {
                            return true;
                        }

                        if (data[row, afterCol] == data[row, col])
                        {
                            return true;
                        }
                        if (data[row, afterCol] != data[row, col])
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
