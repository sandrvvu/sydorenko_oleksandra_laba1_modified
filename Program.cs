using System;
using System.IO;
using Newtonsoft.Json;

namespace laba1
{
    class Program
    {
        public class Point //клас точки
        {
            public double x;
            public double y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Triangle //клас трикутника
        {
            public Point A;
            public Point B;
            public Point C;

            public Triangle(Point A, Point B, Point C)
            {
                this.A = A;
                this.B = B;
                this.C = C;
            }

            public void GetPoints() //виведення значення точок трикутника
            {
                Console.WriteLine($"Дані про точки трикутника: ({A.x};{A.y}), ({B.x};{B.y}), ({C.x};{C.y}) ");
            }

            public double GetLength(Point P1, Point P2) //отримання довжини між точками
            {
                double side;
                side = Math.Sqrt(Math.Pow(P2.x - P1.x, 2) + Math.Pow(P2.y - P1.y, 2));
                return side;
            }


            public void EqualTriangle(Point A2, Point B2, Point C2)  //метод що визначає чи рівні даний трикутник з трикутиком,заданими такими точками

            {
                double a, b, c;
                double a2, b2, c2;

                a = GetLength(B, C);
                b = GetLength(A, C);
                c = GetLength(A, B);

                a2 = GetLength(B2, C2);
                b2 = GetLength(A2, C2);
                c2 = GetLength(A2, B2);

                if (a == a2 && b == b2 && c == c2)
                {
                    Console.WriteLine("Трикутники рівні");
                }
                else { Console.WriteLine("Трикутники НЕ рівні"); }

            }

            public double Perimetr()  //метод для обчислення периметра
            {
                double P, a, b, c;
                a = GetLength(B, C);
                b = GetLength(A, C);
                c = GetLength(A, B);
                P = a + b + c;
                return P;
            }
            public void GetPerimetr() //виведення значення периметра
            {
                double P = Perimetr();
                Console.WriteLine($"Периметр даного трикутника дорівнює {P}");
            }

            public double Area() //метод для  обчислення площі
            {
                double p, a, b, c;
                a = GetLength(B, C);
                b = GetLength(A, C);
                c = GetLength(A, B);
                p = Perimetr() / 2;
                return (Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            }
            public void GetArea() //виведення значення площі
            {
                double S = Area();
                Console.WriteLine($"Площа даного трикутника дорівнює {S}");
            }

            public Tuple<double, double, double> Heights() //метод для обчислення висот
            {
                double a = GetLength(B, C);
                double b = GetLength(A, C);
                double c = GetLength(A, B);
                double h1 = Area() / a;
                double h2 = Area() / b;
                double h3 = Area() / c;
                var heights = Tuple.Create(h1, h2, h3);
                return heights;
            }

            public void GetHeights() //виведення значення висот
            {
                Tuple<double, double, double> h = Heights();
                Console.WriteLine($"Висоти даного трикутника дорівнюють {h}");
            }

            public Tuple<double, double, double> Medians() //метод для обчислення медіан
            {
                double a = GetLength(B, C);
                double b = GetLength(A, C);
                double c = GetLength(A, B);
                double m1 = Math.Sqrt(2 * (Math.Pow(c, 2) + Math.Pow(b, 2)) - Math.Pow(a, 2)) / 2;
                double m2 = Math.Sqrt(2 * (Math.Pow(c, 2) + Math.Pow(a, 2)) - Math.Pow(b, 2)) / 2;
                double m3 = Math.Sqrt(2 * (Math.Pow(a, 2) + Math.Pow(b, 2)) - Math.Pow(c, 2)) / 2;
                var medians = Tuple.Create(m1, m2, m3);
                return medians;
            }

            public void GetMedians() //виведення значення медіан
            {
                Tuple<double, double, double> m = Medians();
                Console.WriteLine($"Медіани даного трикутника дорівнюють {m}");
            }

            public Tuple<double, double, double> Bisectors() //метод для обчислення бісектрис
            {
                double a = GetLength(B, C);
                double b = GetLength(A, C);
                double c = GetLength(A, B);
                double b1 = Math.Sqrt(a * b * (a + b + c) * (a + b - c)) / (a + b);
                double b2 = Math.Sqrt(c * b * (a + b + c) * (c + b - a)) / (c + b); ;
                double b3 = Math.Sqrt(a * c * (a + b + c) * (a + c - b)) / (a + c); ;
                var bisectors = Tuple.Create(b1, b2, b3);
                return bisectors;
            }
            public void GetBisectors() //виведення значення бісектрис
            {
                Tuple<double, double, double> b = Bisectors();
                Console.WriteLine($"Бісектриси даного трикутника дорівнюють {b}");
            }
            public double R() //метод для обчислення радіусу описаного кола
            {
                double R, a, b, c;
                a = GetLength(B, C);
                b = GetLength(A, C);
                c = GetLength(A, B);
                R = (a * b * c) / (4 * Area());
                return R;
            }

            public void GetR() //виведення значення радіуса описаного кола
            {
                double RadiusR = R();
                Console.WriteLine($"Радіус описаного кола даного трикутника дорівнюють {RadiusR}");
            }
            public double r() //метод для обчислення радіусу вписаного кола
            {
                double r;
                r = 2 * Area() / Perimetr();
                return r;
            }

            public void Getr() //виведення значення радіусу вписаного  кола
            {
                double Radiusr = r();
                Console.WriteLine($"Радіус вписаного кола даного трикутника дорівнюють {Radiusr}");
            }

            public void Type() //визначення типу трикутника
            {
                double a = GetLength(B, C);
                double b = GetLength(A, C);
                double c = GetLength(A, B);

                if ((a * a + b * b == c * c) || (a * a + c * c == b * b) || (c * c + b * b == a * a))
                {
                    Console.WriteLine("Трикутник прямокутний");
                }
                if ((a == b) || (a == c) || (b == c))
                {
                    Console.WriteLine("Трикутник рiвнобедренний");
                }
                if ((a == b) && (a == c) && (b == c))
                {
                    Console.WriteLine("Трикутник правильний");
                }
                else
                {
                    Console.WriteLine("Трикутник довiльний");
                }
            }

            public void RotateCenter(double angle) //поворот на кут відносно центра
            {

                A.x = A.x * Math.Cos(angle) - A.y * Math.Sin(angle);
                A.y = A.y * Math.Cos(angle) + A.x * Math.Sin(angle);
                B.x = B.x * Math.Cos(angle) - B.y * Math.Sin(angle);
                B.y = B.y * Math.Cos(angle) + B.x * Math.Sin(angle);
                C.x = C.x * Math.Cos(angle) - C.y * Math.Sin(angle);
                C.y = C.y * Math.Cos(angle) + C.x * Math.Sin(angle);

                Console.WriteLine($"Координати при поворот на кут {angle} : ({A.x};{A.y}),({B.x};{B.y}),({C.x};{C.y})");

            }

            public void RotatePoint(double angle, Point P)  //поворот на кут відносно точки
            {
                A.x = (A.x - P.x) * Math.Cos(angle) - (A.y - P.y) * Math.Sin(angle);
                A.y = (A.y - P.y) * Math.Cos(angle) + (A.x - P.x) * Math.Sin(angle);
                B.x = (B.x - P.x) * Math.Cos(angle) - (B.y - P.y) * Math.Sin(angle);
                B.y = (B.y - P.y) * Math.Cos(angle) + (B.x - P.x) * Math.Sin(angle);
                C.x = (C.x - P.x) * Math.Cos(angle) - (C.y - P.y) * Math.Sin(angle);
                C.y = (C.y - P.y) * Math.Cos(angle) + (C.x - P.x) * Math.Sin(angle);

                Console.WriteLine($"Координати при поворот на кут {angle} відносно точки ({P.x};{P.y}) : ({A.x};{A.y}),({B.x};{B.y}),({C.x};{C.y})");
            }


            public void method1(string filename) //зберігання створеного об’єкта класу з Завдання 1 у JSON файл
            {
                string toWrite = JsonConvert.SerializeObject(this);
                File.WriteAllText(filename, toWrite);
            }

            public static Triangle method2(string filename) //Відкриває JSON файл з даними та створює об’єкт класу з цими даними для виконання Завдання 1.
            {
                StreamReader r = new StreamReader(filename);
                string jsonString = r.ReadToEnd();
                dynamic json = JsonConvert.DeserializeObject(jsonString);

                double x1 = json.x1;
                double y1 = json.y1;
                double x2 = json.x2;
                double y2 = json.y2;
                double x3 = json.x3;
                double y3 = json.y3;
                Point A = new Point(x1, y1);
                Point B = new Point(x2, y2);
                Point C = new Point(x3, y3);

                return new Triangle(A, B, C);
            }
        }

        static void Main(string[] args)
        {
            Triangle trg = Triangle.method2("C:\\kpii\\programing\\лабороторні\\лаба1\\laba1\\file.json");
        }
    }
}