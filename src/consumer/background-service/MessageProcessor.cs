using System;
using System.Threading.Tasks;

namespace background_service
{
    public static class MessageProcessor
    {
        public async static Task Process(string message)
        {
            Console.WriteLine($"Processando: {DateTime.Now.ToUniversalTime()}");
            Console.WriteLine(message);
        }
    }
}