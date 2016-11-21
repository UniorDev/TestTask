namespace DataBaseLibrary
{
    public class DataBase
    {
        public enum Dimension
        {
            One,
            Two,
            Three
        }

        public DataBase(int containers, int matrics, int lenght, int values, Dimension d)
        {

        }

        public DataBase()
        {

        }

        public void A()
        {
            var db = new DataBase(1, 1, 1, 1, Dimension.One);
        }
    }
}
