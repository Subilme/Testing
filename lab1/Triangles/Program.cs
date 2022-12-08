namespace Triangles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] s = new string[] { "" };
            Console.WriteLine(IfTriangle(s));
        }

        public static string IfTriangle(string[] args)
        {
            try
            {
                if (args.Length != 3)
                {
                    return "ошибка";
                }

                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);
                double c = double.Parse(args[2]);

                if ((a + b > c) && (b + c > a) && (a + c > b))
                {
                    if ((a.Equals(b)) && (b.Equals(c)))
                    {
                        return "равносторонний";
                    }
                    if ((a.Equals(b)) || (a.Equals(c)) || (b.Equals(c)))
                    {
                        return "равнобедренный";
                    }
                    return "обычный";
                }
                return "не треугольник";
            }
            catch
            {
                return "ошибка";
            }
        }
    }
}