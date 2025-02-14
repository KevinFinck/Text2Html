namespace Text2Html;

public class Faq
{
    public int? FaqNumber { get; set; }
    public string? Title { get; set; }
    public string? FormattedTitle { get; set; }
    public List<string?> FormattedParagraphs { get; set; } = new List<string?>();
}