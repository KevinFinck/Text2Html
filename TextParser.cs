using System.Diagnostics;
using System.Text;

namespace Text2Html
{
    public class TextParser
    {
        public class HtmlResults
        {
            public string TheList { get; set; }
            public string TextSection { get; set; }
        }

        public static HtmlResults ParseList(string textToProcess)
        {
            var html = ConvertToHtml(textToProcess);
            return html;
            //model.TextToOutput = $"{html.TheList}{Environment.NewLine}{Environment.NewLine}{html.TextSection}";

            //OutputText = model.TextToOutput;

            //ViewData["JavaScript"] = "window.location = '" + Url.Page("Index") + "'";
        }



        public static HtmlResults ConvertToHtml(string? input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var theList = new StringBuilder();
            var theTextSections = new StringBuilder();

            using (var reader = new StringReader(input))
            {
                var line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var periodPos = line.IndexOf(".");
                    if (periodPos >= 0)
                    {
                        var lineNumber = line.Substring(0, periodPos);
                        var theRest = line
                            .Substring(periodPos + 1)
                            .Trim();

                        var formatted = $"<li><a href=\"#faq{lineNumber}\">{theRest}</a></li>";
                        theList.AppendLine(formatted);


                        formatted = $@"   
        <li class=""Answer"">
            <a name=""faq{lineNumber}""></a>{theRest}
            <p></p>

            <a href=""#Top"">Back To Top</a>
        </li>";
                        theTextSections.AppendLine(formatted);
                    }

                } while (line != null);
            }

            var out1 = theList.ToString();
            var out2 = theTextSections.ToString();
            var htmlResults = new HtmlResults
            {
                TheList = theList.ToString(),
                TextSection = theTextSections.ToString()
            };

