using MinesweeperBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperBusinessLogic.Models
{
    public class FieldValidator : IFieldValidator
    {

        /// <summary>
        /// Checks if rows and cols choosed by user are valid.
        /// </summary>
        /// <param name="inputArgs">Input arguments</param>
        /// <returns>Array that holds the rows and colums or null if the input arguments are invalid.</returns> 
        public int[] checkRowsCols()
        {

            int[] rowsCols = null;

            int rows, cols;
            rows = cols = 0;

            // read the line from user input
            string inputLine = Console.ReadLine();

            // splits line on spaces
            string[] inputArgs = inputLine.Split(' ');

            // check null or length input arguments (the numbers must be two)
            if (inputArgs == null || inputArgs.Length != 2)
            {
                printMessage(MessageModel.INVALID_ARGUMENTS_NUMBER);
                printMessage(MessageModel.PRESS_ANY_KEY_TO_EXIT);
                Environment.Exit(0);
            }

            // check if arguments are:
            // - effective integer;
            // - greater than zero;
            // - in the range specified.
            else if (Int32.TryParse(inputArgs[0], out rows) && Int32.TryParse(inputArgs[1], out cols))
            {
                if ((rows < 0 || cols < 0) && CheckNumInRange(rows, 1, 100) && CheckNumInRange(cols, 1, 100))
                {
                    printMessage(MessageModel.INVALID_NUMBERS_RANGE);
                    printMessage(MessageModel.PRESS_ANY_KEY_TO_EXIT);
                    Environment.Exit(0);
                }
                else if (rows == 0 && cols == 0)
                {
                    return null;
                }
                else
                {
                    rowsCols = new int[2];
                    rowsCols[0] = rows;
                    rowsCols[1] = cols;
                }

            }

            // all other cases (i.e. invalid input format...)
            else
            {
                printMessage(MessageModel.INVALID_INPUT_ARGUMENTS);
                printMessage(MessageModel.PRESS_ANY_KEY_TO_EXIT);
                Environment.Exit(0);
            }

            return rowsCols;
        }

        /// <summary>
        /// Checks if the number falls in the range specified.
        /// </summary>
        /// <param name="num">A number tochecked</param>
        /// <param name="minRange">Minimum range number</param>
        /// <param name="maxRange">Maximum range number</param>
        /// <returns>True if the number falls in the given range, false otherwise</returns>
        public bool CheckNumInRange(int num, int minRange, int maxRange)
        {
            bool result = true;
            if (num < minRange || num > maxRange)
            {
                printMessage(MessageModel.INVALID_NUMBERS_RANGE);
                printMessage(MessageModel.PRESS_ANY_KEY_TO_EXIT);
                return false;
            }
            return result;
        }

        /// <summary>
        /// Checks if the squares choosed by user are valid and, in this case, fills the matrix.
        /// </summary>
        /// <param name="rows">Rows to read from user input</param>
        /// <param name="cols">Cols to read from user input</param>
        /// <returns>Matrix that holds all squares entered or null if they are invalid.</returns>
        public SquareModel[,] checkSquaresMatrix(int N, int M)
        {
            SquareModel[,] squaresMatrixInput = new SquareModel[N, M];

            int i, j;
            i = j = 0;

            while (i < N)
            {
                // read the line from user input
                string inputLine = Console.ReadLine();
                // if the line is null or not contains rows characters exit
                if (inputLine == null || inputLine.Length != M)
                {
                    printMessage(MessageModel.INVALID_INPUT_ARGUMENTS);
                    printMessage(MessageModel.PRESS_ANY_KEY_TO_EXIT);
                    Environment.Exit(0);
                }
                // read each character and store it in fields matrix
                while (j < M)
                {
                    bool isDotValue = inputLine[j].Equals('.');
                    bool isMineValue = inputLine[j].Equals('*');

                    if (!isDotValue && !isMineValue)
                    {

                        printMessage(MessageModel.INVALID_INPUT_FIELDS);
                        printMessage(MessageModel.PRESS_ANY_KEY_TO_EXIT);
                        Environment.Exit(0);
                    }

                    // fill the fields matrix
                    squaresMatrixInput[i, j] = new SquareModel();

                    if (isMineValue)
                    {
                        squaresMatrixInput[i, j].mineFound = true;
                    }
                    squaresMatrixInput[i, j].squareValue = inputLine[j].ToString();
                    j++;
                }
                i++;
                j = 0;
            }
            return squaresMatrixInput;
        }

        /// <summary>
        /// Print a given message.
        /// </summary>
        /// <param name="s">The messate to print</param>
        public void printMessage(String s)
        {
            Console.WriteLine(s);
            if (s.Equals(MessageModel.PRESS_ANY_KEY_TO_EXIT))
                Console.ReadKey();
        }

    }
}
