namespace Text2Html;

public class Faq
{
    public int? FaqNumber { get; set; }
    public string? Title { get; set; }
    public List<string?> Paragraphs { get; set; } = new List<string?>();
}