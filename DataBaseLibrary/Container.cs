using System.Collections.Generic;

namespace DataBaseLibrary
{
    public class Container<T> where T : struct
    {
        private readonly List<IMatrix<T>> _matrices;

        public IMatrix<T> this[int x] => _matrices[0];

        #region Ctors

        public Container(params IMatrix<T>[] matrices)
        {
            _matrices = new List<IMatrix<T>>();

            foreach ( var matrix in matrices )
            {
                _matrices.Add(matrix);
            }
        }

        public Container(int matricsCount, T[] points)
        {
            _matrices = new List<IMatrix<T>>();

            for ( var i = 0; i < matricsCount; i++ )
            {
                _matrices.Add(new OneDimensionalMatrix<T>(points));
            }
        }

        public Container(int matricsCount, int positionsCount)
        {
            _matrices = new List<IMatrix<T>>();

            for ( var i = 0; i < matricsCount; i++ )
            {
                _matrices.Add(new OneDimensionalMatrix<T>(positionsCount));
            }
        }

        public Container(int matricsCount)
        {
            _matrices = new List<IMatrix<T>>();

            for ( var i = 0; i < matricsCount; i++ )
            {
                _matrices.Add(new OneDimensionalMatrix<T>());
            }
        }

        #endregion

        public void AddMatrix(IMatrix<T> matrix)
        {
            _matrices.Add(matrix);
        }


    }
}
