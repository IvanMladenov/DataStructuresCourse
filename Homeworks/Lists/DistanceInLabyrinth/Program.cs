﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceInLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] labyrinth = new string[][]
            {
                new string[] {"0", "0", "0", "x", "0", "x" },
                new string[] {"0", "x", "0", "x", "0", "x" },
                new string[] {"0", "*", "x", "0", "x", "0" },
                new string[] {"0", "x", "0", "0", "0", "0" },
                new string[] {"0", "0", "0", "x", "x", "0" },
                new string[] {"0", "0", "0", "x", "0", "x" },
            };

            TraverseDFS(labyrinth, 2, 0, 1);
            Print(labyrinth);
        }

        static void TraverseDFS(string[][] matrix, int row, int col, int currentStep)
        {
            //Check if we are in matrix - bottom of recursion
            if (row < 0 || col < 0 || row == matrix.Length || col == matrix[row].Length)
            {
                return;
            }
            //Second condition - bottom
            if (matrix[row][col] == "x" || matrix[row][col] == "*")
            {
                return;
            }
            //Third condition - bottom
            if (int.Parse(matrix[row][col]) < currentStep && matrix[row][col] != "0")
            {
                return;
            }

            matrix[row][col] = currentStep.ToString();

            TraverseDFS(matrix, row, col + 1, currentStep+1); //Right
            TraverseDFS(matrix, row + 1, col, currentStep+1); //Bottom
            TraverseDFS(matrix, row, col - 1, currentStep+1); //Left
            TraverseDFS(matrix, row - 1, col, currentStep+1); //Up
        }

        static void Print(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
