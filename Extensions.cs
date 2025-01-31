namespace Text2Html
{
    public static class Extensions
    {
        public static string? ConvertLineFeeds(this string text)
        {
            return text?.Replace(Environment.NewLine, $"<br />{Environment.NewLine}");
        }
    }
}
