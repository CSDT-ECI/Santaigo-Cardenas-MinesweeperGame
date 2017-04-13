namespace MinesweeperBusinessLogic.Interfaces
{
    public interface IFieldModel
    {
        SquareModel[,] MineField { get; set; }

        int Rows { get; }

        int Cols { get;  }

        bool checkBounds(int row, int col);

        string adjacentsMines(int row, int col);

        void setDefaultFieldValue();
    }
}
