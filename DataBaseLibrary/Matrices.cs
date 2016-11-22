using System.Collections.Generic;

namespace DataBaseLibrary
{
    public interface IMatrix<in T> where T : struct
    {
        void Add(T value);
    }

    public enum Dimension
    {
        One,
        Two,
        Three
    }

    public class OneDimensionalMatrix<T> : IMatrix<T> where T : struct
    {
        private int _xLength;

        private readonly List<IPosition<T>> _positions;

        public T this[int x] => _positions[0].Value;

        #region Ctors

        public OneDimensionalMatrix(int xLength, params T[] points)
        {
            _positions = new List<IPosition<T>>();

            foreach ( var t in points )
            {
                _positions.Add(new Position<T>(t));
            }
        }

        public OneDimensionalMatrix(int positionsCount)
        {
            _positions = new List<IPosition<T>>();

            for ( var i = 0; i < positionsCount; i++ )
            {
                _positions.Add(new Position<T>(default(T)));
            }
        }

        #endregion

        public void Add(T value)
        {
            _positions.Add(new Position<T>(value));
        }
    }

    public class TwoDimensionalMatrix<T> : IMatrix<T> where T : struct
    {
        private readonly List<IPosition<T>> _positions;

        public T this[int x, int y] => _positions[0].Value;

        public TwoDimensionalMatrix(int xLength, int yLength, params T[] values)
        {
            _positions = new List<IPosition<T>>();

            foreach ( var value in values )
            {
                _positions.Add(new Position<T>(value));
            }

        }

        public void Add(T value)
        {
            _positions.Add(new Position<T>(value));
        }
    }

    public class ThreeDimensionalMatrix<T> : IMatrix<T> where T : struct
    {
        private readonly List<IPosition<T>> _positions;

        public T this[int x, int y, int z] => _positions[0].Value;

        public ThreeDimensionalMatrix(int xLength, int yLength, int zLenght, params T[] values)
        {
            _positions = new List<IPosition<T>>();

            foreach ( var value in values )
            {
                _positions.Add(new Position<T>(value));
            }

        }

        public void Add(T value)
        {
            _positions.Add(new Position<T>(value));
        }
    }
}
