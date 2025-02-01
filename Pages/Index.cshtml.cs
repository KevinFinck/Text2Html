using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using TextCopy;

namespace Text2Html.Pages
{
    public class ParserModel : PageModel
    {
        //public string DefaultText { get; set; } = TestData.SimpleList;
        public string DefaultText { get; set; } = TestData.JointListAndText;



        private readonly ILogger<ParserModel> _logger;

        [BindProperty] 
        public TextParser Parser { get; set; }

        [BindProperty]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Raw Input to Format:")]
        public string? Input { get; set; }



        [BindProperty]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Parsed List:")]
        public string? ParsedFaqList { get; set; }

        [BindProperty]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Parsed FAQ Text:")]
        public string? ParsedFaqText { get; set; }


        //public ParserModel() { }

        public ParserModel(ILogger<ParserModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            Input = DefaultText;
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()

        //public IActionResult OnPostParse()
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    ParsedFaqList = "ModelState is invalid.";
        //    //    return Page();
        //    //}


        //    if (string.IsNullOrWhiteSpace(ParsedFaqList))
        //        ParseModel();
        //    else
        //        CopyResultsToClipboard();

        //    return Page();
        //    //return RedirectToPage("./Index", this);
        //}

        public IActionResult OnPostParse()
        {
            var html = TextParser.ConvertToHtml(Input);
            var results = html;
            if (string.IsNullOrWhiteSpace(results?.TheList) && string.IsNullOrWhiteSpace(results?.TextSection))
            {
                ParsedFaqList = "Nothing came back. :(";
                ParsedFaqText = null;
                ViewData["FormattedResult"] = ParsedFaqList;

                return Page();
            }

            var toHtml = results.TheList.Replace(Environment.NewLine, $"<br />{Environment.NewLine}");

            ParsedFaqList = results.TheList.ConvertLineFeeds();
            ParsedFaqText = results.TextSection.ConvertLineFeeds();
            ViewData["FormattedResult"] = ParsedFaqList;    // TODO: remove?

            return Page();
        }

        public IActionResult OnPostCopyToClipboard(string textValue)
        {
            ClipboardService.SetText(textValue ?? "");
            return Page();
        }
    }
}
