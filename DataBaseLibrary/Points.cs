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
            X = x;
        }
    }

    public struct D2Point : IPoint
    {
        public int X { get; }
        public int Y { get; }

        public D2Point(int x, int y)
        {
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
            X = x;
            Y = y;
            Z = z;
        }
    }

}
