using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    public static class MagicSquare
    {
        // TODO finir l'exo du cube magique
        public static UInt32 MagicSum(UInt32 n)
        {
            return n * (n * n + 1) / 2;
        }

        // TODO: unit test:
        // n=1 => 1
        // n=3 => 15
        // n=4 => 34
        // n=5 => 65

        public static bool IsMagic(UInt32[,] square)
        {
            UInt32 magigSum = 0;

            // compute magic sum
            // verify rows
            // verify columns
            // verify diagonals
            // verify all numbers are present (only once)

            AreMagicColumns(square);
            AreMagicRows(square);

            return false;
        }

        public static UInt32[,] Generate(UInt32 n)
        {
            // TODO: fill array with number in range [1, n^2]
            return new UInt32[n, n];
        }

        public static bool AreMagicRows(UInt32[,] square)
        {
            // row verification
            for (uint i = 0; i < square.GetLength(0); i++)
            {
                UInt32 rowCount = 0;
                Console.WriteLine();
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    Console.Write(square[i, j]);
                    rowCount += square[i, j];


                }
                Console.WriteLine($" *{rowCount}* ");
                bool corectOnNot = rowCount == 15;
                Console.WriteLine($" line {i} is  {corectOnNot}");
            }

            return false;
        }
        public static bool AreMagicColumns(UInt32[,] square)
        {
            // column verification
            for (int i = 0; i < square.GetLength(1); i++)
            {
                UInt32 columnCount = 0;

                Console.WriteLine();
                for (Int32 j = 0; j < square.GetLength(0); j++)
                {
                    Console.Write(square[j, i]);
                    columnCount += square[j, i];
                }
                Console.WriteLine($" *{columnCount}* ");
                Console.WriteLine($"Column {i} is " + (columnCount == 15 ? "correct" : "incorect"));
            }
            return false;
        }

        public static bool AreMagicDiagonal(UInt32[,] square)
        {


            return false;
        }

    }
}
