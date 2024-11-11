using Text2Html;
using TextCopy;

var parseMe = @"
1.	Why was this Notice issued?
2.	What is a class action?
3.	What is this lawsuit about?
4.	Why is there a Settlement?
5.	How do I know if I am in the Settlement Class?
6.	What does the settlement provide?
7.	How much will my payment be?
8.	When will I get my payment?
9.	How do I get a payment?
10.	What am I giving up if I stay in the Settlement Class?
11.	Do I have a lawyer in this case?
12.	How will the lawyers be paid?	
13.	How do I get out of the Settlement?
14.	If I don’t exclude myself, can I sue the Defendant for the same thing later?
15.	If I exclude myself, can I get anything from this settlement?
16.	How do I object to the Settlement?
17.	What’s the difference between objecting and excluding myself from the Settlement?
18.	When and where will the Court decide whether to approve the Settlement?
19.	Do I have to come to the hearing?
20.	May I speak at the hearing?
21.	Where do I get more information??
";


var results = TextParser.ParseList(parseMe);
ClipboardService.SetText(results?.TextSection ?? "");
ClipboardService.SetText(results?.TheList ?? "");



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
