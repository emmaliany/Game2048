namespace game_2048.Required
{
    /// <summary>
    /// all enums in this project
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// enum that represent moves options in 2048 game
        /// </summary>
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Quit
        }

        /// <summary>
        /// enum that represent all statuses a game could have
        /// </summary>
        public enum GameStatus
        {
            Win,
            Lose,
            Idle
        }

        /// <summary>
        /// enum that represent all new cells options
        /// </summary>
        public enum Cell
        {
            Two,
            Four
        }
    }
}
