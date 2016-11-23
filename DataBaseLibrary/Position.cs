using System;

namespace DataBaseLibrary
{
    public interface IPosition<out T> where T : struct
    {
        T Value { get; }
    }

    public class Position<T> : IPosition<T> where T : struct
    {
        public T Value { get; }

        public Position(T value)
        {
            var typeOfValue = value.GetType();
            if ( typeOfValue == typeof(bool) || typeOfValue == typeof(DateTime) || typeOfValue == typeof(char) )
                throw new WrongValueTypeException();

            Value = value;
        }
    }
}
