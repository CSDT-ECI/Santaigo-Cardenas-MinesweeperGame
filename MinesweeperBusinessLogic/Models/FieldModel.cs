using MinesweeperBusinessLogic.Interfaces;
using System;

namespace MinesweeperBusinessLogic.Models
{
    public class FieldModel : IFieldModel
    {
        private SquareModel[,] mineField { get; set; }
        private int rows { get; set; }
        private int cols { get; set; }

        private readonly SquareModel square = new SquareModel();

        /// <summary>
        /// Object Field
        /// </summary>
        /// <param name="rows">Total rows.</param>
        /// <param name="cols">Total cols.</param>
        /// <param name="squaresMatrix">Squares matrix.</param>
        public FieldModel(int rows, int cols, SquareModel[,] squaresMatrix)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.mineField = squaresMatrix;
        }

        /// <summary>
        /// An array with possible values:
        /// - "*" (mine);
        /// - positive number (the total mines around this square).
        /// </summary>
        public SquareModel[,] MineField
        {
            get
            {
                return this.mineField;
            }

            set
            {
                this.mineField = value;
            }
        }

        /// <summary>
        /// Total rows.
        /// </summary>
        public int Rows
        {
            get { return this.rows; }
            private set { this.rows = value; }
        }

        /// <summary>
        /// Total cols.
        /// </summary>
        public int Cols
        {
            get { return this.cols; }
            private set { this.cols = value; }
        }

        /// <summary>
        /// Checks if the move is in bounds.
        /// </summary>
        /// <param name="row">The row number in input.</param>
        /// <param name="col">The col number in input.</param>
        /// <returns>True if the move is in bounds and false otherwise.</returns>
        public bool checkBounds(int row, int col)
        {
            var result = (row >= 0) && (row < this.rows) && (col >= 0) && (col < this.cols);
            return result;
        }

        /// <summary>
        /// Counts the number of adjacent mines to a square and replace the dot character with this number. 
        /// </summary>
        /// <param name="row">Square row.</param>
        /// <param name="col">Square col.</param>
        /// <returns>The square value after replacing the dot characters</returns>
        public string adjacentsMines(int row, int col)
        {
            if (this.mineField[row, col].squareValue == this.square.dotValue)
            {
                int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
                int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
                int minesCounter = 0;

                for (int direction = 0; direction < directionRow.Length; direction++)
                {
                    int newRow = directionRow[direction] + row;
                    int newCol = directionCol[direction] + col;
                    if (this.checkBounds(newRow, newCol))
                    {
                        if (this.mineField[newRow, newCol].mineFound)
                        {
                            minesCounter++;
                        }
                    }
                }

                if (this.mineField[row, col].squareValue != this.square.mineValue)
                    this.mineField[row, col].squareValue = Convert.ToString(minesCounter);
            }
            return this.mineField[row, col].squareValue;
        }

        /// <summary>
        /// Sets default value of a field (dotValue).
        /// </summary>
        public void setDefaultFieldValue()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.mineField[i, j] = this.square;
                }
            }
        }

    }
}
