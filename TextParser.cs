using System.Diagnostics;
using System.Text;

namespace Text2Html
{
    public class TextParser
    {
        public class HtmlResults
        {
            public string? TheList { get; set; }
            public string? TextSection { get; set; }
        }

// Input Parser
// Open Reader
// List<faq> = SectionParser(reader)

// Section parser:
        // in: Reader
        // Faq num
        // Faq title
        // Faq paragraphs

// Line parser

        public static HtmlResults? ConvertToHtml(string? input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var theList = new StringBuilder();
            var theTextSections = new StringBuilder();

            var reader = new StringReader(input);
            var faqs = FaqParser(reader);

            foreach (var faq in faqs)
            {
                theList.AppendLine(faq.FormattedTitle);
                theTextSections.AppendLine(string.Join("<br/>", faq.FormattedParagraphs));
            }
            
            var htmlResults = new HtmlResults
            {
                TheList = theList.ToString(),
                TextSection = theTextSections.ToString()
            };

            return htmlResults;
        }

        public static IEnumerable<Faq> FaqParser(StringReader reader)
        {
            var faqs = new List<Faq>();
            
            Faq? faq = null;
            var line = string.Empty;
            do
            {
                line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) 
                    continue;

                int? faqNumber = null;

                var separator = line.IndexOf('.');
                if (separator < 0) separator = line.IndexOf(')');
                if (separator >= 0)
                {
                    var numString = line.Substring(0, separator);
                    if (int.TryParse(numString, out var parsedNum))
                        faqNumber = parsedNum;
                }
                
                if (faqNumber.HasValue)
                {
                    if (faq != null) faqs.Add(faq);
                    faq = new Faq
                    {
                        FaqNumber = faqNumber
                    };
                    if (line.Length > separator + 1)
                    {
                        faq.Title = line
                            .Substring(separator + 1)
                            .Trim();
                        faq.FormattedTitle = $"<li><a href=\"#faq{faq.FaqNumber}\">{faq.Title}</a></li>";
                    }
                    
                    var formatted = $@"   
        <li class=""Answer"">
            <a name=""faq{faq.FaqNumber}""></a>{faq.Title}
            <p></p>

            <a href=""#Top"">Back To Top</a>
        </li>";
                    faq.FormattedParagraphs.Add(formatted);
                }
                else
                {
                    faq.FormattedParagraphs.Add(line);
                }
            } while (line != null);
            if (faq != null) 
                faqs.Add(faq);
            
            return faqs;
        }

    public static string ParagraphParser()
        {
            var input = @"
Class Counsel have not been paid for their work in this case. In addition to thousands of hours of labor spent on this case, Class Counsel have expended substantial expenses prosecuting this case. The Court will determine how much Class Counsel will be paid for fees and expenses. Class Counsel will seek an award for attorneys’ fees of up to one-third of the Settlement Fund, plus reimbursement of Class Counsel’s costs and expenses (no more than $200,000), also to be paid from the Settlement Fund. You will not be responsible for payment of Class Counsel’s fees and expenses. 
Class Counsel will also request a service award payment of up to $50,000 for each Plaintiff (the Plaintiffs named in the lawsuit or the plaintiffs named in the Related Actions) for their service to the Settlement Class. This payment will also be paid from the Settlement Fund. 
The Court must approve any amounts paid to Class Counsel and to Plaintiffs. Class Counsel’s motion seeking an award of attorneys’ fees, reimbursement of costs and expenses, and service awards for the named plaintiffs will be available at www.lincolnCOIsettlement.com.
";

            var result = new StringBuilder();

            using (var reader = new StringReader(input))
            {
                var line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    result.AppendLine($"<p>{line}</p>");

                } while (line != null);
            }


            var clipboard = result.ToString();
            return clipboard;
        }
    }
}