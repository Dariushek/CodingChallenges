using FluentAssertions;
using Xunit;

namespace Matrices
{
    public class DiagonalSummationTests
    {
        [Fact]
        public void SumLeftDiagonalReturnsSumOfAllElementsOnLeftMatrixDiagonal()
        {
            var matrix = new[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            int sum = matrix.SumLeftDiagonal();

            sum.Should().Be(15);
        }

        [Fact]
        public void SumRightDiagonalReturnsSumOfAllElementsOnRightMatrixDiagonal()
        {
            var matrix = new[,]
            {
                {1, 1, 1, 9},
                {9, 9, 9, 9},
                {5, 6, 7, 11},
                {5, 6, 7, 11}
            };

            int sum = matrix.SumRightDiagonal();

            sum.Should().Be(29);
        }
    }
}