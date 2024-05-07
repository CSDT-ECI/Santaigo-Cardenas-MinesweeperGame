# Testing Debt

Este proyecto no cuenta con pruebas por lo que ya se esta cumpliendo con deuda tecnica debido a test, es por esto que la recomendacion que se da es implementar test unitarios para las clases principales, el codigo al estar bien documentado y ser entendible no requiere gran complejidad de pruebas. Es por ello que se va a realizar la sugerencia de las pruebas unitarias para las clases FieldModel, FieldValidator y SquareModel cada una con sus respectivas funciones.

## FieldModel Test
```C#
using NUnit.Framework;
using MinesweeperBusinessLogic;

[TestFixture]
public class FieldModelTests
{
    [Test]
    public void CheckBounds_ValidInput_ReturnsTrue()
    {
        // Arrange
        var rows = 5;
        var cols = 5;
        var squaresMatrix = new SquareModel[rows, cols];
        var field = new FieldModel(rows, cols, squaresMatrix);

        // Act
        var result = field.checkBounds(3, 3);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckBounds_InvalidInput_ReturnsFalse()
    {
        // Arrange
        var rows = 5;
        var cols = 5;
        var squaresMatrix = new SquareModel[rows, cols];
        var field = new FieldModel(rows, cols, squaresMatrix);

        // Act
        var result = field.checkBounds(6, 6);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void AdjacentsMines_NoMines_ReturnsZero()
    {
        // Arrange
        var rows = 3;
        var cols = 3;
        var squaresMatrix = new SquareModel[rows, cols];
        var field = new FieldModel(rows, cols, squaresMatrix);

        // Act
        var result = field.adjacentsMines(1, 1);

        // Assert
        Assert.AreEqual("0", result);
    }

    [Test]
    public void AdjacentsMines_OneMine_ReturnsOne()
    {
        // Arrange
        var rows = 3;
        var cols = 3;
        var squaresMatrix = new SquareModel[rows, cols];
        squaresMatrix[0, 0].mineFound = true;
        var field = new FieldModel(rows, cols, squaresMatrix);

        // Act
        var result = field.adjacentsMines(1, 1);

        // Assert
        Assert.AreEqual("1", result);
    }

    [Test]
    public void SetDefaultFieldValue_AllSquaresSetToDefault()
    {
        // Arrange
        var rows = 3;
        var cols = 3;
        var squaresMatrix = new SquareModel[rows, cols];
        var field = new FieldModel(rows, cols, squaresMatrix);

        // Act
        field.setDefaultFieldValue();

        // Assert
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Assert.AreEqual(field.square, field.mineField[i, j]);
            }
        }
    }
}
```

## FieldValidator Test
```C#
using NUnit.Framework;
using MinesweeperBusinessLogic.Models;

[TestFixture]
public class FieldValidatorTests
{
    [Test]
    public void CheckRowsCols_ValidInput_ReturnsArray()
    {
        // Arrange
        var fieldValidator = new FieldValidator();
        var inputLine = "3 3";

        // Act
        var result = fieldValidator.checkRowsCols(inputLine);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Length);
        Assert.AreEqual(3, result[0]);
        Assert.AreEqual(3, result[1]);
    }

    [Test]
    public void CheckRowsCols_InvalidInput_ReturnsNull()
    {
        // Arrange
        var fieldValidator = new FieldValidator();
        var inputLine = "0 0";

        // Act
        var result = fieldValidator.checkRowsCols(inputLine);

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void CheckNumInRange_NumberInRange_ReturnsTrue()
    {
        // Arrange
        var fieldValidator = new FieldValidator();
        var num = 50;
        var minRange = 1;
        var maxRange = 100;

        // Act
        var result = fieldValidator.CheckNumInRange(num, minRange, maxRange);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckNumInRange_NumberOutOfRange_ReturnsFalse()
    {
        // Arrange
        var fieldValidator = new FieldValidator();
        var num = 101;
        var minRange = 1;
        var maxRange = 100;

        // Act
        var result = fieldValidator.CheckNumInRange(num, minRange, maxRange);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void CheckSquaresMatrix_ValidInput_ReturnsMatrix()
    {
        // Arrange
        var fieldValidator = new FieldValidator();
        var N = 3;
        var M = 3;
        var inputLines = new string[] { "...", "...", ".*." };

        // Act
        var result = fieldValidator.checkSquaresMatrix(N, M, inputLines);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(N, result.GetLength(0));
        Assert.AreEqual(M, result.GetLength(1));
        Assert.IsFalse(result[0, 0].mineFound);
        Assert.IsTrue(result[2, 1].mineFound);
    }

    [Test]
    public void CheckSquaresMatrix_InvalidInput_ThrowsException()
    {
        // Arrange
        var fieldValidator = new FieldValidator();
        var N = 3;
        var M = 3;
        var inputLines = new string[] { "...", "...", "..." };

        // Act & Assert
        Assert.Throws<Exception>(() => fieldValidator.checkSquaresMatrix(N, M, inputLines));
    }
}
```

## SquareModel Test
```C#
using NUnit.Framework;
using MinesweeperBusinessLogic;

[TestFixture]
public class SquareModelTests
{
    [Test]
    public void Clone_CreatesExactCopy()
    {
        // Arrange
        var originalSquare = new SquareModel();
        originalSquare.squareValue = originalSquare.mineValue;
        originalSquare.mineFound = true;

        // Act
        var clonedSquare = originalSquare.Clone();

        // Assert
        Assert.IsNotNull(clonedSquare);
        Assert.AreEqual(originalSquare.squareValue, clonedSquare.squareValue);
        Assert.AreEqual(originalSquare.mineFound, clonedSquare.mineFound);
    }
}
```