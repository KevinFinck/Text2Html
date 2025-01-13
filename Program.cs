using Text2Html;
using TextCopy;

//var parseMe = @"
//1.	Why is this Notice being issued?
//2.	What is a class action and who is involved?
//3.	Why is this lawsuit a class action?
//4.	What is this lawsuit about?
//5.	Has the Court decided who is right?
//6.	What are Plaintiffs seeking?
//7.	Is there money available now?
//8.	Am I part of this Class?
//9.	What happens if I do nothing at all?
//10.	 How do I ask to be excluded from the Class?
//11.	 Do I have a lawyer in this lawsuit?
//12.	 Should I hire my own lawyer?
//13.	 How will the lawyers be paid?
//14.	 How and when will the Court decide who is right?
//15.	 Do I have to attend the trial?
//16.	 Will I get money after the trial?
//17.	 Are more details available?
//";
//var results = TextParser.ParseList(parseMe);
//ClipboardService.SetText(results?.TextSection ?? "");
//ClipboardService.SetText(results?.TheList ?? "");



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
