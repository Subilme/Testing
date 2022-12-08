namespace TrinaglesTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = "input.txt";
            string output = "output.txt";

            using (StreamReader reader = new(input))
            {
                string text = reader.ReadToEnd();
                args = text.Split("\r\n");
            }

            using (StreamWriter writer = new(output, false))
            {
                foreach (string line in args)
                {
                    var expected = line.Split("\"")[1];
                    string[] parts = line.Substring(0, line.IndexOf("\"")).Trim().Split();
                    string result = Triangles.Program.IfTriangle(parts);
                    if (result == expected)
                    {
                        writer.WriteLine("success");
                        continue;
                    }
                    writer.WriteLine("error");
                }
            }
        }
    }
}