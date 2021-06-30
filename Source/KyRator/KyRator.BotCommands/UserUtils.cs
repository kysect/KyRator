namespace KyRator.BotCommands
{
    public class UserUtils
    {
        public static string ParseUserIdFromMention(string mention) => mention.Substring(2, mention.Length - 3);
    }
}