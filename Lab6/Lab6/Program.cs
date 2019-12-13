using System;
using System.Reflection;

namespace Lab6
{

    delegate int PlusOrMinus(int p1, int p2);

    class Program
    {


        static int Plus(int p1, int p2)
        {
            return p1 + p2;
        }
        static int Minus(int p1, int p2)
        {
            return p1 - p2;
        }

        static void PlusOrMinusMethodFunc(string str, int i1, int i2, Func<int, int, int> PlusOrMinusParam)
        {
            int result = PlusOrMinusParam(i1, i2);
            Console.WriteLine(str + result.ToString());

        }


        static void PlusOrMinusMethod(string str, int i1, int i2, PlusOrMinus PlusOrMinusParam)
        {
            int result = PlusOrMinusParam(i1, i2);
            Console.WriteLine(str + result.ToString());
        }

        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            attribute = null;
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);

            if (isAttribute.Length > 0)
            {
                attribute = isAttribute[0];
                return true;
            }

            return false;
        }



        static void Main(string[] args)
        {

            Console.WriteLine("Делегаты\n");

            int a = 20, b = 15;
            PlusOrMinusMethod("Плюс ", a, b, Plus);
            PlusOrMinusMethod("Минус ", a, b, Minus);

            PlusOrMinus useMethod = new PlusOrMinus(Plus);
            PlusOrMinusMethod("Используем метод ", a, b, useMethod);


            PlusOrMinus useIdea = Plus;
            PlusOrMinusMethod("Используем \"предположение\" компилятора ", a, b, useIdea);

            PlusOrMinus anonMethod = delegate (int param1, int param2)
            {
                return param1 + param2;
            };
            PlusOrMinusMethod("Используем анонимный метод ", a, b, anonMethod);
            PlusOrMinusMethod("Используем лямбду 0 ", a, b,
                (int x, int y) =>
                {
                    int z = x + y;
                    return z;
                });
            PlusOrMinusMethod("Используем лямбду 1 ", a, b, (x, y) => { return x + y; });
            PlusOrMinusMethod("Используем лямбду 2 ", a, b, (x, y) => x + y);

            Console.WriteLine("\n Используем делегат Func<>");

            PlusOrMinusMethodFunc("Используем метод Plus ", a, b, Plus);

            string strOutside = "sample text";

            PlusOrMinusMethodFunc("Используем лямбду 0\n", a, b,
                (int x, int y) =>
                {
                    Console.WriteLine("\nПеременная вне лямбды " + strOutside);
                    int z = x + y;
                    return z;
                });
            PlusOrMinusMethodFunc("\nИспользуем лямбду 2\n", a, b,
                (x, y) =>
                {
                    return x + y;
                });
            PlusOrMinusMethodFunc("\nИспользуем лямбду 3\n", a, b, (x, y) => x + y);

            Console.WriteLine("Используем групповой делегат");
            Action<int, int> a1 = (x, y) => { Console.WriteLine("{0} + {1} = {2}", x, y, x + y); };
            Action<int, int> a2 = (x, y) => { Console.WriteLine("{0} - {1} = {2}", x, y, x - y); };
            Action<int, int> group = a1 + a2;
            group(15, 20);

            Action<int, int> group2 = a1;
            Console.WriteLine("Добавление вызова метода к групповому делегату");
            group2 += a2; group2(20, 15);
            Console.WriteLine("Удаление вызова метода из группового делегата");
            if ((group2 != null) && (a1 != null))
            {
                group2 -= a1;
            }
            group2(20, 10);

            Console.WriteLine("\nРЕФЛЕКСИЯ\n");

            Type t = typeof(Reflection);

            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nПубличные методы");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства с атрубутами");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(AT), out attrObj))
                {
                    AT attr = attrObj as AT;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
            Console.WriteLine("InvokeMember");
            Reflection fi = (Reflection)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
            Console.WriteLine("InvokeMethod");
            object[] parameters = { 20, 15 };
            object Result = t.InvokeMember("Plus", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Plus(20,15)={0}", Result);

            Console.ReadLine();
        }
    }
}
