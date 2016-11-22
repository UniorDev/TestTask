using System.Collections.Generic;

namespace DataBaseLibrary
{
    public abstract class DataBase
    {
        public static void AddContainers<T>(ref List<Container<T>> dataBase, Container<T> container, params Container<T>[] containers) where T : struct
        {
            dataBase?.Add(container);
            dataBase?.AddRange(containers);
        }

        public static List<Container<T>> Create<T>() where T : struct
        {
            return new List<Container<T>>();
        }

        public static List<Container<T>> Create<T>(int conteinersCount, int matricsCount, Position<T>[] positions) where T : struct
        {
            var containers = new List<Container<T>>();

            for ( var i = 0; i < conteinersCount; i++ )
            {
                containers.Add(new Container<T>(matricsCount, points));
            }

            return containers;
        }

        public static List<Container<T>> Create<T>(int conteinersCount, int matricsCount, int positionsCount) where T : struct
        {
            var containers = new List<Container<T>>();

            for ( var i = 0; i < conteinersCount; i++ )
            {
                containers.Add(new Container<T>(matricsCount, positionsCount));
            }

            return containers;
        }

        public static List<Container<T>> Create<T>(int conteinersCount) where T : struct
        {
            var containers = new List<Container<T>>();

            for ( var i = 0; i < conteinersCount; i++ )
            {
                containers.Add(new Container<T>());
            }

            return containers;
        }

    }
}
