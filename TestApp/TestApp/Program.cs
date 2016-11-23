using DataBaseLibrary;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunExapleOne();
            //RunExampleTwo();
            //Show3DMatrix();
            Console.ReadKey();
        }

        private static void RunExapleOne()
        {
            var db = DataBase.Create<decimal>(3);
            foreach ( var container in db )
            {
                var d2Matrix = new Matrix<decimal>(Dimension.Two, new D2Point(20, 30), 5m, 2m, 3m, 10m, 12m, 25m, 32m);
                var d1Matrix = new Matrix<decimal>(Dimension.One, new D1Point(100), 25m, 15m, 1m, 2m, 9m, 10m, 22m, 14m,
                    8m);
                container.AddMatrices(d2Matrix, d1Matrix);
            }

            DataBase.DisplayOnConsole(db);
        }

        private static void RunExampleTwo()
        {
            var db = DataBase.Create<double>(10);
            foreach ( var container in db )
            {
                var d2Matrix1 = new Matrix<double>(Dimension.Two, new D2Point(2, 2), 5, 2, 3, 6);
                var d1Matrix1 = new Matrix<double>(Dimension.One, new D1Point(4), 1, 5, 8, 9);
                var d2Matrix2 = new Matrix<double>(Dimension.Two, new D2Point(2, 2), 5, 2, 3, 6);
                var d1Matrix2 = new Matrix<double>(Dimension.One, new D1Point(4), 1, 5, 8, 9);
                var d2Matrix3 = new Matrix<double>(Dimension.Two, new D2Point(2, 2), 5, 2, 3, 6);
                var d1Matrix3 = new Matrix<double>(Dimension.One, new D1Point(4), 1, 5, 8, 9);
                var d2Matrix4 = new Matrix<double>(Dimension.Two, new D2Point(2, 2), 5, 2, 3, 6);
                var d1Matrix4 = new Matrix<double>(Dimension.One, new D1Point(4), 1, 5, 8, 9);
                var d2Matrix5 = new Matrix<double>(Dimension.Two, new D2Point(2, 2), 5, 2, 3, 6);
                var d1Matrix5 = new Matrix<double>(Dimension.One, new D1Point(4), 1, 5, 8, 9);
                container.AddMatrices(d2Matrix1, d1Matrix1, d2Matrix2, d1Matrix2, d2Matrix3, d2Matrix4, d1Matrix4,
                    d2Matrix5, d1Matrix5);
            }

            DataBase.DisplayOnConsole(db);
        }

        private static void Show3DMatrix()
        {
            var db = DataBase.Create<int>();
            var container = new Container<int>();
            var matrix = new Matrix<int>(Dimension.Three, new D3Point(3, 3, 3), 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 8, 7, 6, 5, 3, 2, 1, 0, 1, 2, 3, 4, 9, 8, 7, 6, 5);
            container.AddMatrices(matrix);
            DataBase.AddContainers(ref db, container);
            DataBase.DisplayOnConsole(db);
        }
    }
}