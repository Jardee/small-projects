using System;
using System.Collections.Generic;
using System.Linq;


namespace SudokuValidateNxN
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        class Sudoku
        {
            int[][] _sudokuData;
            int _piece = 0;
            int _size = 0;
            public Sudoku(int[][] sudokuData)
            {
                _sudokuData = sudokuData;
                _piece = (int)Math.Sqrt(_sudokuData.GetLength(0));
                _size = _sudokuData.GetLength(0);
            }

            bool square_check(int y)
            {
                double z = Math.Sqrt(y);

                if (z == (int)z)
                    return true;
                else
                    return false;

            }

            public bool IsValid()
            {
                if (!square_check(_size))
                    return false;

                for (int i = 0; i < _sudokuData.GetLength(0); i++)
                {
                    //if (_sudokuData[i].Length != _size)
                    //return false;
                    if (_sudokuData[i].Length != _sudokuData.GetLength(0))
                        return false;
                }


                //check for zeros
                for (int i = 0; i < _size; i++)
                    for (int j = 0; j < _size; j++)
                    {
                        if (_sudokuData[i][j] <= 0 || _sudokuData[i][j] > _size) return false;
                        if (!(_sudokuData[i][j] is int)) return false;
                    }

                //actual check rows
                for (int i = 0; i < _size; i++)
                {
                    List<int> x = new List<int>();
                    List<int> y = new List<int>();
                    for (int j = 0; j < _size; j++)
                    {
                        x.Add(_sudokuData[i][j]);
                        y.Add(_sudokuData[j][i]);
                    }

                    var diffChecker1 = new HashSet<int>();
                    var diffChecker2 = new HashSet<int>();

                    if (!x.All(diffChecker1.Add))
                        return false;

                    if (!y.All(diffChecker2.Add))
                        return false;
                }

                for (int i = 0; i < _size; i += _piece)
                {
                    for (int j = 0; j < _size; j += _piece)
                    {
                        List<int> vv = new List<int>();

                        for (int x = i; x < i + _piece; x++)
                        {
                            for (int y = j; y < j + _piece; y++)
                            {
                                vv.Add(_sudokuData[x][y]);
                            }
                        }

                        var diffChecker = new HashSet<int>();

                        if (!vv.All(diffChecker.Add))
                            return false;
                    }
                }

                return true;

            }
        }
    }
}
