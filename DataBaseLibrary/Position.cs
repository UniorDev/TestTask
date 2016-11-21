namespace DataBaseLibrary
{
    public class Position<T> where T : struct
    {
        public IPoint Point { get; }

        public T Value { get; }

        public Position(IPoint point, T value)
        {
            var typeOfValue = value.GetType();
            if ( typeOfValue.IsEnum || typeOfValue == typeof(bool) )
                throw new WrongValueTypeException();

            Point = point;
            Value = value;
        }
    }
}
