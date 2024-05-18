using System;
using System.Collections.Generic;
using System.Linq;

namespace game_2048.logic
{
    public static class BoardSetters
    {
        /// <summary>
        /// set param board (data) as a new board with borders
        /// </summary>
        /// <param name="data">2d array that this function sets its borders</param>
        public static void BuildBoard(string[,] data)
        {
            // set default value ' ' on board
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = Required.Constants.EMPTY;
                }

            }

            // set board's borders
            for (int row = 1; row < data.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < data.GetLength(1); col += 2)
                {
                    data[row, col] = "|";
                }

            }
            for (int col = 0; col < data.GetLength(1); col++)
            {
                for (int row = 0; row < data.GetLength(0); row += 2)
                {
                    if ((row == 0 || row == data.GetLength(0) - 1 || col == 0 || col == data.GetLength(0) - 1) && col % 2 == 0)
                    {
                        data[row, col] = "-";
                    }
                    else if (col % 2 == 0)
                    {
                        data[row, col] = "+";
                    }
                    else
                    {
                        data[row, col] = "----";
                    }
                }
            }
        }

        /// <summary>
        /// add random cell to a random empty spot in param array
        /// </summary>
        /// <param name="data">2d array that represnt a board</param>
        public static void AddRandomCell(string[,] data)
        {

            Dictionary<int, int> openSpots = FindEmptySpots(data);

            if (openSpots.Count() == 0)
            {
                return;
            }
            Random random = new Random();
            int chosenRow = random.Next(0, openSpots.Count());
            int chosenCol = random.Next(0, openSpots[chosenRow]);
            bool isOpenRow = false;

            for (int row = 1; row < data.GetLength(0); row += 2)
            {
                for (int col = 1; col < data.GetLength(1); col += 2)
                {
                    if (data[row, col] == Required.Constants.EMPTY)
                    {
                        if (chosenRow == 0 && chosenCol == 0)
                        {
                            data[row, col] = RandomNumber();
                            return;
                        }
                        if (chosenRow == 0)
                        {
                            chosenCol--;
                        }
                        isOpenRow = true;
                    }
                }
                chosenRow = isOpenRow ? chosenRow - 1 : chosenRow;
            }
        }

        /// <summary>
        /// create a dictionary of open spots: {row, how many empty cell in row}...
        /// </summary>
        /// <param name="data">2d array that is a board</param>
        /// <returns>dictionary of open spots</returns>
        private static Dictionary<int, int> FindEmptySpots(string[,] data)
        {
            int inOrderRow = 0;
            Dictionary<int, int> openSpots = new Dictionary<int, int>();
            for (int row = 1; row < data.GetLength(0); row += 2)
            {
                for (int col = 1; col < data.GetLength(1); col += 2)
                {
                    if (data[row, col] == Required.Constants.EMPTY)
                    {
                        if (openSpots.ContainsKey(inOrderRow))
                        {
                            openSpots[inOrderRow]++;
                        }
                        else
                        {
                            openSpots.Add(inOrderRow, 1);
                        }
                    }
                }
                if (openSpots.ContainsKey(inOrderRow))
                {
                    inOrderRow++;
                }
            }
            return openSpots;
        }

        /// <summary>
        /// choose random number
        /// </summary>
        /// <returns>string -> random number as a string</returns>
        private static string RandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 2) == 0 ? Required.Constants.TWO : Required.Constants.FOUR;
        }

        /// <summary>
        /// remove the word "changed" from all cells in board
        /// </summary>
        /// <param name="data">2d array</param>
        public static void RemoveChanged(string[,] data)
        {
            for (int row = 1; row < data.GetLength(0); row += 2)
            {
                for (int col = 1; col < data.GetLength(1); col += 2)
                {
                    if (data[row, col].Contains("changed"))
                    {
                        data[row, col] = data[row, col].Replace("changed", "");
                    }
                }
            }
        }
    }
}
