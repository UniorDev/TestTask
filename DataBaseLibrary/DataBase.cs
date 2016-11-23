using System;
using System.Collections.Generic;

namespace DataBaseLibrary
{
    public abstract class DataBase
    {
        /// <summary>
        /// Adds as many containers as you want
        /// </summary>
        /// <typeparam name="T">Numerical type</typeparam>
        /// <param name="dataBase">Place where you wanna store containers</param>
        /// <param name="container"></param>
        /// <param name="containers"></param>
        public static void AddContainers<T>(ref List<Container<T>> dataBase, Container<T> container, params Container<T>[] containers) where T : struct
        {
            dataBase?.Add(container);
            dataBase?.AddRange(containers);
        }

        public static List<Container<T>> Create<T>() where T : struct
        {
            return new List<Container<T>>();
        }

        public static List<Container<T>> Create<T>(params Container<T>[] containers) where T : struct
        {
            return new List<Container<T>>(containers);
        }

        public static List<Container<T>> Create<T>(int conteinersCount, int matricsCount, Position<T>[] positions) where T : struct
        {
            var containers = new List<Container<T>>();

            for ( var i = 0; i < conteinersCount; i++ )
            {
                containers.Add(new Container<T>(matricsCount, positions));
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

        /// <summary>
        /// Displays database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containers"></param>
        public static void DisplayOnConsole<T>(List<Container<T>> containers) where T : struct
        {
            for ( var i = 0; i < containers.Count; i++ )
            {
                Console.WriteLine($" {i}-Container:\n");
                containers[i].DisplayOnConsole();
            }

            Console.WriteLine("\n\n".PadRight(40, '-'));
        }
    }
}
