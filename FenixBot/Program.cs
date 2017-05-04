using System;
using FenixBot.Helpers;

namespace FenixBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Format("FenixBot version {0} initialized", VersionHelper.GetFullAssemblyVersion()));

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