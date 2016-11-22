using System;
using System.Collections.Generic;

namespace DataBaseLibrary
{
    public class Container<T> where T : struct
    {
        private readonly List<Matrix<T>> _matrices;

        public Matrix<T> this[int x] => _matrices[x];

        #region Ctors

        public Container(params Matrix<T>[] matrices)
        {
            _matrices = new List<Matrix<T>>();

            foreach ( var matrix in matrices )
            {
                _matrices.Add(matrix);
            }
        }

        public Container(int matricsCount, Position<T>[] positions)
        {
            _matrices = new List<Matrix<T>>();

            for ( var i = 0; i < matricsCount; i++ )
            {
                _matrices.Add(new Matrix<T>(positions));
            }
        }

        public Container(int matricsCount, int positionsCount)
        {
            _matrices = new List<Matrix<T>>();

            for ( var i = 0; i < matricsCount; i++ )
            {
                _matrices.Add(new Matrix<T>(positionsCount));
            }
        }

        #endregion

        public void AddMatrix(Matrix<T> matrix)
        {
            _matrices.Add(matrix);
        }

        public void DisplayOnConsole()
        {
            for ( var i = 0; i < _matrices.Count; i++ )
            {
                Console.WriteLine($"      {i}-Matrix:\n");
                _matrices[i].DisplayOnConsole();
                Console.WriteLine("\n\n");
            }
        }
    }
}
