using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Text2Html.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty] public TextParser Parser { get; set; }

        [BindProperty] 
        public string Input { get; set; }

        
        
        [BindProperty]
        [DataType(DataType.MultilineText)]
        public string ParsedOutput { get; set; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    ParsedOutput = "ModelState is invalid.";
            //    return Page();
            //}

            var results = TextParser.ParseList(Input);
            if (string.IsNullOrWhiteSpace(results?.TheList) && string.IsNullOrWhiteSpace(results?.TextSection))
            {
                ParsedOutput = "Nothing came back. :(";
                return Page();
            }

            var toHtml = results.TheList.Replace(Environment.NewLine, "<br />");
            ParsedOutput = toHtml;

            return Page();

            //return RedirectToPage("./Index");
        }

    }
}
