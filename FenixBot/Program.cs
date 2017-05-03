using System;

namespace FenixBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var bot = Bot.Instance();
                    bot.Init();
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("ERROR: {0}", e.Message));
                }
            }
        }
    }
}