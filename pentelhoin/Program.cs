using System;

namespace pentelhoin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string block = new Block(1, "a", new DateTime(2000, 1, 1), "b", "c").CalculateHash();
            Console.WriteLine(block);
        }
    }
}
