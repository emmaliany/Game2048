using System.Text.RegularExpressions;

namespace game_2048.logic
{
    /// <summary>
    /// static class with methods that move the boards
    /// </summary>
    public static class Movement
    {

        /// <summary>
        /// move all the cells up in board, commit additions if in need and count earned points from the move
        /// </summary>
        /// <param name="data">board game</param>
        /// <returns>int -> points from current move</returns>
        public static int MoveUp(string[,] data)
        {
            int points = 0;
            for (int col = 1; col < data.GetLength(1); col += 2)
            {
                for (int row = 3; row < data.GetLength(0); row += 2)
                {
                    int beforeRow = row - 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)  // if cell doesn't contains a number
                    {
                        continue;
                    }
                    while (beforeRow > 0) // go back in rows
                    {
                        if (data[beforeRow, col] == Required.Constants.EMPTY)  // when the cell before is empty
                        {
                            data[beforeRow, col] = SetPadding(data[row, col]);
                            data[row, col] = Required.Constants.EMPTY;
                            beforeRow -= 2;
                            row -= 2;
                            continue;
                        }
                        if (data[beforeRow, col] == data[row, col])  // when the cell before has the same number as current cell
                        {
                            int value = int.Parse(data[row, col]) * 2;
                            points += value;
                            data[beforeRow, col] = SetPadding(value.ToString()) + "changed";  //sign that the cell is from new addition
                            data[row, col] = Required.Constants.EMPTY;
                            break;
                        }
                        if (data[beforeRow, col] != data[row, col])  // when the cell before has a different number
                        {
                            break;
                        }
                    }
                }
            }
            logic.BoardSetters.RemoveChanged(data);
            return points;
        }

        /// <summary>
        /// move all the cells down in board, commit additions if in need and count earned points from the move
        /// </summary>
        /// <param name="data">board game</param>
        /// <returns>int -> points from current move</returns>
        public static int MoveDown(string[,] data)
        {
            int points = 0;
            for (int col = 1; col < data.GetLength(1); col += 2)
            {
                for (int row = data.GetLength(0) - 4; row > 0; row -= 2)
                {
                    int afterRow = row + 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)  // if cell doesn't contains a number
                    {
                        continue;
                    }
                    while (afterRow < data.GetLength(0))
                    {
                        if (data[afterRow, col] == Required.Constants.EMPTY)  // when the cell after is empty
                        {
                            data[afterRow, col] = SetPadding(data[row, col]);
                            data[row, col] = Required.Constants.EMPTY;
                            afterRow += 2;
                            row += 2;
                            continue;
                        }
                        if (data[afterRow, col] == data[row, col])  // when the cell after has the same number as current cell
                        {
                            int value = int.Parse(data[row, col]) * 2;
                            points += value;
                            data[afterRow, col] = SetPadding(value.ToString()) + "changed";  //sign that the cell is from new addition
                            data[row, col] = Required.Constants.EMPTY;
                            break;
                        }
                        if (data[afterRow, col] != data[row, col])  // when the cell after has a different number
                        {
                            break;
                        }
                    }
                }
            }
            logic.BoardSetters.RemoveChanged(data);
            return points;
        }

        /// <summary>
        /// move all the cells to the left in board, commit additions if in need and count earned points from the move
        /// </summary>
        /// <param name="data">board game</param>
        /// <returns>int -> points from current move</returns>
        public static int MoveLeft(string[,] data)
        {
            int points = 0;
            for (int row = 1; row < data.GetLength(0); row += 2)
            {
                for (int col = 3; col < data.GetLength(1); col += 2)
                {
                    int beforeCol = col - 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)  // if cell doesn't contains a number
                    {
                        continue;
                    }
                    while (beforeCol > 0)
                    {
                        if (data[row, beforeCol] == Required.Constants.EMPTY)  // when the cell before is empty
                        {
                            data[row, beforeCol] = SetPadding(data[row, col]);
                            data[row, col] = Required.Constants.EMPTY;
                            beforeCol -= 2;
                            col -= 2;
                            continue;
                        }
                        if (data[row, beforeCol] == data[row, col])  // when the cell before has the same number as current cell
                        {
                            int value = int.Parse(data[row, col]) * 2;
                            points += value;
                            data[row, beforeCol] = SetPadding(value.ToString()) + "changed"; //sign that the cell is from new addition
                            data[row, col] = Required.Constants.EMPTY;
                            break;
                        }
                        if (data[row, beforeCol] != data[row, col])  // when the cell before has a different number
                        {
                            break;
                        }
                    }
                }
            }
            logic.BoardSetters.RemoveChanged(data);
            return points;
        }

        /// <summary>
        /// move all the cells to the right in board, commit additions if in need and count earned points from the move
        /// </summary>
        /// <param name="data">board game</param>
        /// <returns>int -> points from current move</returns>
        public static int MoveRight(string[,] data)
        {
            int points = 0;
            for (int row = 1; row < data.GetLength(0); row += 2)
            {
                for (int col = data.GetLength(1) - 4; col > 0; col -= 2)
                {
                    int afterCol = col + 2;
                    if (Regex.IsMatch(data[row, col], @"\d") == false)  // if cell doesn't contains a number
                    {
                        continue;
                    }
                    while (afterCol < data.GetLength(1))
                    {
                        if (data[row, afterCol] == Required.Constants.EMPTY) // when the cell after is empty
                        {
                            data[row, afterCol] = SetPadding(data[row, col]);
                            data[row, col] = Required.Constants.EMPTY;
                            afterCol += 2;
                            col += 2;
                            continue;
                        }
                        if (data[row, afterCol] == data[row, col]) // when the cell after has the same number as current cell
                        {
                            int value = int.Parse(data[row, col]) * 2;
                            points += value;
                            data[row, afterCol] = SetPadding(value.ToString()) + "changed"; //sign that the cell is from new addition
                            data[row, col] = Required.Constants.EMPTY;
                            break;
                        }
                        if (data[row, afterCol] != data[row, col])  // when the cell before has a different number
                        {
                            break;
                        }
                    }
                }
            }
            logic.BoardSetters.RemoveChanged(data);
            return points;
        }

        /// <summary>
        /// set " " padding to string for it to be in length of 4 characters
        /// </summary>
        /// <param name="toPad">the string that needs padding</param>
        /// <returns>param string with padding</returns>
        private static string SetPadding(string toPad)
        {
            if (toPad.Length == 1)
            {
                toPad = toPad + "   ";
            }
            else if (toPad.Length == 2)
            {
                toPad = toPad + "  ";
            }
            else if (toPad.Length == 3)
            {
                toPad = toPad + " ";
            }
            return toPad;
        }

    }
}
