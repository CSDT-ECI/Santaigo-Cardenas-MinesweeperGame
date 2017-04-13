using System;

namespace MinesweeperBusinessLogic.Interfaces
{
    public interface IFieldValidator
    {
        bool CheckNumInRange(int num, int MIN_RANGE, int MAX_RANGE);

        SquareModel[,] checkSquaresMatrix(int N, int M);

        int[] checkRowsCols();

        void printMessage(String s);
    }
}
