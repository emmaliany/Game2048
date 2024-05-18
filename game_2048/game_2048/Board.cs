using System;

namespace game_2048
{
    /// <summary>
    /// class that represent a board of game
    /// </summary>
    /// <properties>
    /// string[,] Data - string 2d array that represent a board
    /// </properties>
    public class Board
    {
        public string[,] Data { get; protected set; }

        /// <summary>
        /// ctor - this method create new board with initial values
        /// </summary>
        public Board()
        {
            Data = new string[9, 9];
            logic.BoardSetters.BuildBoard(Data);
            Startgame();
        }

        
        /// <summary>
        /// set 2 random cell with value of 2 or 4
        /// </summary>
        public void Startgame()
        {
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                int randomRow = random.Next(0, (Data.GetLength(0) - 1) / 2);
                randomRow = 2 * randomRow + 1;
                int randomCol = random.Next(0, (Data.GetLength(1) - 1) / 2);
                randomCol = 2 * randomCol + 1;
                Required.Enums.Cell randomCell = (Required.Enums.Cell)random.Next(0, 2);

                if (logic.BoardStatus.IsTaken(Data[randomRow, randomCol]))
                {
                    i--;
                    continue;
                }

                switch (randomCell)
                {
                    case Required.Enums.Cell.Two:
                        Data[randomRow, randomCol] = Required.Constants.TWO;
                        break;
                    case Required.Enums.Cell.Four:
                        Data[randomRow, randomCol] = Required.Constants.FOUR;
                        break;
                }
            }
        }

        /// <summary>
        /// move all the cells in the board to the wanted direction
        /// </summary>
        /// <param name="currentMove">what direction the board needs to move</param>
        /// <returns>int -> how many point this move earned</returns>
        public int Move(Required.Enums.Direction currentMove)
        {
            int points = 0;
            switch (currentMove)
            {
                case Required.Enums.Direction.Up:
                    points = logic.Movement.MoveUp(Data);
                    logic.BoardSetters.AddRandomCell(Data);
                    break;
                case Required.Enums.Direction.Down:
                    points = logic.Movement.MoveDown(Data);
                    logic.BoardSetters.AddRandomCell(Data);
                    break;
                case Required.Enums.Direction.Left:
                    points = logic.Movement.MoveLeft(Data);
                    logic.BoardSetters.AddRandomCell(Data);
                    break;
                case Required.Enums.Direction.Right:
                    points = logic.Movement.MoveRight(Data);
                    logic.BoardSetters.AddRandomCell(Data);
                    break;
                case Required.Enums.Direction.Quit:
                    ui.ConsoleOutput.ExitProgram();
                    break;
            }
            return points;
        }       
    }
}
