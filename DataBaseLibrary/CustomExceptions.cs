using System;

namespace DataBaseLibrary
{
    public class WrongValueTypeException : Exception
    {
        public WrongValueTypeException(string message = "Wrong type of value. Please use numeric values(integer, double, decimal).")
            : base(message)
        { }
    }

    public class DataBaseOverFlowException : Exception
    {
        public DataBaseOverFlowException(string message = "Data base overflowed. You can't add something.") : base(message)
        { }
    }

    public class IndexOutOfDataBaseBoundsException : Exception
    {
        public IndexOutOfDataBaseBoundsException(string name, string bound) : base(ModifyMessage(name, bound))
        { }

        private static string ModifyMessage(string name, string bound)
        {
            return $"{name} index out of data base bounds. Should be equal or less than {bound}";
        }
    }

    public class InvalidPointException : Exception
    {
        public InvalidPointException(string message = "Invalid point. It should be not less than 0.") : base(message)
        { }
    }
}