            return htmlResults;
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



/* Sample from CA40070001 Tan v Quick Box

   1. Why should I read this website?
   If you were billed for La Pura Products between June 20, 2016 and September 9, 2024, you are a member of a Settlement Class.
   This website explains the class action lawsuit, the proposed Settlement, your legal rights, what benefits are available, who is eligible for the benefits, and how to get the benefits.
   The Court in charge of this case is the United States District Court for the Southern District of California. The lawsuit is known as Tan v. Quick Box LLC, Case No. 3:20-cv-01082. You may obtain additional updates on the status of the case by contacting Class Counsel (listed in Question 11 below), checking back to this website for updates, or viewing case information through the Court’s system at www.Pacer.gov. 
   Back to Top
   2. What is this lawsuit about?
   This lawsuit is about whether La Pura Products were marketed in a false or misleading way. “La Pura Products” is a defined term under the Settlement Agreement, meaning “any product manufactured, marketed, sold, or otherwise promoted under the La Pura brand name or any variation thereof, including (but not limited to) La’Pura and LaPura.” The suit alleges that Quick Box Defendants fulfilled these orders regarding La Pura Products. Defendant denies that it did anything wrong. This Settlement is not an admission of any liability. The Court has not decided who is right.
    Back to Top
   3. Why is the lawsuit a class action?
   In a class action lawsuit, one or more people called “Class Representatives” sue on behalf of other people who have similar claims. The people together are a “Class” or “Class Members.” The people who sue – and all the Class Members like them – are called the “Plaintiffs.” The company the Plaintiffs sued (in this case Quick Box LLC, among others) is called the “Defendant.” One court resolves the issues for everyone in the Class – except for those people who choose to exclude themselves from the Class. U.S. District Judge Linda Lopez is in charge of this class action.
   Back to Top
   4. Why is there a Settlement?
   The Court did not decide in favor of Plaintiffs or Defendant. Instead, both sides agreed to a settlement. By agreeing to settle, both sides avoid the cost and risk of a trial, and people who submit valid claims will get compensation. The Class Representative her their attorneys believe the Settlement is best for the Settlement Class and its members. 
   Back to Top
   5. Am I part of the Settlement?
   You are a Class Member if you were billed for La Pura Products between June 20, 2016 and September 9, 2024.
   Excluded from the Settlement are: (i) jurists and mediators who are or have presided over the Action, Plaintiff’s Counsel and Defendants’ Counsel, their employees, legal representatives, heirs, successors, assigns, or any members of their immediate family; (ii) any government entity; (iii) The Quick Box Parties and any entity in which The Quick Box Parties have a controlling interest, any of their subsidiaries, parents, affiliates, and officers, directors, employees, legal representatives, heirs, successors, or assigns, or any members of their immediate family; and (iv) any persons who timely opt out of the Settlement Class.
   Back to Top
   6. What does the Settlement provide?
   The $5.5 million Settlement Fund will provide Monetary Payments to Class Members who submit valid claims. Class notice and claim administration expenses, Plaintiffs’ Counsel’s attorneys’ fees and expenses and any service award to the Class Representative (discussed below) will also be paid out of the Settlement Fund, if approved by the Court. The settlement distribution process will be administered by an independent Settlement Administrator approved by the Court.
   Back to Top
   7. What can I get from the Settlement?
   If you file a Pre-Populated Claim Form, you will be provided a Monetary Payment based on your purchases of La Pura Products as reflected in purchase records. The Monetary Payment is subject to a pro rata increase or decrease depending upon the amount remaining in the Net Fund after all eligible Claims are determined. 
   Based on the applicable purchase records, the Settlement Administrator will determine and notify Class Members of the Monetary Payment, the amount of Class Members can receive via the Settlement Agreement.
   Any money remaining in the Settlement Fund after payment of settlement notice and administration, attorneys’ fees and costs (Question 12 below), and Class Representative service awards (Question 12 below) ordered by the Court, and valid Class Member claims, will be paid pursuant to the cy pres doctrine to the National Consumer Law Center.  
   Back to Top
   8. How can I get my Monetary Payment?
   If you are a Class Member, you must fill out and submit a Claim Form to qualify for a Monetary Payment. You can easily file your Claim online here.  You can also download a paper Claim Form from this website or get one by calling the Settlement Administrator at 1-877-658-0293. The completed Claim Form must be submitted online by February 5, 2025, or by mail at the address below, received by February 5, 2025.
   Tan v. Quick Box Settlement Administrator
   P.O. Box 2449
   Portland, OR 97208-2449
   Upon receiving a completed Claim Form, the Settlement Administrator will review the documentation and confirm or deny your eligibility for an award.
   Back to Top
   9. When will I receive my Monetary Payment?
   The Court will hold a hearing on January 6, 2025 (which is subject to change), to decide whether to approve the Settlement. Even if the Court approves the Settlement, there may be appeals. The appeal process can take time, perhaps more than a year. You will not receive your Monetary Payment until any appeals are resolved. Please be patient.
   Back to Top
   10. What am I giving up to receive these Settlement benefits?
   Unless you exclude yourself (“opt out”) from the Settlement Class by timely submitting an Exclusion Request (see Questions 13-14 below), you will remain in the Settlement Class. By remaining in the Settlement Class you “release” and can’t sue, continue to sue, or be part of any other lawsuit against the Quick Box Defendants about the “Released Claims” in this case. These Released Claims are only those claims that you could have brought based on the identical factual predicate of those claims brought in this case about the alleged misleading marketing and labeling of La Pura Products between June 20, 2016 and September 9, 2024.
   The Settlement Agreement at Section VIII (titled “Releases”) describes these “Released Claims” and the “Released Parties” in necessary legal terminology, so read these sections carefully. The Settlement Agreement is available on this website or in the public court records on file in this lawsuit. For questions regarding the Releases or what they mean, you can also talk to one of the lawyers listed in Question 11 below for free, or you can, talk to your own lawyer at your own expense.
   Back to Top
   11. Do I have lawyers in this case?
   The Court has appointed attorneys from the law firm Kneupper & Covey, PC of Huntington Beach, CA, to represent you and the other Class Members. The lawyers are called Class Counsel. They are experienced in handling similar class action cases. You will not be charged for these lawyers. If you want to be represented by your own lawyer, you may hire one at your own expense.
   You may contact Class Counsel if you have any questions about this Notice or the Settlement. Please do not contact the Court.
   Class Counsel:
   Kevin Kneupper
   Cyclone Covey
   KNEUPPER & COVEY, PC
   17011 Beach Blvd., Ste. 900
   Huntington Beach, CA 92647-5998
   Tel: 512-420-8407
   Email: cyclone@kneuppercovey.com
   Website: www.kneuppercovey.com 
   Back to Top
   12. How will the lawyers be paid?
   Class Counsel will ask the Court for an award of attorneys’ fees of up to 1/3 of the Settlement Fund ($1,833,333.33) and for reimbursement of expenses incurred through the date of the Settlement ($84,040.37) and additional expenses incurred related to this notice and the administration of payment of the award (which will be disclosed in the motion for attorney's fees and costs, but are currently estimated at $124,456). Any award of attorneys’ fees and costs will be paid from the Settlement Fund. Class Counsel will also ask the Court for a service award for the Class Representative (up to $6,000). The purpose of the service awards is to compensate the Plaintiff for her time, efforts and risks taken on behalf of the Settlement Class. Any award of payment to the Class Representative will be paid from the Settlement Fund.
   Back to Top
   13. How do I get out of the Settlement?
   If you don’t want a Monetary Payment, but want to keep the right to sue or continue to sue the Quick Box Defendants on your own, on the basis of the legal issues in this case, then you must take steps to exclude yourself from the Settlement (get out of the Settlement). This is called “excluding yourself”—or is sometimes referred to as “opting out” of the Settlement Class.
   To exclude yourself from the Settlement, you must send a “Request for Exclusion” in the form of a letter or Request for Exclusion form stating that you want to be excluded from Tan v. Quick Box LLC, Case No. 3:20-cv-01082. Be sure to include your name, address, telephone number, and basis upon which you are a Class Member. You must mail your Request for Exclusion received by December 23, 2024 to: Tan v. Quick Box Settlement Administrator, P.O. Box 2449, Portland, OR 97208-2449. A Request for Exclusion form can also be obtained on this website. 
   If you do not follow these procedures and deadlines, you will remain a Class Member and lose any opportunity to exclude yourself from the Settlement. This means that your rights will be determined in this lawsuit by the Settlement Agreement if it receives final approval from the Court.
   Back to Top
   14. If I exclude myself, can I get anything from the Settlement?
   No. If you exclude yourself, you cannot receive Monetary Payments. But, you may sue, continue to sue, or be part of a different lawsuit against the Quick Box Defendants about the legal issues in this case.
   Back to Top
   15. How do I tell the Court that I don’t like the Settlement?
   If you’re a Class Member, you can object to the Settlement if you don’t like any part of it. You can give reasons why you think the Court should not approve it. The Court will consider your views. Note: You can’t ask the Court to order a different Settlement; the Court can only approve or reject the Settlement. If the Court denies approval, no settlement awards will be sent out and the lawsuit will continue. If that is what you want to happen, you must object.
   To object, you must send a letter. Be sure to include the following information:
   a.	The case name and number (Tan v. Quick Box LLC, Case No. 3:20-cv-01082-LL-DDL); 
   b.	Your name, address, telephone number and, if represented by counsel, the name, address, and telephone number of your counsel; 
   c.	A statement under oath that you are a Class Member; 
   d.	A statement whether you intend to appear at the Final Approval Hearing, either in person or through counsel; 
   e.	A statement of all your objections and the specific grounds supporting your objections; 
   f.	A statement whether the objection applies only to you, to a specific subset of the Settlement Class, or to the entire Settlement Class; 
   g.	Copies of any papers, briefs, or other documents upon which your objection is based; and 
   h.	Your handwritten, dated signature (the signature of your counsel, an electronic signature, and the annotation “/s” or similar annotation will not suffice).
   Your objection must be submitted to the Court either by mailing (or by filing it at any location of the United States District Court for the Southern District of California) and served on Class Counsel and Defendant’s Counsel received no later than December 23, 2024, to the following addresses:
   Court:
   Clerk
   United States District Court,
   Southern District of California
   221 West Broadway
   San Diego, CA 92101	Class Counsel:
   Kevin Kneupper 
   Cyclone Covey
   Kneupper & Covey PC
   17011 Beach Blvd, Suite 900
   Huntington Beach, CA 92647	Defense Counsel:
   David T. Biderman
   Thomas J. Tobin
   Perkins Coie LLP
   1888 Century Park East, Suite 1700
   Los Angeles, CA 90067
   If you timely file an objection it will be considered by the Court at the Final Approval Hearing. You do not need to attend the Final Approval Hearing for the Court to consider your objection.
   The Court will require substantial compliance with these requirements above. If you do not submit a written objection in accordance with the deadline and procedure set forth above, you will waive your right to be heard at the Final Approval Hearing. However, the Court may excuse your failure to file a written objection upon a showing of good cause, which, if granted, would permit you to still appear at the Final Approval Hearing and object to the Settlement. 
   Back to Top 
   16.What is the difference between objecting and asking to be excluded?
   Objecting is simply telling the Court that you don’t like something about the Settlement. You can object only if you stay in the Settlement Class. Excluding yourself is telling the Court that you don’t want to be part of the Settlement Class. If you exclude yourself, you have no basis to object because you are no longer part of the case.
   Back to Top 
   17.When and where will the Court decide whether to approve the Settlement?
   
   The Court will hold a Final Approval Hearing on January 6, 2025, at the United States District Court for the Southern District of California, 221 West Broadway, San Diego, CA 92101. 
   At the hearing, the Court will hear any comments, objections, and arguments concerning the fairness of the proposed Settlement, including the amount requested by Class Counsel for attorneys’ fees and expenses. If there are objections, the Court will consider them. You do not need to attend this hearing. You also do not need to attend to have a comment or objection considered by the Court. After the hearing, the Court will decide whether to approve the Settlement. We do not know how long these decisions will take.
   Note: The date and time of the Final Approval Hearing are subject to change by Court Order. Any change will be posted on this website. You should check the website or the Court’s PACER website to confirm that the date and/or time have not changed.
   Back to Top 
   18.Do I have to attend the Final Approval Hearing?
   No. Class Counsel will answer all questions Judge Lopez may have. But, you are welcome to attend the hearing at your own expense. If you submit an objection, you do not have to attend the hearing to talk about your objection. As long as you filed your written objection by the deadline, the Judge will consider it. You may also pay your own lawyer to attend, but it is not necessary. 
   Back to Top 
   19.May I speak at the Final Approval Hearing?
   As long as you do not exclude yourself, you can (but do not have to) participate and speak for yourself in this lawsuit and Settlement. This is called making an appearance. You can also have your own lawyer speak for you, but you will have to pay for the lawyer yourself. 
   If you want to appear, or if you want your own lawyer instead of Class Counsel to speak for you in this lawsuit, you must send a letter saying that it is your “Notice of Intention to Appear in Tan v. Quick Box LLC.” Be sure to include your name, address, telephone number, and your signature. Your Notice of Intention to Appear must be received by December 30, 2024, and be sent to the Clerk of Court at the address listed in Question 15.
   If you want to speak at the Final Approval Hearing without having followed these procedures, you may do so if you demonstrate good cause to the Court.
   Back to Top 
   20.What happens if I do nothing at all?
   If you do nothing, you’ll be part of the Settlement Class, but get no Monetary Payment from the Settlement. Unless you exclude yourself, you will not be permitted to continue to assert Released Claims in any other lawsuit against the Quick Box Defendants about the legal issues in this case, ever again.
   Back to Top 
   21.Are there more details about the Settlement?
   This notice summarizes the proposed Settlement. More details are in the Settlement Agreement. You can get a copy of the Settlement Agreement at www.LaPuraClassActionSettlement.com, or by contacting Class Counsel by email or telephone at the address or number listed in response to Question 11 above. 
   Back to Top 
   22.How do I get more information?
   You can call toll-free 1-877-658-0293; write to Tan v. Quick Box Settlement Administrator, P.O. Box 2449, Portland, OR 97208-2449; or review this website, where you will find answers to common questions about the Settlement, a Claim Form, motions for approval of the Settlement and Class Counsel’s request for attorneys’ fees and expenses, and other important documents in the case.
   You can also access information about this case through the Court’s Public Access to Court Electronic Records (PACER) system. To learn about PACER and register for a PACER account, go to https://www.Pacer.gov/. Once you have a PACER account, you can access and retrieve documents from the Court’s docket for the Action at https://ecf.casd.uscourts.gov/. You can also access and retrieve documents from the Court’s docket by visiting the Clerk’s Office located at United States District Court for the Southern District of California, 221 West Broadway, San Diego, CA 92101, during business hours.
   
   PLEASE DO NOT TELEPHONE THE COURT OR THE COURT’S CLERK TO INQUIRE ABOUT THIS SETTLEMENT OR THE CLAIM PROCESS 
    
 */
