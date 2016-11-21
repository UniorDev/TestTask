using System;

namespace DataBaseLibrary
{
    public class WrongValueTypeException : Exception
    {
        public WrongValueTypeException(string message = "Wrong type of value. Please use numeric values(integer, double, decimal).")
            : base(message)
        {

        }
    }
}
