using System;
using System.IO;
using Newtonsoft.Json;

namespace MyuTwitchBot
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("./config.json")) File.WriteAllText("./config.json", JsonConvert.SerializeObject(new Configuration(), Formatting.Indented));
            if (!File.Exists("./commands.json")) File.WriteAllText("./commands.json", JsonConvert.SerializeObject(new Command[] { new Command() }, Formatting.Indented));
            Bot twitchBot = new Bot(JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("./config.json")));
            Console.WriteLine("1");
            Console.ReadLine();
        }
    }
}
