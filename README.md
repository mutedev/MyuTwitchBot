# MyuTwitchBot
A simple Twitch bot that can easily be configured.

* Used on [my Twitch Channel](https://twitch.tv/subsilence_myu)

<br>

# Download
[Version 1.0 - Initial Release](https://github.com/mutedev/MyuTwitchBot/releases/tag/1.0) <- Right here on GitHub

[Version 1.1 - Random Response Commands](https://github.com/mutedev/MyuTwitchBot/releases/tag/1.1) <- Right here on GitHub

<br>

# config.json example
```json
{
    "twitchUsername": "Your Twitch Username 💜",
    "channelName": "Your Twitch Username 💜",
    "authToken": "Generated token",
    "subMessagePrime": "Message for new prime subscribers 🧡",
    "subMessageTier1": "Message for new tier 1 subscribers 💜",
    "subMessageTier2": "Message for new tier 2 subscribers 💜💜",
    "subMessageTier3": "Message for new tier 3 subscribers 💜💜💜"
}
```
* You can generate your token [here](https://twitchapps.com/tmi/) (This will link to an external website).

# commands.json example
```json
[
    {
        "Trigger": "!discord",
        "Responses": [ 
            "Invite to your Discord server :D"   
        ]
    },
    {
        "Trigger": "!schedule",
        "Responses": [ 
            "Some schedule information 📅",
            "Here is my schedule 📅"   
        ]
    }
]
```
* You can basicly make infinite commands, each with one custom response.

