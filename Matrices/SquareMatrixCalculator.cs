using System;

namespace Matrices
{
    public static class SquareMatrixCalculator
    {
        public static int SumLeftDiagonal(this int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
                throw new ArgumentException("Matrix should be square.");

            var sum = 0;
            int height;
            int width = height = matrix.GetLength(0);
            
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            return sum;
        }

        public static int SumRightDiagonal(this int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
                throw new ArgumentException("Matrix should be square.");

            var sum = 0;
            int height;
            int width = height = matrix.GetLength(0);

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (i + j == width - 1)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            return sum;
        }

        private static bool IsSquareMatrix(int[,] matrix)
        {
            return matrix.Rank == 2 && matrix.GetLength(0) == matrix.GetLength(1);
        }
    }
}