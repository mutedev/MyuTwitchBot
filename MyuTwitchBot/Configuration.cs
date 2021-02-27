namespace MyuTwitchBot
{
    public class Configuration
    {
        public string twitchUsername {get;set;}
        public string channelName {get;set;}
        public string authToken {get;set;}

        public string subMessagePrime {get;set;} = "";
        public string subMessageTier1 {get;set;} = "";
        public string subMessageTier2 {get;set;} = "";
        public string subMessageTier3 {get;set;} = "";
    }
}