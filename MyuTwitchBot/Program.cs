using System;
using System.IO;
using Newtonsoft.Json;

namespace MyuTwitchBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean exit = false;
            if (!File.Exists("./config.json"))
            {
                File.WriteAllText("./config.json", JsonConvert.SerializeObject(new Configuration(), Formatting.Indented));
                exit = true;
            }
            if (!File.Exists("./commands.json"))
            {
                File.WriteAllText("./commands.json", JsonConvert.SerializeObject(new Command[] { new Command() }, Formatting.Indented));
                exit = true;
            }
            if (exit) Environment.Exit(1);

            Bot twitchBot = new Bot(JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("./config.json")));
            Console.ReadLine();
        }
    }
}
