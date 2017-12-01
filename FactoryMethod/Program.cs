using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test FactoryMethod:");
            Client client = new Client();
            client.Demo1();
            client.Demo2();
            client.Demo3();
            Console.WriteLine("Test success");
        }
    }
}
