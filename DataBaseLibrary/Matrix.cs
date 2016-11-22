using System;
using System.Collections;
using System.Collections.Generic;

namespace DataBaseLibrary
{
    public enum Dimension
    {
        One,
        Two,
        Three
    }

    public class Matrix<T> : IEnumerable<T> where T : struct
    {
        private readonly int _xLength, _yLength = 1, _zLength = 1;
        private readonly Dimension _dimension;
        private readonly List<IPosition<T>> _positions;
        private readonly long _lengthEnd;

        public Matrix(Dimension dimension, int xLength, int yLength = 1, int zLength = 1, params T[] points)
        {
            _xLength = xLength;
            _yLength = yLength;
            _zLength = zLength;
            _lengthEnd = xLength * yLength * zLength;
            _dimension = dimension;
            _positions = new List<IPosition<T>>();

            foreach ( var point in points )
            {
                _positions.Add(new Position<T>(point));
            }
        }

        public Matrix(int positionsCount)
        {
            _positions = new List<IPosition<T>>();
            _lengthEnd = positionsCount;
            _xLength = positionsCount;
        }

        public Matrix(Position<T>[] positions)
        {
            _positions = new List<IPosition<T>>();

            foreach ( var position in positions )
            {
                _positions.Add(position);
            }

            _lengthEnd = positions.Length;
            _xLength = positions.Length;
        }

        public void Add(T value)
        {
            if ( _positions.Count >= _lengthEnd ) throw new DataBaseOverFlowException();

            _positions.Add(new Position<T>(value));
        }

        public void AddRange(T[] values)
        {
            foreach ( var value in values )
            {
                if ( _positions.Count >= _lengthEnd ) throw new DataBaseOverFlowException();

                _positions.Add(new Position<T>(value));
            }
        }

        public T this[int x, int y = 0, int z = 0]
        {
            get
            {
                switch ( _dimension )
                {
                    case Dimension.One:
                        {
                            if ( x >= _xLength ) throw new IndexOutOfDataBaseBoundsException(nameof(x), Convert.ToString(_xLength));
                            if ( x >= _positions.Count ) return default(T);
                            return _positions[x].Value;
                        }
                    case Dimension.Two:
                        {
                            if ( x >= _xLength ) throw new IndexOutOfDataBaseBoundsException(nameof(x), Convert.ToString(_xLength));
                            if ( y >= _yLength ) throw new IndexOutOfDataBaseBoundsException(nameof(y), Convert.ToString(_yLength));

                            var index = y * _xLength + x;

                            if ( index >= _positions.Count ) return default(T);

                            return _positions[index].Value;
                        }
                    case Dimension.Three:
                        {
                            if ( x >= _xLength ) throw new IndexOutOfDataBaseBoundsException(nameof(x), Convert.ToString(_xLength));
                            if ( y >= _yLength ) throw new IndexOutOfDataBaseBoundsException(nameof(y), Convert.ToString(_yLength));
                            if ( z >= _zLength ) throw new IndexOutOfDataBaseBoundsException(nameof(z), Convert.ToString(_zLength));

                            var index = z * _yLength * _xLength + y * _xLength + x;

                            if ( index >= _positions.Count ) return default(T);

                            return _positions[index].Value;
                        }
                }

                return default(T);
            }
        }

        public void DisplayOnConsole()
        {
            switch ( _dimension )
            {
                case Dimension.One:
                    {
                        foreach ( var position in _positions )
                            Console.Write(Convert.ToString(position.Value) + ' ');
                        break;
                    }
                case Dimension.Two:
                    {
                        for ( var i = 0; i < _yLength; i++ )
                        {
                            for ( var j = 0; j < _xLength; j++ )
                            {
                                var index = i * _xLength + j;
                                Console.Write(Convert.ToString(_positions[index]) + ' ');
                            }
                            Console.WriteLine();
                        }
                        break;
                    }

                case Dimension.Three:
                    {
                        for ( var i = 0; i < _yLength; i++ )
                        {
                            for ( var j = 0; j < _zLength; j++ )
                            {
                                for ( var k = 0; k < _xLength; k++ )
                                {
                                    var index = ( i * _xLength + k ) * j;
                                    Console.Write(Convert.ToString(_positions[index]) + ' ');
                                }
                                Console.Write("         ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach ( var position in _positions )
            {
                yield return position.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
