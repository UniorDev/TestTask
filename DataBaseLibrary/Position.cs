using System;

namespace DataBaseLibrary
{
    /// <summary>
    /// Defines general behavior of position
    /// </summary>
    /// <typeparam name="T">Should be numerical</typeparam>
    public interface IPosition<out T> where T : struct
    {
        T Value { get; }
    }

    public class Position<T> : IPosition<T> where T : struct
    {
        /// <summary>
        /// Value, that will be stored
        /// </summary>
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
