namespace DataBaseLibrary
{
    public interface IPoint
    {
        int X { get; }
    }

    public struct D1Point : IPoint
    {
        public int X { get; }

        public D1Point(int x)
        {
            if ( x < 0 ) throw new InvalidPointException();

            X = x;
        }
    }

    public struct D2Point : IPoint
    {
        public int X { get; }
        public int Y { get; }

        public D2Point(int x, int y)
        {
            if ( x < 0 || y < 0 ) throw new InvalidPointException();

            X = x;
            Y = y;
        }
    }

    public struct D3Point : IPoint
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public D3Point(int x, int y, int z)
        {
            if ( x < 0 || y < 0 || z < 0 ) throw new InvalidPointException();

            X = x;
            Y = y;
            Z = z;
        }
    }

}
