namespace KyRator.BotCommands
{
    public class UserUtils
    {
        public static string ParseUserIdFromMention(string mention) => mention.Substring(3, mention.Length - 4);
    }
}