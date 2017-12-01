using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test SimpleFactory:");
            Client client = new Client();
            client.Demo1();
            client.Demo2();
            client.Demo3();
        }
    }
}
