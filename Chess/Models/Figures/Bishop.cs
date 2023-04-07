namespace Chess.Models
{
    public class Bishop : IChess
    {
        public int PosX { get; set; }

        public int PosY { get; set; }

        public Bishop(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
        }

        /// <summary>
        ///     List contatining all allowed moves that Bishop can do.
        /// </summary>
        private readonly List<Tuple<int, int>> AllowedMovePatterns = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(-1, -1),
            new Tuple<int, int> (-1, 1),
            new Tuple<int, int> (1, -1),
            new Tuple<int, int> (1, 1)
        };

        /// <summary>
        ///     Returns a list of all Fields to which Bishop can go based on current position.
        /// </summary>
        /// <returns>List<IField></returns>
        public List<IField> GetAvailablePositions()
        {
            foreach (Tuple<int, int> Pattern in AllowedMovePatterns)
            {

            }

            return new List<IField>();
        }
    }
}
