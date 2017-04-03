namespace MinesweeperBusinessLogic
{

    public class SquareModel
    {

        public string dotValue = ".";

        public string mineValue = "*";

        public bool mineFound { get; set; }

        public string squareValue { get; set; }

        /// <summary>
        /// Object Square.
        /// </summary>
        public SquareModel()
        {
            this.squareValue = dotValue;
            this.mineFound = false;
        }

        /// <summary>
        /// Create a copy of references to an object Square.
        /// </summary>
        public SquareModel Clone()
        {
            return this.MemberwiseClone() as SquareModel;
        }

    }
}
