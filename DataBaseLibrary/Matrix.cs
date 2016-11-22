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
        private readonly IPoint _pointLength;
        private readonly Dimension _dimension;
        private readonly List<IPosition<T>> _positions;
        private readonly long _lengthEnd;

        public Matrix(Dimension dimension, IPoint pointLength, params T[] points)
        {
            _dimension = dimension;
            _positions = new List<IPosition<T>>();

            foreach ( var point in points )
            {
                _positions.Add(new Position<T>(point));
            }

            if ( pointLength is D1Point )
            {
                _lengthEnd = _pointLength.X;
                _pointLength = new D1Point(_pointLength.X);
            }
            else if ( pointLength is D2Point )
            {
                var d2Point = ( D2Point )pointLength;
                _lengthEnd = d2Point.X * d2Point.Y;
                _pointLength = new D2Point(d2Point.X, d2Point.Y);
            }
            else
            {
                var d3Point = ( D3Point )pointLength;
                _lengthEnd = d3Point.X * d3Point.Y * d3Point.Z;
                _pointLength = new D3Point(d3Point.X, d3Point.Y, d3Point.Z);
            }
        }

        public Matrix(int positionsCount)
        {
            _positions = new List<IPosition<T>>();
            _lengthEnd = positionsCount;
            _pointLength = new D1Point(positionsCount);
        }

        public Matrix(Position<T>[] positions)
        {
            _positions = new List<IPosition<T>>();

            foreach ( var position in positions )
            {
                _positions.Add(position);
            }

            _lengthEnd = positions.Length;
            _pointLength = new D1Point(positions.Length);
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

        public T this[IPoint point]
        {
            get
            {
                switch ( _dimension )
                {
                    case Dimension.One:
                        {
                            if ( point.X >= _pointLength.X ) throw new IndexOutOfDataBaseBoundsException(nameof(point.X), Convert.ToString(_pointLength.X));
                            if ( point.X >= _positions.Count ) return default(T);
                            return _positions[point.X].Value;
                        }
                    case Dimension.Two:
                        {
                            var d2PointLenght = ( D2Point )_pointLength;
                            var d2Point = ( D2Point )point;
                            if ( d2Point.X >= d2PointLenght.X ) throw new IndexOutOfDataBaseBoundsException(nameof(d2Point.X), Convert.ToString(d2PointLenght.X));
                            if ( d2Point.Y >= d2PointLenght.Y ) throw new IndexOutOfDataBaseBoundsException(nameof(d2Point.Y), Convert.ToString(d2PointLenght.Y));

                            var index = d2Point.Y * d2PointLenght.X + d2Point.X;

                            if ( index >= _positions.Count ) return default(T);

                            return _positions[index].Value;
                        }
                    case Dimension.Three:
                        {
                            var d3PointLenght = ( D3Point )_pointLength;
                            var d3Point = ( D3Point )point;
                            if ( d3Point.X >= d3PointLenght.X ) throw new IndexOutOfDataBaseBoundsException(nameof(d3Point.X), Convert.ToString(d3PointLenght.X));
                            if ( d3Point.Y >= d3PointLenght.Y ) throw new IndexOutOfDataBaseBoundsException(nameof(d3Point.Y), Convert.ToString(d3PointLenght.Y));
                            if ( d3Point.Z >= d3PointLenght.Z ) throw new IndexOutOfDataBaseBoundsException(nameof(d3Point.Z), Convert.ToString(d3PointLenght.Z));

                            var index = d3Point.Z * d3PointLenght.Y * d3PointLenght.X + d3Point.Y * d3PointLenght.X + d3Point.X;

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
                        var d2PointLenght = ( D2Point )_pointLength;

                        for ( var i = 0; i < d2PointLenght.Y; i++ )
                        {
                            for ( var j = 0; j < d2PointLenght.X; j++ )
                            {
                                var index = i * d2PointLenght.X + j;
                                Console.Write(Convert.ToString(_positions[index]) + ' ');
                            }
                            Console.WriteLine();
                        }
                        break;
                    }

                case Dimension.Three:
                    {
                        var d3PointLenght = ( D3Point )_pointLength;

                        for ( var i = 0; i < d3PointLenght.Y; i++ )
                        {
                            for ( var j = 0; j < d3PointLenght.Z; j++ )
                            {
                                for ( var k = 0; k < d3PointLenght.X; k++ )
                                {
                                    var index = ( i * d3PointLenght.X + k ) * j;
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
