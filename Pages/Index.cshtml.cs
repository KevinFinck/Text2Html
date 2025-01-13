using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using TextCopy;

namespace Text2Html.Pages
{
    public class ParserModel : PageModel
    {
        public string DefaultText { get; set; }
            = @"
        1.	Why is this Notice being issued?
        2.	What is a class action and who is involved?
        3.	Why is this lawsuit a class action?
        4.	What is this lawsuit about?
        5.	Has the Court decided who is right?
        6.	What are Plaintiffs seeking?
        7.	Is there money available now?
        8.	Am I part of this Class?
        9.	What happens if I do nothing at all?
        10.	 How do I ask to be excluded from the Class?
        11.	 Do I have a lawyer in this lawsuit?
        12.	 Should I hire my own lawyer?
        13.	 How will the lawyers be paid?
        14.	 How and when will the Court decide who is right?
        15.	 Do I have to attend the trial?
        16.	 Will I get money after the trial?
        17.	 Are more details available?
        ";



        private readonly ILogger<ParserModel> _logger;

        [BindProperty] 
        public TextParser Parser { get; set; }

        [BindProperty]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Raw Input to Format:")]
        public string Input { get; set; }

        
        
        [BindProperty]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Parsed Output:")]
        public string ParsedOutput { get; set; }


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
        //    //    ParsedOutput = "ModelState is invalid.";
        //    //    return Page();
        //    //}


        //    if (string.IsNullOrWhiteSpace(ParsedOutput))
        //        ParseModel();
        //    else
        //        CopyResultsToClipboard();

        //    return Page();
        //    //return RedirectToPage("./Index", this);
        //}

        public IActionResult OnPostParse()
        {
            var results = TextParser.ParseList(Input);
            if (string.IsNullOrWhiteSpace(results?.TheList) && string.IsNullOrWhiteSpace(results?.TextSection))
            {
                ParsedOutput = "Nothing came back. :(";
                ViewData["FormattedResult"] = ParsedOutput;
                return Page();
            }

            var toHtml = results.TheList.Replace(Environment.NewLine, $"<br />{Environment.NewLine}");

            ParsedOutput = toHtml;
            ViewData["FormattedResult"] = ParsedOutput;

            return Page();
        }

        public IActionResult OnPostCopyToClipboard(string textValue)
        {
            ClipboardService.SetText(textValue ?? "");
            return Page();
        }
    }
}
