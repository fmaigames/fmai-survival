using System;

namespace FMAI.Survival.Social
{
    public enum ChatChannelType
    {
        Global,
        Town,
        Party,
        Private,
        Admin
    }

    [Serializable]
    public class ChatMessage
    {
        public string senderId;
        public ChatChannelType channel;
        public string text;
        public long timestampUtcTicks;

        public ChatMessage(string sender, ChatChannelType type, string message)
        {
            senderId = sender;
            channel = type;
            text = message;
            timestampUtcTicks = DateTime.UtcNow.Ticks;
        }
    }
}
