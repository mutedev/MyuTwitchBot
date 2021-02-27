using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
namespace MyuTwitchBot
{
    public class Bot
    {
        Random rand = new Random();
        TwitchClient client;
        Command[] commands = JsonConvert.DeserializeObject<Command[]>(File.ReadAllText("./commands.json"));
        static Configuration configuration;

        #region Constructor
        public Bot(Configuration config)
        {
            configuration = config;
            ConnectionCredentials credentials = new ConnectionCredentials(config.twitchUsername, config.authToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, config.channelName);

            client.OnLog += Client_OnLog;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnNewSubscriber += Client_OnNewSubscriber;
            client.Connect();
        }
        #endregion

        #region Events
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            try
            {
                Command cmd = commands.First(c => c.Trigger == e.ChatMessage.Message);
                client.SendMessage(e.ChatMessage.Channel, cmd.Responses[rand.Next(0, cmd.Responses.Length)]);
            }
            catch { }
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            switch (e.Subscriber.SubscriptionPlan)
            {
                case SubscriptionPlan.Prime: client.SendMessage(e.Channel, configuration.subMessagePrime); break;
                case SubscriptionPlan.Tier1: client.SendMessage(e.Channel, configuration.subMessageTier1); break;
                case SubscriptionPlan.Tier2: client.SendMessage(e.Channel, configuration.subMessageTier2); break;
                case SubscriptionPlan.Tier3: client.SendMessage(e.Channel, configuration.subMessageTier3); break;
            }
        }
        #endregion
    }
}