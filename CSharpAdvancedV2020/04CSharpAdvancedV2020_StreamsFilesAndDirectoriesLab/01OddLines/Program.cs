using System.IO;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Input.txt");
            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}