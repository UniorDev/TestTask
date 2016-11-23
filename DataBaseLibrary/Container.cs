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


        /// <summary>
        /// Adds as many as you want matrices
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="matrices"></param>
        public void AddMatrices(Matrix<T> matrix, params Matrix<T>[] matrices)
        {
            _matrices.Add(matrix);

            foreach ( var m in matrices )
            {
                _matrices.Add(m);
            }
        }

        /// <summary>
        /// Displays container on console
        /// </summary>
        public void DisplayOnConsole()
        {
            for ( var i = 0; i < _matrices.Count; i++ )
            {
                Console.WriteLine($"    {i}-Matrix:\n");
                _matrices[i].DisplayOnConsole();
                Console.WriteLine("\n\n");
            }
        }
    }
}
