// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;

namespace No._08
{
    public class Checker
    {
        private readonly List<string> data;
        private readonly VisiblePos[] rowsFromLeft;
        private readonly VisiblePos[] rowsFromRight;
        private readonly VisiblePos[] colsFromTop;
        private readonly VisiblePos[] colsFromBottom;

        public Checker(List<string> data)
        {
            this.data = data;
            int cntRows = this.data.Count;
            int cntCols = this.data[0].Length;

            this.rowsFromLeft = Tools.initializeArray<VisiblePos>(cntRows);
            this.rowsFromRight = Tools.initializeArray<VisiblePos>(cntRows);
            this.colsFromTop = Tools.initializeArray<VisiblePos>(cntCols);
            this.colsFromBottom = Tools.initializeArray<VisiblePos>(cntCols);

            for (int row = 0; row < cntRows; row++)
            {
                for (int col = 0; col < cntCols; col++)
                {
                    _ = this.rowsFromLeft[row].checkIncreasing(this.data[row][col], col);
                    _ = this.colsFromTop[col].checkIncreasing(this.data[row][col], row);
                }
            }

            for (int row = cntRows - 1; row >= 0; row--)
            {
                for (int col = cntCols - 1; col >= 0; col--)
                {
                    _ = this.rowsFromRight[row].checkIncreasing(this.data[row][col], cntCols - col - 1);
                    _ = this.colsFromBottom[col].checkIncreasing(this.data[row][col], cntRows - row - 1);
                }
            }
        }

        public int countVisibleTrees()
        {
            int maxRow = this.data.Count - 1;
            int maxCol = this.data[0].Length - 1;
            int cntVisible = 0;

            for (int row = 0; row <= maxRow; row++)
            {
                for (int col = 0; col <= maxCol; col++)
                {
                    if (this.rowsFromLeft[row].isVisible(this.data[row][col], col)
                        || this.rowsFromRight[row].isVisible(this.data[row][col], maxCol - col)
                        || this.colsFromTop[col].isVisible(this.data[row][col], row)
                        || this.colsFromBottom[col].isVisible(this.data[row][col], maxRow - row))
                    {
                        cntVisible++;
                    }
                }
            }

            return cntVisible;
        }

        public static int calcMaxScenic(List<string> data)
        {
            int cntRows = data.Count;
            int cntCols = data[0].Length;

            int result = 0;

            for (int row = 1; row < cntRows - 1; row++)
            {
                for (int col = 1; col < cntCols - 1; col++)
                {
                    int myHeight = data[row][col];

                    int srow = row - 1;
                    while (srow > 0 && data[srow][col] < myHeight)
                    {
                        srow--;
                    }

                    int top = row - srow;

                    srow = row + 1;
                    while (srow < cntRows-1 && data[srow][col] < myHeight)
                    {
                        srow++;
                    }

                    int bottom = srow - row;

                    int scol = col - 1;
                    while (scol > 0 && data[row][scol] < myHeight)
                    {
                        scol--;
                    }

                    int left = col - scol;

                    scol = col + 1;
                    while (scol < cntCols-1 && data[row][scol] < myHeight)
                    {
                        scol++;
                    }

                    int right = scol - col;

                    result = Math.Max(top * bottom * left * right, result);
                }
            }

            return result;
        }
    }
}