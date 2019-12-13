﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lab3
{
 
    class Program
    {
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1. ArrayList");
            Console.WriteLine("2. List");
            Console.WriteLine("3. Matrix");
            Console.WriteLine("4. SimpleStack");
            Console.WriteLine("5.Exit");
            Console.WriteLine();

        }

        static int Main(string[] args)
        {
            #region
            int n = 0;
            ArrayList arli = new ArrayList();
            List<Geometric_figures> li = new List<Geometric_figures>();

            double length;

            Rectangle rect = new Rectangle(0, 0);
            Console.WriteLine("Ввод параметров фигур прямоугольника:");
            Console.Write("Длина ");
            length = Double.Parse(Console.ReadLine());
            rect.length1 = length;
            Console.Write("Ширина ");
            length = Double.Parse(Console.ReadLine());
            rect.length2 = length;

            Square scv = new Square(0);
            Console.WriteLine("Ввод параметров для квадрата:");
            Console.Write("Строна ");
            length = Double.Parse(Console.ReadLine());
            scv.length1 = length;
            scv.length2 = length;

            Circle cir = new Circle(0);
            Console.WriteLine("Ввод параметров для круга");
            Console.Write("Радиус ");
            length = Double.Parse(Console.ReadLine());
            cir.radius = length;

            arli.Add(rect);
            li.Add(rect);
            arli.Add(scv);
            li.Add(scv);
            arli.Add(cir);
            li.Add(cir);

            #endregion

            while (n != 5)
            {

                Menu();
                n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            int yeah;

                            Console.WriteLine("Сортировка");
                            Console.WriteLine("  1. По возрастанию");
                            Console.WriteLine("  2. По убыванию");
                            yeah = int.Parse(Console.ReadLine());
                            if (yeah == 1)
                                for (int j = 0; j < arli.Count - 1; j++)
                                    for (int i = 0; i < arli.Count - 1 - j; i++)
                                    {
                                        if (((Geometric_figures)arli[i]).CompareTo(arli[i + 1]) == 1)
                                        {
                                            Object spec = arli[i];
                                            arli[i] = arli[i + 1];
                                            arli[i + 1] = spec;
                                        }
                                    }
                            else
                                for (int j = 0; j < arli.Count - 1; j++)
                                    for (int i = 0; i < arli.Count - 1 - j; i++)
                                    {
                                        if (((Geometric_figures)arli[i]).CompareTo(arli[i + 1]) == 0)
                                        {
                                            Object spec = arli[i];
                                            arli[i] = arli[i + 1];
                                            arli[i + 1] = spec;
                                        }
                                    }


                            Console.WriteLine();

                            foreach (object i in arli)
                            {
                                if (i.GetType().Name == "Rectangle")
                                {
                                    Console.WriteLine(i.GetType().Name + ":");
                                    ((Rectangle)i).Print();
                                }
                                else
                                    if (i.GetType().Name == "Square")
                                {
                                    Console.WriteLine(i.GetType().Name + ":");
                                    ((Square)i).Print();
                                }
                                else
                                    if (i.GetType().Name == "Circle")
                                {
                                    Console.WriteLine(i.GetType().Name + ":");
                                    ((Circle)i).Print();
                                }
                            }

                            break;
                        }
                    case 2:
                        {
                            int yeah;

                            Console.WriteLine("Сортировка");
                            Console.WriteLine("  1. По возрастанию");
                            Console.WriteLine("  2. По убыванию");
                            yeah = int.Parse(Console.ReadLine());
                            if (yeah == 1)
                                for (int j = 0; j < li.Count - 1; j++)
                                    for (int i = 0; i < li.Count - 1 - j; i++)
                                    {
                                        if (((Geometric_figures)li[i]).CompareTo(li[i + 1]) == 0)
                                        {
                                            Object spec = li[i];
                                            li[i] = li[i + 1];
                                            li[i + 1] = (Geometric_figures)spec;
                                        }
                                    }
                            else
                                for (int j = 0; j < li.Count - 1; j++)
                                    for (int i = 0; i < li.Count - 1 - j; i++)
                                    {
                                        if (((Geometric_figures)li[i]).CompareTo(li[i + 1]) == 1)
                                        {
                                            Object spec = li[i];
                                            li[i] = li[i + 1];
                                            li[i + 1] = (Geometric_figures)spec;
                                        }
                                    }

                            foreach (object i in li)
                            {
                                if (i.GetType().Name == "Rectangle")
                                {
                                    Console.WriteLine(i.GetType().Name + ":");
                                    ((Rectangle)i).Print();
                                }
                                else
                                    if (i.GetType().Name == "Square")
                                {
                                    Console.WriteLine(i.GetType().Name + ":");
                                    ((Square)i).Print();
                                }
                                else
                                    if (i.GetType().Name == "Circle")
                                {
                                    Console.WriteLine(i.GetType().Name + ":");
                                    ((Circle)i).Print();
                                }
                            }

                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("\nMatrix");
                            Matrix<Geometric_figures> matrix = new Matrix<Geometric_figures>(3, 3, 3, new FigureMatrixCheckEmpty());
                            matrix[0, 0, 0] = rect;
                            matrix[1, 1, 1] = scv;
                            matrix[2, 2, 2] = cir;
                            Console.WriteLine(matrix.ToString());

                            break;
                        }
                    case 4:
                        {
                            SimpleStack<Geometric_figures> stack = new SimpleStack<Geometric_figures>();
                            stack.Push(rect);
                            stack.Push(scv);
                            stack.Push(cir);

                            while (stack.Count > 0)
                            {
                                Geometric_figures f = stack.Pop();
                                Console.WriteLine(f);
                            }
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("ERROR");
                        }
                        break;
                }

            }
            return 0;
        }

    }

}
