using System.Collections.Generic;

namespace DataBaseLibrary
{
    public interface IMatrix<in T> where T : struct
    {
        void Add(T value);
    }

    public class OneDimensionalMatrix<T> : IMatrix<T> where T : struct
    {
        private readonly List<IPosition<T>> _positions;

        public T this[int x] => _positions[0].Value;

        public OneDimensionalMatrix(params T[] values)
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

    public class TwoDimensionalMatrix<T> : IMatrix<T> where T : struct
    {
        private readonly List<IPosition<T>> _positions;

        public T this[int x, int y] => _positions[0].Value;

        public TwoDimensionalMatrix(params T[] values)
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

    public class TreeDimensionalMatrix<T> : IMatrix<T> where T : struct
    {
        private readonly List<IPosition<T>> _positions;

        public T this[int x, int y, int z] => _positions[0].Value;

        public TreeDimensionalMatrix(params T[] values)
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
