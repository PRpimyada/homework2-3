﻿using System;

class MainClass {
    static public void Main(String[] args)
    {
        while (true)
        {
            char operation = GetOperation("+ or -");
            if (!(operation == '+' || operation == '-'))
            {
                break;
            }

            int row = GetDimension("row");
            int column = GetDimension("column");

            float[,] matrixOne = ReadMatrixValues(row, column);
            float[,] matrixTwo = ReadMatrixValues(row, column);

            float[,] resultMatrix = PerformMatrixOperation(matrixOne, matrixTwo, operation);

            PrintMatrix(resultMatrix);
        }
    }

    static char GetOperation(string message)
    {
        Console.WriteLine($"Enter the operation ({message}):");
        return char.Parse(Console.ReadLine());
    }

    static int GetDimension(string dimension)
    {
        Console.WriteLine($"Enter the number of {dimension}s:");
        return int.Parse(Console.ReadLine());
    }

    static float[,] ReadMatrixValues(int row, int column)
    {
        float[,] matrix = new float[row, column];

        Console.WriteLine($"Enter the values for {row}x{column} matrix:");

        for (int i = 0; i < row; i++)
        {
            string[] values = Console.ReadLine().Split(' ');

            for (int j = 0; j < column; j++)
            {
                matrix[i, j] = float.Parse(values[j]);
            }
        }

        return matrix;
    }

    static float[,] PerformMatrixOperation(float[,] matrixOne, float[,] matrixTwo, char operation)
    {
        int row = matrixOne.GetLength(0);
        int column = matrixOne.GetLength(1);
        float[,] resultMatrix = new float[row, column];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                resultMatrix[i, j] = operation == '+' ? matrixOne[i, j] + matrixTwo[i, j] : matrixOne[i, j] - matrixTwo[i, j];
            }
        }

        return resultMatrix;
    }

    static void PrintMatrix(float[,] matrix)
    {
        int row = matrix.GetLength(0);
        int column = matrix.GetLength(1);

        Console.WriteLine("Result:");

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }

            Console.WriteLine();
        }
    }
}