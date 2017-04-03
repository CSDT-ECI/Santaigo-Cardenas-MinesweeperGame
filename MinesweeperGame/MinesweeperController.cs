using System;
using System.Collections.Generic;
using MinesweeperBusinessLogic;
using MinesweeperBusinessLogic.Interfaces;
using MinesweeperBusinessLogic.Models;

namespace MinesweeperUILogic
{
    public class MinesweeperController : IMinesweeperController
    {
        private List<IFieldModel> fieldModel;

        private IFieldValidator fieldValidator;

        /// <summary>
        ///  Game start.
        /// </summary>
        public void start()
        {

            int fieldsEntered = 0;

            int[] rowsCols = null;

            SquareModel[,] squaresMatrix = null;

            fieldModel = new List<IFieldModel>();

            fieldValidator = new FieldValidator();

            // INPUT

            // check if rows and cols choosed by user are valid
            while ((rowsCols = fieldValidator.checkRowsCols()) != null)
            {
                fieldsEntered++;

                int n = rowsCols[0];
                int m = rowsCols[1];

                // create squaresMatrix 
                squaresMatrix = new SquareModel[n, m];

                // validate fields and fill the squares matrix
                if ((squaresMatrix = fieldValidator.checkSquaresMatrix(n, m)) != null)
                {
                    // fill and append the field to the list
                    this.fieldModel.Add(new FieldModel(n, m, squaresMatrix));
                }

            }

            // OUTPUT

            // read all fields and update these (that not contains a mine) with the number of mines around a square  
            int fieldNum = 0;
            while (fieldNum < fieldsEntered)
            {

                IFieldModel curFieldModel = this.fieldModel[fieldNum];

                Console.WriteLine();
                fieldNum++;
                fieldValidator.printMessage(MessageModel.FIELD_NUMBER + fieldNum);

                for (int i = 0; i < curFieldModel.Rows; i++)
                {
                    for (int j = 0; j < curFieldModel.Cols; j++)
                    {
                        Console.Write(curFieldModel.adjacentsMines(i, j).ToString());
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine(MessageModel.PRESS_ANY_KEY_TO_EXIT);
            Console.ReadKey();
        }

    }
}
