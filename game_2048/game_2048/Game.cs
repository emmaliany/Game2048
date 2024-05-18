namespace game_2048
{
    /// <summary>
    /// this class represents a 2048 Game
    /// <members>
    /// Board BoardGame - the board of the game
    /// Required.Enums.GameStatus Status - status of the game
    /// int Points - sum of points
    /// </members>
    /// </summary>
    public class Game
    {
        
        public Board BoardGame;
        public Required.Enums.GameStatus Status { get; protected set; }
        public int Points { get; protected set; }

        /// <summary>
        /// ctor - method that sets all the properties of current Game to a new game
        /// </summary>
        public Game()
        {
            BoardGame = new Board();
            Status = Required.Enums.GameStatus.Idle;
            Points = 0;
        }

        /// <summary>
        /// move boards cell according to param direction
        /// </summary>
        /// <param name="currentMove"> set the direction of board move</param>
        public void Move(Required.Enums.Direction currentMove)
        {
            Points += BoardGame.Move(currentMove);
            UpdateGameStatus();
        }

        /// <summary>
        /// check and update if needed the status of the game
        /// </summary>
        public void UpdateGameStatus()
        {
            
            for (int row = 1; row < BoardGame.Data.GetLength(0); row += 2)
            {
                for (int col = 1; col < BoardGame.Data.GetLength(1); col += 2)
                {
                    if (BoardGame.Data[row,col] == Required.Constants.WINNING_CELL)
                    {
                        Status = Required.Enums.GameStatus.Win;
                        return;
                    }
                }
            }

            if (logic.BoardStatus.IsPossibleMove(BoardGame.Data) == false)
            {
                Status = Required.Enums.GameStatus.Lose;
            }
        }

        
    }
}
